using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    public Vector3 inputDirection;
    [SerializeField]
    public float moveSpeed;
    [SerializeField]
    private Rigidbody rb;
    [SerializeField]
    private float jumpStrength;
    private int groundTouchCount = 0;
    void Update()
    {
        Movement();
        Jump();

    }



    public void Movement()
    {
        
        Vector3 DIRECTION = Vector3.zero;
        DIRECTION += Input.GetAxisRaw("Horizontal") * transform.right;
        DIRECTION += Input.GetAxisRaw("Vertical") * transform.forward;

        DIRECTION *= moveSpeed * Time.deltaTime;
        DIRECTION.Normalize();
        transform.position += DIRECTION;

    }
    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) == false || groundTouchCount == 0 ) 
        return;
        rb.velocity = new Vector3(0, jumpStrength, 0);





    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            groundTouchCount++;


        }

        
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            groundTouchCount--;

            if (groundTouchCount < 0)
            {
                Debug.LogError("SHIIIIIEEEED");
            }

        }
    }
    public void Start()
    {
        GameManager.SubscribeToPause(Toggle);
    }
    private void Toggle(bool _State)
    {
        enabled = !_State;
    }
    private void OnDestroy()
    {
        GameManager.UnSubscribeToPause(Toggle);
    }

    public void setMoveSpeed()
    {
        transform.position *= moveSpeed;
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
