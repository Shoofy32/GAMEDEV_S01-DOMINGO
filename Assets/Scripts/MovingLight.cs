using UnityEngine;

public class MovingLight : MonoBehaviour
{
    [SerializeField]
    private bool isMoving = false;
    private float direction = 1.5f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (isMoving)
        {
            transform.Translate(new Vector3(0, 0, direction) * Time.deltaTime);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Wall"))
        {
            direction *= -1;
        }
    }

    private void move()
    {
        isMoving = true;
    }

    public void OnEnable()
    {
        CheckpointTrigger.move += move;
    }
    public void OnDisable()
    {
        CheckpointTrigger.move -= move;
    }
}
