using UnityEngine;

public class trap : MonoBehaviour
{
    bool isActive = false;
    bool isActive2 = false;
    bool isActive3 = false;
    public void OnEnable()
    {
        CheckpointTrigger.trap += activateTrap;
        CheckpointTrigger.trap2 += activateTrap2;
        CheckpointTrigger.trap3 += activateTrap3;
    }
    public void OnDisable()
    {
        CheckpointTrigger.trap -= activateTrap;
        CheckpointTrigger.trap2 -= activateTrap2;
        CheckpointTrigger.trap3 -= activateTrap3;
    }

    // Update is called once per frame
    void Update()
    {
        if (isActive && CompareTag("TrapUp"))
        {   
            if (transform.position.y < 0.22)
            {
                transform.Translate(new Vector3(0, 5, 0) * Time.deltaTime);
            }        
        }
        if (isActive2 && CompareTag("TrapSide"))
        {
            if (transform.position.x > 7.23)
            {
                transform.Translate(new Vector3(-5, 0, 0) * Time.deltaTime);
            }
        }
        if (isActive3 && CompareTag("TrapDown"))
        {   
            if (transform.position.y > 7.15)
            {
                transform.Translate(new Vector3(0, -5, 0) * Time.deltaTime);
            }
        }
    }

    void activateTrap()
    {
        isActive = true;
    }
    void activateTrap2()
    {
        isActive2 = true;
    }
    void activateTrap3()
    {
        isActive3 = true;
    }
}
