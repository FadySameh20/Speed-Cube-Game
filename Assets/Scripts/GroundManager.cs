using UnityEngine;


public class GroundManager : MonoBehaviour
{
    public GameObject player;
    public GameObject tile;

    void Update()
    {
        if (player.transform.position.z > tile.transform.position.z)
        {
            tile.transform.position = new Vector3(tile.transform.position.x, tile.transform.position.y, player.transform.position.z + 100);
            FindObjectOfType<GameManager>().LevelUp();
        }
    }
}