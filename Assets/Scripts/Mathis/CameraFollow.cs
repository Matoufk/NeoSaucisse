using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject player;
    public float timeOffset;
    public Vector3 posOffset;

    private Vector3 velocity;

    public float xOffSet;
    private void Start()
    {
        transform.rotation = Quaternion.Euler(xOffSet, 0, 0);
    }
    void FixedUpdate()
    {
        //transform.rotation = Quaternion.Euler(xOffSet, 0, 0);
        transform.position = Vector3.SmoothDamp(transform.position, player.transform.position + posOffset, ref velocity, timeOffset);
    }
}