
using System;
using UnityEngine;

public class CheckpointTrigger : MonoBehaviour
{
    public static Action move;
    public static Action finale;
    private void OnTriggerEnter(Collider other)
    {
        transform.position = new Vector3(transform.position.x, transform.position.y - 0.1f, transform.position.z);

        if (other.gameObject.CompareTag("Player") && GetComponent<MeshRenderer>().enabled == true)
        {
            if (CompareTag("Rotator"))
            {
                move?.Invoke();
            }
            if (CompareTag("Finish"))
            {
                finale?.Invoke();
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        transform.position = new Vector3(transform.position.x, transform.position.y + 0.1f, transform.position.z);
    }

}
