using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public Text highScoreText;

    void Start()
    {
        highScoreText.text = "High Score: " + ScoreManager.instance.highScore.ToString();
    }

    public void PlayButton()
    {
        SceneManager.LoadScene(1);
    }

    public void ResetButton()
    {
        PlayerPrefs.DeleteKey("HighScore");
    }
}
