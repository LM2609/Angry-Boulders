using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public bool gameOver = false;

    public int score = 0;

    private void Awake()
    {
        Instance = this;
    }

    public void AddScore(int points)
    {
        // Stop scoring if the game has ended
        if (gameOver)
            return;

        score += points;
    }

    public void GameOver()
    {
        if (gameOver)
            return;

        gameOver = true;

        Debug.Log("GAME OVER! The king has fallen!");
        Debug.Log("Final Score: " + score);
    }
}