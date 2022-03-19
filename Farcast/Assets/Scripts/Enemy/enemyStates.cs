using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyStates : MonoBehaviour
{
    public GameObject player;
    public LayerMask whatIsPlayer;

    public float alertRange;
    public float surroundRange;
    public float attackRange;
    public float walkPointRange;


    public int health;
    public int damage;
    public float speed;
    public float attackTime;
    public float flashTime;
    public float knockbackResistance;
    public SpriteRenderer renderer;
    public Animator weapon;
    public Rigidbody2D rb;

    public AudioClip[] audioClips;
    public AudioSource audioSource;
    public AudioListener audioListener;

    public cameraShake cameraControls;
    public Animator animator;


    [SerializeField] public Color damagedColor; 

    private bool inAlertRange;
    private bool inSurroundRange;
    private bool inAttackRange;

    private bool followState;
    private bool attackState;
    private bool surroundState;
    private float timeSinceLastAttack;
    private bool isHit;
    private float timeAfterHit;
    private Color origionalColor;
    private bool isWalking = false;
    private bool idle = true;
    private Vector2 walkPoint;
    [SerializeField] public bool inBattle = false;
    private bool facingRight = true;
    private float oldPosition;

    void Awake()
    {
        origionalColor = renderer.color;
    }

    private void Update()
    {
        inAlertRange = Physics2D.OverlapCircle(transform.position, alertRange, whatIsPlayer);
        inAttackRange = Physics2D.OverlapCircle(transform.position, attackRange, whatIsPlayer);
        inSurroundRange = Physics2D.OverlapCircle(transform.position, surroundRange, whatIsPlayer);

        if ((Vector2) transform.position == walkPoint) isWalking = false;

        if (timeAfterHit > flashTime) callingStateMachines();

        faceDirection();

        timeAfterHit += Time.deltaTime;
        timeSinceLastAttack += Time.deltaTime;
    }

    public void LateUpdate()
    {
        oldPosition = transform.position.x;
    }

    //==============================================================================
    //  TAKE DAMAGE AND DEATH 
    //==============================================================================

    public void takeDamage(int damage)
    {
        rb.bodyType = RigidbodyType2D.Dynamic;
        health -= damage;
        StartCoroutine(cameraControls.Shake(.15f, .1f)); //camera shake
        PlayRandomAudio();
        FlashRed();
        animator.SetBool("IsDamaged", true);
        timeAfterHit = 0;
        Invoke("stopForce", flashTime);
    }

    private void stopForce()
    {
        rb.bodyType = RigidbodyType2D.Kinematic;
        rb.velocity = Vector3.zero;
    }

    public void checkDead()
    {
        if (health <= 0)
        {
            Debug.Log("Enemy Dead!");
            StartCoroutine(cameraControls.Shake(.3f, .3f)); //camera shake
            Destroy(this);
        }
    }

    //==============================================================================
    //  CALLING STATE MACHINES
    //==============================================================================

    void callingStateMachines()
    {
        if (!inAlertRange && !inSurroundRange && !inAttackRange) patroling(); inBattle = false;
        if (inAlertRange && !inSurroundRange && !inAttackRange && !inBattle) followingState(); //follow
        if (inSurroundRange)
        {
            inBattle = true;
            if (timeSinceLastAttack > attackTime + Random.Range(0, 4)) //cooldown ended
            {
                attackingState();
            }
            else
            {
                attackCooldownState();
            }
        }
    }

    //==============================================================================
    //  FACE DIRECTION OF PLAYER OR FACE DIRECTION OF ROAM
    //==============================================================================
    void faceDirection()
    {
        if (inSurroundRange)
        {
            if (player.transform.position.x < animator.transform.position.x && facingRight) faceLeft();
            if (player.transform.position.x > animator.transform.position.x && !facingRight) faceRight();
        }
        else if(!inSurroundRange)
        {
            if(transform.position.x > oldPosition && !facingRight) // moving right
            {
                faceRight();
            }
            if (transform.position.x < oldPosition && facingRight) //moving left
            {
                faceLeft();
            }
        }
    }

    void faceRight()
    {
        transform.rotation = Quaternion.identity;
        facingRight = true;
    }

    void faceLeft()
    {
        transform.rotation = Quaternion.Euler(0, 180, 0);
        facingRight = false;
    }

    //==============================================================================
    //  Patrolling Script (walk point range determines the range it can walk) (Can add if within bounds of enemy camp)
    //==============================================================================

    private void patroling() //runs every frame
    {
        if (!isWalking && idle) //if enemy has reached point
        {
            StartCoroutine(timer());
            SearchWalkPoint();
        }
        else transform.position = Vector2.MoveTowards(transform.position, walkPoint, speed * Time.deltaTime);
        if (isWalking) roamingState();
        if (!isWalking) idleState();
    }

    private void SearchWalkPoint()
    {
        isWalking = true;
        float randomX = Random.Range(-walkPointRange, walkPointRange);
        float randomY = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector2(transform.position.x + randomX, animator.transform.position.y + randomY);
    }

    private IEnumerator timer()
    {
        idle = false;
        yield return new WaitForSeconds(Random.Range(2, 8));
        idle = true;
    }

    //==============================================================================
    //  Change Color after hit
    //==============================================================================
    void FlashRed()
    {
        renderer.color = damagedColor;
        Invoke("ResetColor", flashTime);
    }
    void ResetColor()
    {
        renderer.color = origionalColor;
        animator.SetBool("IsDamaged", false);
    }

    //==============================================================================
    //  Play Random Audio
    //==============================================================================
    void PlayRandomAudio()
    {
        audioSource.clip = audioClips[Random.Range(0, audioClips.Length)];
        audioSource.Play();
    }

    //==============================================================================
    //  STATE MACHINES
    //==============================================================================
    void idleState()
    {
        animator.SetTrigger("idle");
    }

    void roamingState()
    {
        animator.SetTrigger("isRoaming");
    }

    void followingState()
    {
        animator.SetTrigger("isFollowing");
    }

    void attackSprintState()
    {
        animator.SetTrigger("isSprinting");
    }

    void attackCooldownState()
    {
        animator.SetTrigger("attackCooldown");
    }

    void attackingState()
    {
        if (inAttackRange && timeSinceLastAttack > attackTime)
        {
            animator.SetTrigger("isAttacking");
            weapon.SetTrigger("isAttacking");
            player.GetComponent<playerGeneral>().takeDamage(damage);
            timeSinceLastAttack = 0;
        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * 1.2f * Time.deltaTime);
            attackSprintState();
        }
    }

    void OnDrawGizmosSelected() //displays the area in of attack range
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, alertRange);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
        Gizmos.color = Color.magenta;
        Gizmos.DrawWireSphere(transform.position, surroundRange);
    }
}
