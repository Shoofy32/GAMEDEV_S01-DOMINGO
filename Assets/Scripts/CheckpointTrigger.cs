using System;
using UnityEngine;

public class CheckpointTrigger : MonoBehaviour
{
    public static Action notMoving;
    public static Action Moving;
    private void OnTriggerEnter(Collider other)
    {
        transform.position = new Vector3(transform.position.x, transform.position.y - 0.1f, transform.position.z);

        if (other.gameObject.CompareTag("Player"))
        {
            if (CompareTag("static"))
            {
                notMoving?.Invoke();
            }
            if (CompareTag("dynamic"))
            {
                Moving?.Invoke();
            }

        }
    }

    private void OnTriggerExit(Collider other)
    {
        transform.position = new Vector3(transform.position.x, transform.position.y + 0.1f, transform.position.z);
    }



}
