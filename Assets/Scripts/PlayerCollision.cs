using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public PlayerMovement movement;
    bool isCollided = false;

    void OnCollisionEnter(Collision collisionInfo) {
        if(collisionInfo.collider.tag == "Obstacle") {
            isCollided = true;
            movement.enabled = false;
            FindObjectOfType<GameManager>().EndGame();
        }
    }

    public bool collision()
    {
        return isCollided;
    }

}
