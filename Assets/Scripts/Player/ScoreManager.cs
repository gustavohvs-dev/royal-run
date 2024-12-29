using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] GameManager gameManager;
    [SerializeField] TMP_Text scoreText;
    [SerializeField] int scorePoints = 0;
    public void increaseScorePoints(int addPoints)
    {
        if(gameManager.GameOverStatus == true) return;

        scorePoints += addPoints;
        scoreText.SetText(scorePoints.ToString());
    }
}
