using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleManager : MonoBehaviour
{
    public GameObject player;
    public GameObject tile;
    public List<GameObject> obstaclesList = new List<GameObject>();
    float spawningDelay;

    // Start is called before the first frame update
    void Start()
    {
        spawningDelay = 1;
        StartCoroutine("SpawnObstacles");
    }

    void SpawnObstacle()
    {
        int randomObstacleIndex;
        while (true)
        {
            randomObstacleIndex = Random.Range(0, obstaclesList.Count);
            if (player.transform.position.z - 10 >= obstaclesList[randomObstacleIndex].transform.position.z)
            {
                break;
            }
        }

        int randomXposition = Random.Range(-(int)tile.transform.localScale.x/2 + 4, (int)tile.transform.localScale.x / 2 + 1 - 2);
        int randomZposition = (int)player.transform.position.z + 40;
        obstaclesList[randomObstacleIndex].transform.position = new Vector3(randomXposition, 1, randomZposition);
    }


    IEnumerator SpawnObstacles()
    {
        while(true)
        {
            SpawnObstacle();
            yield return new WaitForSeconds(spawningDelay);
        }
    }


    public void setSpawningDelay()
    {
        if(spawningDelay >= 0.5)
        {
            spawningDelay -= 0.1f;
        }
    }

}
