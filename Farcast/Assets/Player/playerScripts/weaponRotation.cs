using UnityEngine.InputSystem;
using UnityEngine;

public class weaponRotation : MonoBehaviour
{
    
    
    void Update()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
    }
}
