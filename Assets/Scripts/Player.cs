using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed = 5f;   // Movement speed

    private Rigidbody2D rb;
    private float moveX;
    private float moveY;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Get raw input (-1, 0, 1)
        moveX = Input.GetAxisRaw("Horizontal");
        moveY = Input.GetAxisRaw("Vertical");

        // Normalize manually (prevent faster diagonal movement)
        float length = Mathf.Sqrt(moveX * moveX + moveY * moveY);
        if (length > 0f)
        {
            moveX /= length;
            moveY /= length;
        }
    }

    void FixedUpdate()
    {
        // Move player using manual calculations
        float newX = rb.position.x + moveX * moveSpeed * Time.fixedDeltaTime;
        float newY = rb.position.y + moveY * moveSpeed * Time.fixedDeltaTime;

        rb.MovePosition(new Vector2(newX, newY));
    }
}
