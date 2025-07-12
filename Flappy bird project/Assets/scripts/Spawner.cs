using UnityEngine;

public class Spawner : MonoBehaviour
{
    //references the prefab as a gameObject
    public GameObject prefab;

    //variable that determines the spawn rate
    [SerializeField] float spawnRate = 1f;

    //variable that determines the minHeight to spawn the pipes pivot
    [SerializeField] float minHeight = -1f;

    //variable that determines the maxHeight to spawn the pipes pivot
    [SerializeField] float maxHeight = 1f;


//When the script is enabled
    private void OnEnable()
    {
        //Begins to, repeatedly, call the Spawn method by giving its rate in seconds 
        InvokeRepeating(nameof(Spawn), spawnRate, spawnRate);
    }
//When the script is disabled
    void OnDisable()
    {
        //Stops the repeat
        CancelInvoke(nameof(Spawn));   
    }

    //the method that spawn the pipes
    private void Spawn()
    {
        //The gameObject pipes are instantiated 
        GameObject pipes = Instantiate(prefab, transform.position, Quaternion.identity);

        //then a random height is defined 
        pipes.transform.position += Vector3.up * Random.Range(minHeight, maxHeight);
    }




}
