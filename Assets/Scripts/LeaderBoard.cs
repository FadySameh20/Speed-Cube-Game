using UnityEngine.SceneManagement;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LeaderBoard : MonoBehaviour
{
    public Text gainedScore;
    public List<Text> topScores = new List<Text> ();

    private void Start()
    {
        gainedScore.text = Score.score.ToString();
        for(int i = 0; i < GameManager.top10Scores.Count; i++)
        {
            topScores[i].text = (i+1).ToString() + ") " + GameManager.top10Scores[i].ToString();
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene(1);
    }

}
