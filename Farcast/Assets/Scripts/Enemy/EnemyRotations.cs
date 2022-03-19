using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRotations : MonoBehaviour
{
    Vector2 currentDirection;
    Vector2 lastLocation;
    Vector2 currentLocation;
    private bool facingRight;

    void Update()
    {

        //transform.localScale.Set(target.x > transform.position.x ? 1f : -1f, 1f);
        currentLocation = transform.position;
        currentDirection = (currentLocation - lastLocation).normalized;
        //if(currentDirection < transform.position.x && FacingRight) { Flip(); }
       //if (currentDirection > transform.position.x && !FacingRight) { Flip(); }
    }

    private void LateUpdate()
    {
        lastLocation = currentLocation;
    }

    void Flip()
    {
        Vector3 tmpScale = transform.localScale;
        tmpScale.x = -tmpScale.x;
        transform.localScale = tmpScale;
        facingRight = !facingRight;
    }


}
