
using System;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{


    //a variable that holds the spriteRenderer value
    private SpriteRenderer SpriteRenderer;

    //a variable that hold the rigidBody2d value
    private Rigidbody2D rb;

    //a variable that holds a bool value for the jump
    private bool Jump = false;

    //a variable that hold an int value for SpriteIndex
    private int SpriteIndex;

    //a variablue that holds a float value for jumpForce
    [SerializeField] float jumpForce = 5f;

    //an array that holds 3 sprites
    [SerializeField] Sprite[] Sprites;



    //starts before anything, sets the components to its variables 
    void Awake()
    {
        //the rb variable gets the rigidBody component from the Player gameObject
        rb = GetComponent<Rigidbody2D>();

        //the SpriteRenderer gets the SpriteRenderer component from the player gameobject
        SpriteRenderer = GetComponent<SpriteRenderer>();
    }


    //starts before anything
    private void Start()
    {
        //Repeats the method 'AnimateSprite' each 0.15 seconds and with a repeat rate of 0.15 seconds
        //PT-BR: Essa funcao faz o metodo 'AnimateSprite' repetir a cada 0.15 segundos com uma frequencia de repeticao de 0.15 segundos
        InvokeRepeating(nameof(AnimateSprite), 0.15f, 0.15f);
    }

    //Call the function when the script is enabled
    private void OnEnable()
    {   
        //the variable position receives the current transform.position from the transform component
        Vector2 position = transform.position;

        //sets the Y axis of the position variable to 0
        position.y = 0f;

        //attribute the positon variable value to the transform.position component
        transform.position = position;
    }


    //called each frame
    void Update()
    {
        //checks if the key "space" or the leftMouseButton were pressed. If its True, sets the jump variable to true
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
            Jump = true;
    }

    //just like the process function in godot
    void FixedUpdate()
    {
        if (Jump)
        {
            //sets the jump variable to false and sets the vertical velocity to 0
            Jump = false;
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, 0f);

            //add a vertical instant impulse to the rigidBody 
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }


    //method to Animate the character sprite
    private void AnimateSprite()
    {
        //sums the variable with herself +1. SprinteIndex += SpriteIndex 
        SpriteIndex++;

        //if the variable 'SpriteIndex' is equal or greater than the length of Sprites array:
        //Sets SpritesIndex to 0
        if (SpriteIndex >= Sprites.Length)
        {
            SpriteIndex = 0;
        }

        //makes the sprite of the spriteRenderer component receive the current sprite marked by the SpriteIndex inside the Sprites array
        //PT-BR faz o elemento 'sprite ' do componente 'spriteRenderer' receber o sprite que esta localizado dentro do array 'Sprites' definido pelo
        //valor do 'SpriteIndex'
        SpriteRenderer.sprite = Sprites[SpriteIndex];
    }

    //called when the rigidBody enters another Collider2D
    private void OnTriggerEnter2D(Collider2D other)
    {
        //checks if the gameObject tag is an obstacle, if its true
        if (other.gameObject.tag == "Obstacle")
        {
            //find the GameManager object and call the method GameOver inside its script
            FindFirstObjectByType<GameManager>().GameOver();
        }

        //else if the gameObject has a "Scoring" tag
        else if (other.gameObject.tag == "Scoring")
        {
            //find the GameManager object and call the method 'IncreaseScore' inside its script
            FindFirstObjectByType<GameManager>().IncreaseScore();
        }
    }
        
    


}







 

