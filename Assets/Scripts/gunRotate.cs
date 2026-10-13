using UnityEngine;

public class gunRotate : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void LateUpdate()
    {
        // Make the gun follow the player
        transform.rotation = Camera.main.transform.rotation;

    }
}
