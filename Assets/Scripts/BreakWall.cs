using UnityEngine;
// using TMPro; // You will need this later to update your UI!

public class BreakWall : MonoBehaviour
{
    [Header("Player Stats")]
    public int wallBreakerCharges = 4; // Starting charges based on your HTML code
    public int currentScore = 300;     // Starting score based on your HTML code

    [Header("Raycast Settings")]
    public float breakDistance = 2f;   // How close the player must be to the wall
    public Camera playerCamera;        // Drag your Main Camera here in the Inspector

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            AttemptToBreakWall();
        }
    }

    void AttemptToBreakWall()
    {
        if (wallBreakerCharges > 0 && currentScore >= 50)
        {
            Ray ray = new Ray(playerCamera.transform.position, playerCamera.transform.forward);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, breakDistance))
            {
                if (hit.collider.CompareTag("BreakableWall"))
                {
                    Destroy(hit.collider.gameObject);

                    wallBreakerCharges--;
                    currentScore -= 50;

                    Debug.Log("Wall destroyed! Charges left: " + wallBreakerCharges + " | Score: " + currentScore);

                    // TODO: Update your UI TextMeshPro elements here!
                }
                else
                {
                    Debug.Log("You can't break that object!");
                }
            }
        }
        else
        {
            Debug.Log("Not enough charges or score to break a wall.");
        }
    }
}