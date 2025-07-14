using UnityEngine;

public class HurtBox : MonoBehaviour
{
    public GameManagerScript gameManager;
    

    private void Start()
    {
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!Player.shielded)
        {
            if (collision.gameObject.CompareTag("Playerr"))
            {
                gameManager.GameOver(); // Call the GameOver method from GameManagerScript
            }
        }
        else
        {
            Player.shielded = false; // Disable shield if player is shielded
        }

    }

}
