using UnityEngine;

public class Knight : MonoBehaviour
{
    private Rigidbody2D playerRigidBody;
    public float moveSpeed;
    public float jumpForce;
    private float inputHorizontal;
    private bool grounded = true;
    public GameManagerScript gameManager;



    private void Start()
    {
        playerRigidBody = GetComponent<Rigidbody2D>();
        // Ensure the GameManagerScript is assigned
        if (gameManager == null)
        {
            gameManager = FindObjectOfType<GameManagerScript>();
            if (gameManager == null)
            {
                Debug.LogError("GameManagerScript not found in the scene!");
            }
        }
    }

    void Update()
    {
        movePlayerLateral();
        jump();
    }

    private void movePlayerLateral()
    {
        inputHorizontal = Input.GetAxis("Horizontal");
        playerRigidBody.velocity = new Vector2(inputHorizontal * moveSpeed * -1, playerRigidBody.velocity.y);
    }

    private void jump()
    {
        Debug.Log("Jumping");
        if (Input.GetKeyDown(KeyCode.Space) && grounded)
        {
            playerRigidBody.velocity = new Vector2(playerRigidBody.velocity.x, jumpForce);
            grounded = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            grounded = true;
        }

        if (collision.gameObject.CompareTag("Playerr"))
        {

            gameManager.GameOver(); // Call the GameOver method from GameManagerScript
            
        }
    }
}
