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
    private static int scoreThreshold = 3;

    // void Awake() 
    // {
    //     level = SceneManager.GetActiveScene().buildIndex;
    // }

    // Start is called before the first frame update
    void Start()
    {
        level = SceneManager.GetActiveScene().buildIndex;
        //playerName = PersistentData.Instance.GetName();
        //score = PersistentData.Instance.GetScore();
        sceneTxt.text = "Level: " + (level + 1);
        scoreTxt.text = "Score: " + score;
        
    }

    // Update is called once per frame
    void Update()
    {
        scoreTxt.text = "Score: " + score;

    }

    public void AddPoints(int points)
    {
        score += points;
        //PersistentData.Instance.SetScore(score);

        if (score >= scoreThreshold)
        {
            AdvanceLevel();
            scoreThreshold += 4;
        }

    }

    public void AddPoints()
    {
        AddPoints(DEFAULT_POINTS);    
       
    } 

    public void AdvanceLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
