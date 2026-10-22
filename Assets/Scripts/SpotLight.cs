using System;
using UnityEngine;

public class Spotlight : MonoBehaviour
{
    public static Action playerSpotted;
    private void FixedUpdate()
    {
        if (Physics.CapsuleCast(transform.position, new Vector3(transform.position.x, transform.position.y - 10, transform.position.z),2.5f,transform.up*-1, out RaycastHit hit))
        {
            if (hit.collider.CompareTag("Player"))
            {
                Debug.Log("Player Detected");
                playerSpotted?.Invoke();
            }
        }
    }
}