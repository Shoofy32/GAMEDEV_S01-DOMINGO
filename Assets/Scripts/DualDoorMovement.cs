using Unity.VisualScripting;
using UnityEngine;

public class DualDoorMovement : MonoBehaviour
{
    [SerializeField]
    GameObject rDoor;

    [SerializeField]
    GameObject lDoor;

    [SerializeField]
    GameObject plate;
    bool gameStart = false;
    Vector3 platePosition;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        platePosition = plate.transform.position;
    }

    // Update is called once per frame
    void Update()
    {   
        if (plate.transform.position.y < platePosition.y && plate.GetComponent<MeshRenderer>().enabled == true)
        {
            gameStart = true;
        }

        if (gameStart && plate.GetComponent<MeshRenderer>().enabled == true)
        {
            rDoor.transform.position += rDoor.transform.right * Time.deltaTime *5f;
            lDoor.transform.position += lDoor.transform.right * Time.deltaTime *5f;
        }
    }
    
}
