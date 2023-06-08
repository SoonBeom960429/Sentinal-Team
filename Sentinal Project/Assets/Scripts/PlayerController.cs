using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public Rigidbody theRB;
    public float moveSpeed, JumpForce;

    private Vector2 MoveInput;
    public LayerMask whatIsGround;
    public Transform groundPoint;
    private bool isGrounded;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MoveInput.x = Input.GetAxis("Horizontal");
        MoveInput.y = Input.GetAxis("Vertical");
        MoveInput.Normalize();

        theRB.velocity = new Vector3(MoveInput.x * moveSpeed, theRB.velocity.y, MoveInput.y * moveSpeed);

        RaycastHit hit;
        if(Physics.Raycast(groundPoint.position,Vector3.down, out hit, .3f, whatIsGround))
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }
        if(Input.GetButtonDown("Jump")&& isGrounded)
        {
            theRB.velocity += new Vector3(0f, JumpForce, 0f);
        }

    }
}
