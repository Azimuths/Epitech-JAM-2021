using UnityEngine;

public class DebugCam : MonoBehaviour
{
    void Update()
    {
        float xAxisValue = Input.GetAxis("Horizontal");
        float yAxisValue = Input.GetAxis("Vertical");
        transform.Translate(new Vector3(xAxisValue * 0.25f, yAxisValue * 0.25f, 0.0f));
    }
}
