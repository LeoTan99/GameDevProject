using UnityEngine;

public class GoalMoving : MonoBehaviour
{
    public float speed = 2f;
    public float distance = 4f;
    private float initialZ;

    // Start is called before the first frame update
    void Start()
    {
        initialZ = transform.position.z;
    }

    // Update is called once per frame
    void Update()
    {
        float newPositionZ = initialZ + Mathf.Sin(Time.time * speed) * distance;
        transform.position = new Vector3(transform.position.x, transform.position.y, newPositionZ);
    }
}
