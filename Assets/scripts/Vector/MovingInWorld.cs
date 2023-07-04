using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingInWorld : MonoBehaviour
{
    public Vector3 inputDirection;
    public float moveSpeed;
    void Update()
    {
        Movement();

    }



    private void Movement()
    {

        Vector3 DIRECTION = Vector3.zero;
        DIRECTION += Input.GetAxisRaw("Horizontal") * transform.right;
        DIRECTION += Input.GetAxisRaw("Vertical") * transform.forward;
           /* x: Input.GetAxisRaw("Horizontal"),
            y: GetUpDownMovement(),
            z: Input.GetAxisRaw("Vertical")); */
           
            DIRECTION.Normalize();
            DIRECTION *= moveSpeed * Time.deltaTime;
            transform.position += DIRECTION;

    }
    private float GetUpDownMovement()
    {
        float UPDOWN_INPUT = 0;
        if (Input.GetKey(KeyCode.LeftShift))
        {
            UPDOWN_INPUT -= 1;
            }
        if (Input.GetKey(KeyCode.Space))
        {
            UPDOWN_INPUT += 1;
        }
        return UPDOWN_INPUT;
    }

}
/* JUST DO IT
 * Make the character walk in ITS forward direction- [It's a wrap]
 * -instead of the world forward [It's a wrap]
 * Make the camera zoomable [WORKING]
 * */

/*
 * 
 */