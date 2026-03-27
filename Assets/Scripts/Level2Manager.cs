using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Level2Manager : MonoBehaviour
{
    public int totalObjects = 16;
    public int destroyedObjects = 0;

    public float timeRemaining = 150f; // 2 min 30 sec
    private bool gameFinished = false;

    public TextMeshProUGUI missionText;
    public TextMeshProUGUI timerText;

    public string winSceneName = "Menu";
    public string gameOverSceneName = "Game Over";

    void Start()
    {
        UpdateMissionText();
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

    public void AddDestroyedObject()
    {
        if (gameFinished) return;

        destroyedObjects++;
        UpdateMissionText();

        if (destroyedObjects >= totalObjects)
        {
            gameFinished = true;
            SceneManager.LoadScene(winSceneName);
        }
    }

    void UpdateMissionText()
    {
        if (missionText != null)
        {
            missionText.text = destroyedObjects + " / " + totalObjects;
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