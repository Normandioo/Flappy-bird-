using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Player player;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private GameObject playButton;
    [SerializeField] private GameObject gameOver;


    //Score variable
    private int Score;

    void Awake()
    {

        Application.targetFrameRate = 60;
        Pause();
    }

    public void Play()
    {
        Score = 0;
        scoreText.text = Score.ToString();

        playButton.SetActive(false);
        gameOver.SetActive(false);

        Time.timeScale = 1f;
        player.enabled = true;
        PipesMovement[] Pipes = FindObjectsByType<PipesMovement>(FindObjectsSortMode.None);

        for (int i = 0; i < Pipes.Length; i++)
        {
            Destroy(Pipes[i].gameObject);
        }
    }

    public void Pause()
    {
        Time.timeScale = 0f;
        player.enabled = false;
    }

    //A method that stops and kill the game once the GameOver is called from the player's script
    public void GameOver()
    {
        gameOver.SetActive(true);
        playButton.SetActive(true);

        Pause();
    }

    //A method to increase the score once the player scores
    public void IncreaseScore()
    {
        Score++;
        scoreText.text = Score.ToString();
    } 
}
