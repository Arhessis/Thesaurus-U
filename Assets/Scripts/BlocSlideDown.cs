using UnityEngine;
using System.Collections;

public class BlocSlideDown : MonoBehaviour
{
    public Vector3 targetPosition; 
    public float speed = 2.0f;
    public float delaySeconds = 3.0f;

    private bool canMove = false;

    void Start()
    {
        StartCoroutine(WaitAndMove());
    }

    void Update()
    {
        if (canMove)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
        }
    }

    IEnumerator WaitAndMove()
    {
        yield return new WaitForSeconds(delaySeconds);
        canMove = true;
    }
}
