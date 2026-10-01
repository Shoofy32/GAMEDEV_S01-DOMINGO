using UnityEngine;

public class CheckpointTrigger : MonoBehaviour
{
    [SerializeField]
    GameObject obj;

    [SerializeField]
    GameObject reward;

    [SerializeField]
    GameObject rewardSpawn;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && tag =="Rotator")
        {
            obj.transform.Rotate(Vector3.right, 45f);
            
        }

        if (other.CompareTag("Player") && tag == "Finish")
        {
            Instantiate(reward, rewardSpawn.transform.position, rewardSpawn.transform.rotation);
        }

        transform.position = new Vector3(transform.position.x, transform.position.y - 0.1f, transform.position.z);

    }

    private void OnTriggerExit(Collider other)
    {
        
        transform.position = new Vector3(transform.position.x, transform.position.y + 0.1f, transform.position.z);
        
        
    }

    private void OnTriggerStay(Collider other)
    {   
        int movementSpeed = 2;

        if (other.CompareTag("Player") && tag == "VerticalUp")
        {
            obj.transform.Translate(Vector3.up * movementSpeed * Time.deltaTime);
            
        }

        if (other.CompareTag("Player") && tag == "VerticalDown")
        {
            obj.transform.Translate(Vector3.down * movementSpeed * Time.deltaTime);
            
        }

        if (other.CompareTag("Player") && tag == "HorizontalUp")
        {
            obj.transform.Translate(Vector3.right * movementSpeed * Time.deltaTime);
            
        }

        if (other.CompareTag("Player") && tag == "HorizontalDown")
        {
            obj.transform.Translate(Vector3.left * movementSpeed * Time.deltaTime);
           
        }

    }
}
