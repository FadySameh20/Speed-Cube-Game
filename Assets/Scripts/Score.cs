using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{

    public Transform player;
    public Text scoreText, topScoreText;
    public static int score;


    public void setTopScore()
    {
        if (GameManager.top10Scores.Count == 0)
        {
            topScoreText.text = "0";
        }
        else
        {
            topScoreText.text = GameManager.top10Scores[0].ToString();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(player.transform.position.y >= 0.5)
        {
            if(FindObjectOfType<PlayerCollision>().collision() == false)
            {
                scoreText.text = (player.position.z + 100).ToString("0");
                score = int.Parse(scoreText.text);
                int currentScore;
                int topScore;
                int.TryParse(scoreText.text, out currentScore);
                int.TryParse(topScoreText.text, out topScore);
                if (currentScore > topScore)
                {
                    topScoreText.text = scoreText.text;
                }
            }

        }
      
    }
}
