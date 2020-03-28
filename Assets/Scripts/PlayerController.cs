using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float speed;
    public float horzInput;
    public float jumpForce;
    public float wallspeed;
    public float wallJumpForce;

    public bool isWallSliding = false;

    public string facing = "Right";

    private Vector2 velocity;
    public Vector2 wallJumpDirection;

    private Rigidbody2D playerRB;

    private GroundCheck groundCheck;
    private WallDetector wallCheck;
    // Start is called before the first frame update
    void Start()
    {
        //Get the components
        playerRB = GetComponent<Rigidbody2D>(); 
        groundCheck = GameObject.Find("GroundCheck").GetComponent<GroundCheck>();
        wallCheck = GameObject.Find("WallDetector").GetComponent<WallDetector>();

        wallJumpDirection.Normalize();



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
        
     
        //Get Inputs
        horzInput = Input.GetAxis("Horizontal");
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }

        //Face Left or Right
        if(horzInput < 0 )
        {
            facing = "Left";
        }
        if(horzInput > 0 )
        {
            facing = "Right";
        }

        //WallSlide
        if(wallCheck.Walled && playerRB.velocity.y < 0)
        {
            if(playerRB.velocity.y < -wallspeed)
            {
                isWallSliding = true;
                playerRB.velocity = new Vector2(playerRB.velocity.x, -wallspeed);
            }
            isWallSliding = false;
        }
        

    }

    void Jump()
    {
        if(groundCheck.grounded == true)
        {
            playerRB.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
        else if((isWallSliding || wallCheck.Walled) && horzInput != 0)
        {
            Vector2 forceToAdd = new Vector2(wallJumpForce * wallJumpDirection.x * horzInput, wallJumpForce * wallJumpDirection.y);
            playerRB.velocity = new Vector2(playerRB.velocity.x, 0);
            playerRB.AddForce(forceToAdd, ForceMode2D.Impulse);
        }
    }

    
}
