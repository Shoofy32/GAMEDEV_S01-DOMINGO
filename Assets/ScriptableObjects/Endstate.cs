using UnityEngine;

public class Endstate : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] Transform horizontalPlatforms;
    [SerializeField] Transform verticalPlatforms;

    Vector3 playerStart;
    Vector3 horizontalPlatformsPosition;
    Vector3 verticalPlatformsPosition;
    Quaternion[] horizontalPlatformRotations;
    Quaternion[] verticalPlatformRotations;
    void Start()
    {
        playerStart = player.position;

        horizontalPlatformsPosition = horizontalPlatforms.transform.position;
        verticalPlatformsPosition = verticalPlatforms.transform.position;

        horizontalPlatformRotations = CachePlatformRotations(horizontalPlatforms);
        verticalPlatformRotations = CachePlatformRotations(verticalPlatforms);
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {   
        if (other.CompareTag("Player"))
        {
            CharacterController cc = player.GetComponent<CharacterController>();

            if (cc != null) cc.enabled = false;

            player.position = playerStart;

            if (cc != null) cc.enabled = true;

            horizontalPlatforms.transform.position = horizontalPlatformsPosition;
            verticalPlatforms.transform.position = verticalPlatformsPosition;

            ResetPlatformRotations(horizontalPlatforms, horizontalPlatformRotations);
            ResetPlatformRotations(verticalPlatforms, verticalPlatformRotations);
        }
        
    }

    Quaternion[] CachePlatformRotations(Transform parent)
    {
        Quaternion[] rotations = new Quaternion[parent.childCount];
        for (int i = 0; i < parent.childCount; i++)
            rotations[i] = parent.GetChild(i).localRotation;
        return rotations;
    }

    void ResetPlatformRotations(Transform parent, Quaternion[] rotations)
    {
        for (int i = 0; i < parent.childCount; i++)
            parent.GetChild(i).localRotation = rotations[i];
    }
}
