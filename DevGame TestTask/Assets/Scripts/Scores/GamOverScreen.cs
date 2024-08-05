using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{
    public Text scoreText;
  
    public GameObject newHighScoreMessage;

    void Start()
    {
        int finalScore = ScoreManager.instance.currentScore;
        int highScore = ScoreManager.instance.highScore;

        scoreText.text = "Score: " + finalScore.ToString();

        if (finalScore == highScore)
        {
            newHighScoreMessage.SetActive(true);
        }
        else
        {
            newHighScoreMessage.SetActive(false);
        }

        ScoreManager.instance.ResetScore();
    }
    public void RestartButton()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(1);
    }
    public void MenuButton()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }
    
}
