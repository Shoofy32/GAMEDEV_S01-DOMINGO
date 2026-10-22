using UnityEngine;

public class phase : MonoBehaviour
{

    // Update is called once per frame
    void OnEnable()
    {
        laserWall.phase += toggle;
    }
    void OnDisable()
    {
        laserWall.phase -= toggle;
    }

    void toggle()
    {
        GetComponent<MeshRenderer>().enabled = !GetComponent<MeshRenderer>().enabled;
        GetComponent<MeshCollider>().enabled = !GetComponent<MeshCollider>().enabled;
    }
}
