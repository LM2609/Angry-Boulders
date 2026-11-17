using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public bool gameOver = false;

    public int score = 0;

    public TextMeshProUGUI ScoreText;

    public GameObject GameEnd;

    public TextMeshProUGUI FinalScoreText;

    public GameObject FinalScoreObject;

    public int BoulderCount = 5;

    public GameObject Boulder4;

    public GameObject Boulder3;

    public GameObject Boulder2;

    public GameObject Boulder1;

    public GameObject LoadedObject;

    public bool loaded = true;

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

    void Update()
    {
        if (loaded == false)
        {
            LoadedObject.SetActive(false);
        }
        else
        {             
            LoadedObject.SetActive(true);
        }

        if (BoulderCount == 4)
        {
            Instance.Boulder4.SetActive(false);
        }
        if(BoulderCount == 3)
        {
            Instance.Boulder3.SetActive(false);
        }
        if(BoulderCount == 2)
        {
            Instance.Boulder2.SetActive(false);
        }
        if(BoulderCount == 1)
        {
            Instance.Boulder1.SetActive(false); 
        }
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