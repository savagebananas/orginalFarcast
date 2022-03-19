using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;

/*This script rotates the weapon object to face the mouse*/

public class followCursor : MonoBehaviour
{
    public GameObject player;
    public GameObject weaponRef;

    void Update()
    {
        //Get the Screen position of the mouse
        Vector3 difference = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue()) - transform.position;
        difference.Normalize();
        float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotationZ);

        transform.position = weaponRef.transform.position;

        if (rotationZ < -90 || rotationZ > 90) 
        {
            if(player.transform.eulerAngles.y == 0)
            {
                transform.localRotation = Quaternion.Euler(180, 0, -rotationZ);
            }
            else if (player.transform.eulerAngles.y == 180) //player facing left
            {
                transform.localRotation = Quaternion.Euler(180, 180, -rotationZ);
            }
        }


    }

 
}
