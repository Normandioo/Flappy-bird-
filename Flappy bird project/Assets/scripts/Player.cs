
using UnityEngine;

public class Player : MonoBehaviour 
{
    private Rigidbody2D rb;
    private bool Jump = false;
    public float jumpForce = 5f;

    //starts before anything, sets the character RigidBody as the the component of 'rb' variable
    void Awake() => rb = GetComponent<Rigidbody2D>();

    void Update() {
    //checks if the key "space" or the leftMouseButton were pressed, if its True, sets the jump variable to true
    if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
            Jump = true;
}

    void FixedUpdate()
    {
        if (Jump)
        {
            //sets the jump to false and sets the vertical velocity to 0
            Jump = false;
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, 0f); 

            //add a vertical instant impulse to the rigidBody 
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }
}




 

