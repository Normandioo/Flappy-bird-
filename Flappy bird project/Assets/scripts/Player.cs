
using UnityEngine;

public class Player : MonoBehaviour 
{
    private Rigidbody2D rb;
    private bool wantsJump = false;
    public float jumpForce = 5f;

    void Awake() => rb = GetComponent<Rigidbody2D>();

    void Update() {
    if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        wantsJump = true;
}

    void FixedUpdate()
    {
        if (wantsJump)
        {
            wantsJump = false;
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, 0f); // reseta Y
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }
}




 

