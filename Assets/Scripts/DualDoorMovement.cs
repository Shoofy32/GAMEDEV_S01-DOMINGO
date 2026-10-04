using Unity.VisualScripting;
using UnityEngine;

public class DualDoorMovement : MonoBehaviour
{
    [SerializeField]
    GameObject rDoor;

    [SerializeField]
    GameObject lDoor;

    bool gameStart = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gameStart)
        {
            rDoor.transform.position += new Vector3(0.01f, 0, 0);
            lDoor.transform.position += new Vector3(-0.01f, 0, 0);
        }
    }

    public void OnEnable()
    {
        CheckpointTrigger.StartCountdown += OpenDoors;
    }

    public void OpenDoors()
    {
        gameStart = true;
    }

    
}
