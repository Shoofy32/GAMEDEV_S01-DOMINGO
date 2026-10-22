using UnityEngine;
using System.Collections;
using System;

public class laserWall : MonoBehaviour
{
    public static Action phase;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    
    public void OnEnable()
    {
        CheckpointTrigger.finale += startWalls;
    }
    public void OnDisable()
    {
        CheckpointTrigger.finale -= startWalls;
    }

    IEnumerator phasing()
    {
        while (true)
        {
            phase?.Invoke();
            GetComponent<BoxCollider>().enabled = !GetComponent<BoxCollider>().enabled;
            yield return new WaitForSeconds(3f);
        }
    }

    void startWalls()
    {
        StartCoroutine(phasing());
    }
}
