using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System;

public class GameManager : MonoBehaviour
{
    bool gameOver = false;
    float restartDelay = 1f;
    string filePath, fileName;
    public static List<int> top10Scores = new List<int>();

    private void Start()
    {
        fileName = "Top Score.txt";
        filePath = Application.dataPath + "/Resources/" + fileName;
        ReadFile();
        if(SceneManager.GetActiveScene().name == "Game")
        {
            FindObjectOfType<Score>().setTopScore();
        }
    }

    public void ReadFile()
    {
        string[] scores = File.ReadAllLines(filePath);
        top10Scores = scores.Select(x => Int32.Parse(x)).ToList();
    }


    public void LevelUp()
    {
        FindObjectOfType<PlayerMovement>().IncreaseSpeed();
        FindObjectOfType<ObstacleManager>().setSpawningDelay();
    }

    public void EndGame() {
        if (gameOver == false)
        {
            if(top10Scores.Count < 10)
            {
                top10Scores.Add(int.Parse(FindObjectOfType<Score>().topScoreText.text));
            } 
            else
            {
                if(int.Parse(FindObjectOfType<Score>().scoreText.text) > top10Scores.Min())
                {
                    int minIndex = top10Scores.IndexOf(top10Scores.Min());
                    top10Scores[minIndex] = int.Parse(FindObjectOfType<Score>().scoreText.text);
                }
            }
            top10Scores.Sort();
            top10Scores.Reverse();

            string[] scores = top10Scores.Select(i => i.ToString()).ToArray();
            File.WriteAllLines(filePath, scores);
        
            gameOver = true;
            Invoke("GoToLeaderboard", restartDelay);
        }
    }

    void GoToLeaderboard() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);   
    }


}
