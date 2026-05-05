using UnityEngine;

public class CameraSwitcher : MonoBehaviour
{
    public GameObject cameraOne;
    public GameObject cameraTwo;

    void Start()
    {
        cameraOne.SetActive(true);
        cameraTwo.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            cameraOne.SetActive(!cameraOne.activeSelf);
            cameraTwo.SetActive(!cameraTwo.activeSelf);
        }
    }
}