using UnityEngine;

public class table : MonoBehaviour
{
    Rigidbody rb;
    private static int maxClamp = 50;
    [SerializeField] private float speed = 0.000003f;
    private int clamp = maxClamp;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.MovePosition(new Vector3(rb.position.x + speed, rb.position.y, rb.position.z));
        clamp--;
        if (clamp <= maxClamp * -1)
        {
            clamp = maxClamp;
            speed *= -1;
        }
    }
}