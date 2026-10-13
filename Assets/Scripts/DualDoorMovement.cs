using Unity.VisualScripting;
using UnityEngine;
using System;

public class DualDoorMovement : MonoBehaviour
{
    [SerializeField]
    GameObject rDoor;

    [SerializeField]
    GameObject lDoor;

    bool gameStart = false;
    private float max = 112.929f;

    public static Action startGame;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gameStart)
        {   
            rDoor.transform.rotation *= Quaternion.Euler(0f, -0.21f, 0f);
            lDoor.transform.rotation *= Quaternion.Euler(0f, 0.21f, 0f);
            if (lDoor.transform.rotation.eulerAngles.y > max)
            {
                gameStart = false;
                
                GetComponent<BoxCollider>().enabled = false;
                startGame?.Invoke();
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {   
        OpenDoors();
    }

    public void OpenDoors()
    {
        gameStart = true;
    }

    
}
