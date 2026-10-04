using System;
using UnityEngine;

public class CheckpointTrigger : MonoBehaviour
{
    public static Action StartCountdown;
    public static Action Stop;
    public static Action finale;
    public static Action heal;

    private void OnTriggerEnter(Collider other)
    {
        transform.position = new Vector3(transform.position.x, transform.position.y - 0.1f, transform.position.z);

        if (other.gameObject.CompareTag("Player") && CompareTag("Start"))
        {
            StartCountdown?.Invoke();
        }

        if (other.gameObject.CompareTag("Player") && CompareTag("Finish"))
        {
            Stop?.Invoke();
        }

        if (other.gameObject.CompareTag("Player") && CompareTag("Rotator"))
        {
            finale?.Invoke();
        }

        if (other.gameObject.CompareTag("Player") && CompareTag("Heal"))
        {
            heal?.Invoke();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        transform.position = new Vector3(transform.position.x, transform.position.y + 0.1f, transform.position.z);
    }
       
}
