
using System;
using UnityEngine;

public class Player : MonoBehaviour
{

    private SpriteRenderer SpriteRenderer;
    private Rigidbody2D rb;
    private bool Jump = false;
    private int SpriteIndex;
    [SerializeField] float jumpForce = 5f;

    [SerializeField] Sprite[] Sprites;



    //starts before anything, sets the components to its variables 
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        SpriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        //Repeats the method 'AnimateSprite' each 0.15 seconds and with a repeat rate of 0.15 seconds
        //PT-BR: Essa funcao faz o metodo 'AnimateSprite' repetir a cada 0.15 segundos com uma frequencia de repeticao de 0.15 segundos
        InvokeRepeating(nameof(AnimateSprite), 0.15f, 0.15f);
    }

    void Update()
    {
        //checks if the key "space" or the leftMouseButton were pressed. If its True, sets the jump variable to true
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
            Jump = true;
    }

    void FixedUpdate()
    {
        if (Jump)
        {
            //sets the variable jump to false and sets the vertical velocity to 0
            Jump = false;
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, 0f);

            //add a vertical instant impulse to the rigidBody 
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }


//method to Animate the character sprite
    private void AnimateSprite()
    {
        //sums the variable with herself +1 SprinteIndex += SpriteIndex 
        SpriteIndex++;

        //if the variable 'SpriteIndex' is equal or greater than the length of Sprites array:
        //Sets SpritesIndex to 0
        if (SpriteIndex >= Sprites.Length)
        {
            SpriteIndex = 0;
        }

        //makes the sprite of the spriteRenderer component receive the current sprite marked by the SpriteIndex inside the Sprites array
        //PT-BR faz o elemento 'sprite ' do componente 'spriteRenderer' receber o sprite que esta localizado dentro do array 'Sprites' definido pelo
        //do 'SpriteIndex'
        SpriteRenderer.sprite = Sprites[SpriteIndex];
    }
}




 

