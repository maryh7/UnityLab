using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Score : MonoBehaviour
{
    [SerializeField] public static int score = 0;
    [SerializeField] public Text scoreTxt;
    [SerializeField] public Text sceneTxt;
    [SerializeField] int level;
    string playerName;

    const int DEFAULT_POINTS = 2;
    const int REDUCED_POINTS = 1;
    private static float scoreThreshold = 3;
    static int tempScore = 0;

    // Start is called before the first frame update
    void Start()
    {
        level = SceneManager.GetActiveScene().buildIndex;
        //playerName = PersistentData.Instance.GetName();
        //score = PersistentData.Instance.GetScore();
        sceneTxt.text = "Level: " + (level);
        scoreTxt.text = "Score: " + score;
        
    }

    // Update is called once per frame
    void Update()
    {
        scoreTxt.text = "Score: " + score;

    }

    public static void AddPoints(int points)
    {
        score += points;
        tempScore += points;
        PersistentData.Instance.SetScore(score);

        if (score >= scoreThreshold)
        {
            AdvanceLevel();
            scoreThreshold += 4;
            tempScore = 0;
        }

    }

    public static void AddPoints()
    {
            
        if (JellyMovement.xy.x <= 1.5f)
        {
            AddPoints(DEFAULT_POINTS);  
        }
        else
        {
            AddPoints(REDUCED_POINTS);
        }
       
    } 

    public static void AdvanceLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public static void Reset()
    {
        score = 0;
        scoreThreshold = 3;
    }

    public static void ResetScore()
    {
        score -= tempScore;
        tempScore = 0;
    }
}
