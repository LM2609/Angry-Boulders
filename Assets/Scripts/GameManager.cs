using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public bool gameOver = false;

    public int score = 0;

    public TextMeshProUGUI ScoreText;

    public GameObject GameEnd;

    public TextMeshProUGUI FinalScoreText;

    public GameObject FinalScoreObject;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        FinalScoreObject.SetActive(false);
        GameEnd.SetActive(false);
        SetScoreText();
    }

    void SetScoreText()
    {
        ScoreText.text = "Score: " + score.ToString();
    }

    void SetFinalScoreText()
    {
        FinalScoreText.text = "Your Final Score Is: " + score.ToString();
    }

    public void AddScore(int points)
    {
        //check if the game is over
        if (gameOver)
            return;

        //add points
        score += points;
        SetScoreText();
    }

    public void GameOver()
    {
        //check if game is over
        if (gameOver)
            return;

        //end game
        gameOver = true;

        //display end of game message and final score
        GameEnd.SetActive(true);
        
        SetFinalScoreText();
        FinalScoreObject.SetActive(true);
    }
}