using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float speed;
    public float horzInput;
    public float jumpForce;

    private Vector2 velocity;

    private Rigidbody2D playerRB;

    private GroundCheck groundCheck;
    // Start is called before the first frame update
    void Start()
    {
        //Get the components
        playerRB = GetComponent<Rigidbody2D>(); 
        groundCheck = GameObject.Find("GroundCheck").GetComponent<GroundCheck>();

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        

        //Move The Player
        Vector2 pos = Vector2.right * speed * Time.deltaTime * horzInput;
        velocity = playerRB.velocity;
        velocity.x = pos.x;
        playerRB.velocity = velocity;

        
    }

    void Update()
    {
        //Jump
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (groundCheck.grounded)
            {
                Jump();
            }
        }
     
        //Get Inputs
        horzInput = Input.GetAxis("Horizontal");
    }

    void Jump()
    {
        playerRB.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }
}
