using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] PlayerController playerController;
    [SerializeField] TMP_Text timeText;
    [SerializeField] GameObject gameOverText;
    [SerializeField] float startTime = 5f;

    float timeLeft;
    bool gameOverStatus = false;

    public bool GameOverStatus => gameOverStatus;

    void Start()
    {
        timeLeft = startTime;
    }

    void Update()
    {
        DescreaseTime();
    }

    private void DescreaseTime()
    {
        if (gameOverStatus == true) return;

        timeLeft -= Time.deltaTime;
        timeText.text = timeLeft.ToString("F1");
        if (timeLeft <= 0)
        {
            GameOver();
        }
    }

    public void IncreaseTime(float amount)
    {
        timeLeft += amount;
    }

    void GameOver()
    {
        gameOverStatus = true;
        playerController.enabled = false;
        gameOverText.SetActive(true);
        Time.timeScale = 0.1f;
        Time.fixedDeltaTime = 0.02f * Time.timeScale;
    }

}
