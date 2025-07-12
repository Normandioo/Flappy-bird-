using UnityEngine;

public class GameManager : MonoBehaviour
{
    private int Score;

    public void GameOver()
    {
        Debug.Log("Game Over");
    }

    public void IncreaseScore()
    {
        Score++;
    } 
}
