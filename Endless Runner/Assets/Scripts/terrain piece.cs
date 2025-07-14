using UnityEngine;

public class terrainpiece : MonoBehaviour
{
    private Rigidbody2D playerRigidBody;
    public float moveSpeed;
    public float moveSpeedSlow;
    private float inputHorizontal;
    private Vector2 moveToFlip;

    void Start()
    {
        playerRigidBody = GetComponent<Rigidbody2D>();

    }

    void Update()
    {
        movePlayerLateral();
    }

    private void movePlayerLateral()
    {
        inputHorizontal = Input.GetAxis("Horizontal");
        moveToFlip = new Vector2(inputHorizontal * moveSpeed * -1, playerRigidBody.velocity.y);

        //greater than needs to be slower
        if(moveToFlip.x > 0)
        {
            playerRigidBody.velocity = new Vector2(inputHorizontal * moveSpeedSlow * -1, playerRigidBody.velocity.y);
        }
        else
        {
            playerRigidBody.velocity = new Vector2(inputHorizontal * moveSpeed * -1, playerRigidBody.velocity.y);
        }

    }
}
