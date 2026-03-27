using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Level1Manager : MonoBehaviour
{
    public int totalObstacles = 15;
    public int destroyedObstacles = 0;

    public float timeRemaining = 240f; // 4 minutes
    private bool gameFinished = false;

    public TextMeshProUGUI obstacleText;
    public TextMeshProUGUI timerText;

    public string nextSceneName = "02. Boss";
    public string gameOverSceneName = "Game Over";

    void Start()
    {
        UpdateObstacleText();
        UpdateTimerText();
    }

    void Update()
    {
        if (gameFinished) return;

        timeRemaining -= Time.deltaTime;

        if (timeRemaining <= 0f)
        {
            timeRemaining = 0f;
            UpdateTimerText();
            GameOver();
            return;
        }

        UpdateTimerText();
    }

    public void AddDestroyedObstacle()
    {
        if (gameFinished) return;

        destroyedObstacles++;
        UpdateObstacleText();

        if (destroyedObstacles >= totalObstacles)
        {
            gameFinished = true;
            SceneManager.LoadScene(nextSceneName);
        }
    }

    void UpdateObstacleText()
    {
        if (obstacleText != null)
        {
            obstacleText.text = destroyedObstacles + " / " + totalObstacles;
        }
    }

    void UpdateTimerText()
    {
        if (timerText != null)
        {
            int minutes = Mathf.FloorToInt(timeRemaining / 60f);
            int seconds = Mathf.FloorToInt(timeRemaining % 60f);
            timerText.text = minutes.ToString("00") + ":" + seconds.ToString("00");
        }
    }

    void GameOver()
    {
        gameFinished = true;
        SceneManager.LoadScene(gameOverSceneName);
    }
}