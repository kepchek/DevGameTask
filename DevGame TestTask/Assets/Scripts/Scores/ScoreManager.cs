using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    public int currentScore = 0;
    public int highScore = 0;
    public Text ShowScore;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            SceneManager.sceneLoaded += OnSceneLoaded; // Подписка на событие загрузки сцены
        }
        else
        {
            Destroy(gameObject);
        }

        LoadScore();
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        AssignShowScore();
    }

    void Start()
    {
        AssignShowScore();
    }

    void AssignShowScore()
    {
        ShowScore = GameObject.Find("ScoreCounter")?.GetComponent<Text>();
        if (ShowScore == null)
        {
            Debug.LogError("ScoreCounter Text component is not found in the scene.");
        }
        currentScore = 0;
    }

    void Update()
    {
        if (ShowScore != null)
        {
            ShowScore.text = currentScore.ToString();
        }
    }

    public void AddScore(int amount)
    {
        currentScore += amount;
        if (currentScore > highScore)
        {
            highScore = currentScore;
            SaveScore();
        }
    }

    public void ResetScore()
    {
        currentScore = 0;
    }

    public void SaveScore()
    {
        PlayerPrefs.SetInt("HighScore", highScore);
    }

    public void LoadScore()
    {
        if (PlayerPrefs.HasKey("HighScore"))
        {
            highScore = PlayerPrefs.GetInt("HighScore");
        }
    }

    void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded; // Отписка от события загрузки сцены
    }
}
