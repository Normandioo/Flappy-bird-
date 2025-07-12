using UnityEngine;

public class PipesMovement : MonoBehaviour
{

//Variable that determines the movement speed
    [SerializeField] float speed = 5f;

//Variable that determines the position where the prefab pipes will be destroyed
    private float leftEdge;

//When the script starts the variable leftEdge receives a position outside of the camera viewport
    
    void Start()
    {
        leftEdge = Camera.main.ScreenToWorldPoint(Vector3.zero).x - 1f;
    }


//updates each frame
    private void Update()
    {
        //moves the pipes to the left by changing its transform position sums the result of vector3.left * the speed variable * deltatime
        transform.position += Vector3.left * speed * Time.deltaTime;

        //if the transform.position in X is greater than the position of the leftEdge variable
        if (transform.position.x < leftEdge)
        {
            // the object is destroyed
            Destroy(gameObject);
        }
    }
}
