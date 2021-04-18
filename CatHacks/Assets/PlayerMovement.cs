using UnityEngine;


public class PlayerMovement : MonoBehaviour
{
    [SerializeField]private float speed;
    [SerializeField]private float velocityX;
    private Rigidbody2D body;
    private Animator animate;
    private bool grounded;
    private bool left = false;
    
    private void Awake()
    {
        // Creates references for the components to pull from
        body = GetComponent<Rigidbody2D>();
        animate = GetComponent<Animator>();
    }
    

    public void Update()
    {
        // Basic Input of the Arrow Keys that gives us horizontal movement
        float horizontalInput = Input.GetAxis("Horizontal");
        body.velocity = new Vector2(Input.GetAxis("Horizontal") * velocityX, body.velocity.y);

        // Flips the player if he is facing right or left
        if (horizontalInput > 0.01f && left == true) 
        {
            transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
            transform.Rotate(0f, 180f, 0f);
            left = false;
        }
        else if (horizontalInput < -0.01f && left == false) 
        {
            transform.Rotate(0f, 180f, 0f);
            left = true;
        }
        // Checks to see if the space bar is pressed or not grounded and if so jumps
        if (Input.GetKey(KeyCode.Space) && grounded != false)
        {
            Jump();
        }
        
        // Creates animator parameters
        animate.SetBool("Run", horizontalInput != 0);
        animate.SetBool("Grounded", grounded);  
      //  animate.SetBool("shooting", shooting);
    }


    private void Jump() 
    {
        body.velocity = new Vector2(body.velocity.x, speed);
        grounded = false;
    }

    private void OnCollisionEnter2D(Collision2D collision) 
    {
        if (collision.gameObject.tag == "Ground")
            grounded = true;
    }

}