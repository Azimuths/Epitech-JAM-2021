using UnityEngine;

public class Parallax : MonoBehaviour
{
    public Transform cam;
    public float move = 0.5f;
    public Transform background;
    
    void Update()
    {
        transform.position = new Vector2(cam.position.x * move, cam.position.y * move + background.transform.position.y);
    }
}
