using UnityEngine;

public class Coin : Pickup
{
    ScoreManager scoreManager;
    public void Init(ScoreManager scoreManager)
    {
        this.scoreManager = scoreManager;
    }
    protected override void OnPickup()
    {
        scoreManager.increaseScorePoints(100);
    }
}
