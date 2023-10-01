using UnityEngine;

public class FixCamera : MonoBehaviour
{
    public Transform playerTransform;
    private Vector3 offset = new Vector3(0, 0, -10);
    public float smoothFactor = 4;

    void FixedUpdate()
    {
        Vector3 camPos = playerTransform.position + offset;
        if (camPos.x < 0)
        {
            camPos.x = 0;
        }
        if (camPos.x > 103f)
        {
            camPos.x = 103f;
        }
        Vector3 smoothPosition = Vector3.Lerp(transform.position, camPos, smoothFactor * Time.fixedDeltaTime);
        transform.position = smoothPosition;
    }
}
