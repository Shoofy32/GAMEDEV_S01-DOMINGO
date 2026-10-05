using System;
using UnityEngine;

public class CheckpointTrigger : MonoBehaviour
{
    public static Action StartCountdown;
    public static Action Stop;
    public static Action finale;
    public static Action heal;
    public static Action trap;
    public static Action trap2;
    public static Action trap3;
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

        if (other.gameObject.CompareTag("Player") && CompareTag("Heal"))
        {
            heal?.Invoke();
        }

        if (other.gameObject.CompareTag("Player") && CompareTag("trap1"))
        {
            trap?.Invoke();
        }

        if (other.gameObject.CompareTag("Player") && CompareTag("trap2"))
        {
            trap2?.Invoke();
        }

        if (other.gameObject.CompareTag("Player") && CompareTag("trap3"))
        {
            trap3?.Invoke();
        }
    
        if (other.gameObject.CompareTag("HorizontalDown") && CompareTag("VerticalUp"))
        {
            DestroyImmediate(other.gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        transform.position = new Vector3(transform.position.x, transform.position.y + 0.1f, transform.position.z);
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && CompareTag("Rotator"))
        {
            finale?.Invoke();
        }
    }

}
