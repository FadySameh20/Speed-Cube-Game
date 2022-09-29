using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody rb;
    float forwardForce = 2000f;
    float sidewaysForce = 50f;

    // FixedUpdate() is called when changing physics characteristics of an object
    void FixedUpdate()
    {
        rb.AddForce(0, 0, forwardForce * Time.deltaTime);
        if(Input.GetKey("d")) {  // When the player presses "d" button
            rb.AddForce(sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }
        if(Input.GetKey("a")) {
            rb.AddForce(-sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }
        if(rb.position.y < -1f) {
            FindObjectOfType<GameManager>().EndGame();
        }
    }

    public void IncreaseSpeed()
    {
        forwardForce = forwardForce + 500;
    }

}
