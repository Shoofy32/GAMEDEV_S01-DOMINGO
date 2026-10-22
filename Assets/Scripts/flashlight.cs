using UnityEngine;

public class flashlight : MonoBehaviour
{
    void Start()
    {
        GetComponent<Light>().enabled = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            GetComponent<Light>().enabled = !GetComponent<Light>().enabled;
        }

        
    }
    private void FixedUpdate()
    {
        if (Physics.Raycast(transform.position, transform.forward, out RaycastHit hit, 10f) && GetComponent<Light>().enabled)
        {
            hit.collider.GetComponent<MeshRenderer>().enabled = true;
        }
    }
}