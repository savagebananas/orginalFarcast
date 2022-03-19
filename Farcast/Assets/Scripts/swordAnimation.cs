using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*This script has everything related to attack and animation of a specific weapon*/
public class swordAnimation : MonoBehaviour
{
    public int damage;
    playerGeneral player;
    public float knockbackPower;
    public float attackTime;
    private float timeBtwAttack = 0;

    CursorController playerInput;
    public cameraShake cameraControls;

    public GameObject cursor;
    public GameObject swipe;
    public GameObject weaponType;  
    private Animator weaponTypeAnimator;
    public Animator weaponAnimator;
    public Animator swipeAnimator;

    public Transform attackPos;
    public float attackRange;
    public LayerMask whatIsEnemies;

    public AudioClip[] audioClips;
    public AudioSource audioSource;
    public AudioListener audioListener;

    void Start()
    {
        playerInput = cursor.GetComponent<CursorController>();
        swipeAnimator = swipe.GetComponent<Animator>();
        weaponTypeAnimator = weaponType.GetComponent<Animator>();
        audioListener = GetComponent<AudioListener>();
        audioSource = gameObject.GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (timeBtwAttack > attackTime) //cooldown over
        {
            if (playerInput.AttackPressed)
            {
                AttackCall();
            }
        }
        else
        {
            timeBtwAttack += Time.deltaTime;
        }
    }

    void AttackCall()
    {
        Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, whatIsEnemies);
        for (int i = 0; i < enemiesToDamage.Length; i++)
        {
            enemiesToDamage[i].GetComponent<enemyStates>().takeDamage(damage); //calls damage function on every enemy within attack range
            float knockbackRes = enemiesToDamage[i].GetComponent<enemyStates>().knockbackResistance;
            StartCoroutine(knockback(enemiesToDamage[i].GetComponent<enemyStates>().flashTime, knockbackPower, knockbackRes, enemiesToDamage[i].transform, enemiesToDamage[i].attachedRigidbody));
        }
        weaponAnimator.SetTrigger("Attack");
        swipeAnimator.SetTrigger("Attack");
        weaponTypeAnimator.SetTrigger("Attack");
        timeBtwAttack = 0;
        PlayRandomAudio();
    }


    IEnumerator knockback(float knockbackDuration, float knockbackPower, float knockbackRes, Transform obj, Rigidbody2D objRb)
    {
        float timer = 0;
        while (knockbackDuration > timer)
        {
            timer += Time.deltaTime;
            Vector2 direction = (obj.transform.position - this.transform.position).normalized;
            objRb.AddForce(direction * (knockbackPower - knockbackRes));
        }
        yield return 0;
    }

    //==============================================================================
    //  PLAY RANDOM AUDIO
    //==============================================================================
    void PlayRandomAudio()
    {
        audioSource.clip = audioClips[Random.Range(0, audioClips.Length)];
        audioSource.Play();
    }

    void OnDrawGizmosSelected() //displays the area in unity of attack range
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPos.position, attackRange);
    }
}
