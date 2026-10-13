using System.Collections;
using UnityEngine;


public class tableS : MonoBehaviour
{

    [SerializeField] float sideLength = 4f;
    [SerializeField] float speed = 2f;                
    [SerializeField] float waitTime = 1f;              
    [SerializeField] Vector3 axisA = Vector3.right;    
    [SerializeField] Vector3 axisB = Vector3.forward; 
    [SerializeField] bool clockwise = true;
    private bool started = false;
    private bool moving = false;
    Rigidbody rb;
    Vector3[] corners;
    int target = 1;
    float waitTimer;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.isKinematic = true;
        rb.interpolation = RigidbodyInterpolation.Interpolate;

        Vector3 a = axisA.normalized * sideLength;
        Vector3 b = axisB.normalized * sideLength;
        if (!clockwise) b = -b;

        Vector3 start = rb.position;
        corners = new Vector3[]
        {
            start,
            start + a,
            start + a + b,
            start + b
        };
    }

    public void OnEnable()
    {
        lights.on += start;
        CheckpointTrigger.Moving += isMoving;
        CheckpointTrigger.notMoving += isNotMoving;
    }
    public void OnDisable()
    {
        lights.on -= start;
        CheckpointTrigger.Moving -= isMoving;
        CheckpointTrigger.notMoving -= isNotMoving;
    }

    private void start()
    {
        started = true;
    }
    private void isMoving()
    {
        moving = true;
    }
    private void isNotMoving()
    {
        moving = false;
    }

    void FixedUpdate()
    {
        if (started && moving)
        {
            // Waiting at a corner
            if (waitTimer > 0f)
            {
                waitTimer -= Time.fixedDeltaTime;
                return;
            }

            Vector3 next = Vector3.MoveTowards(rb.position, corners[target], speed * Time.fixedDeltaTime);
            rb.MovePosition(next);

            // Arrived at the corner: start the wait and pick the next target
            if ((next - corners[target]).sqrMagnitude < 0.0001f)
            {
                target = (target + 1) % corners.Length;
                waitTimer = waitTime;
            }
        }
    }
}
