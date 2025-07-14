using UnityEngine;
using TMPro;

public class Player : MonoBehaviour
{
    public GameManagerScript gameManager; 
    private Rigidbody2D playerRigidBody;
    public float moveSpeed;
    public float jumpForce;
    private float inputHorizontal;
    private bool grounded = true;
    public static int playerScore = 0;
    public TextMeshProUGUI scoreText; 
    public static bool shielded = false;
    private bool multiplierActive = false;

    void Start()
    {
        playerScore = 0;
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
        playerRigidBody.velocity = new Vector2(inputHorizontal * moveSpeed, playerRigidBody.velocity.y);
    }

    private void jump()
    {
        Debug.Log("Jumping");
        if(Input.GetKeyDown(KeyCode.Space) && grounded)
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
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Coin"))
        {
            Destroy(collision.gameObject);
            Debug.Log("Coin collected!");
            playerScore += 1; 
            scoreText.text = "Score: " + playerScore; 
        }
        if (collision.gameObject.CompareTag("Shield"))
        {
            Destroy(collision.gameObject);
            Debug.Log("Shield collected!");
            shielded = true;
        }
        if (collision.gameObject.CompareTag("ScoreMult"))
        {
            Destroy(collision.gameObject);
            Debug.Log("Multiplier collected!");
            multiplierActive = true;
            playerScore *= 2; // Double the score
            scoreText.text = "Score: " + playerScore;
        }
    }


}
