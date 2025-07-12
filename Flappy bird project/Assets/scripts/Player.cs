
using System;
using UnityEngine;

public class Player : MonoBehaviour
{

    private SpriteRenderer SpriteRenderer;
    private Rigidbody2D rb;
    private bool Jump = false;
    private int SpriteIndex;
    public float jumpForce = 5f;

    public Sprite[] Sprites;



    //starts before anything, sets the components to its variables 
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        SpriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        InvokeRepeating(nameof(AnimateSprite), 0.15f, 0.15f);
    }

    void Update()
    {
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

    private void AnimateSprite()
    {
        SpriteIndex++;
        if (SpriteIndex >= Sprites.Length)
        {
            SpriteIndex = 0;
        }

        SpriteRenderer.sprite = Sprites[SpriteIndex];
    }
}




 

