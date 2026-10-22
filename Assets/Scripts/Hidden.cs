using Unity.VisualScripting;
using UnityEngine;
using System;

public class Hidden : MonoBehaviour
{
    public static Action enabled;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GetComponent<MeshRenderer>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (GetComponent<MeshRenderer>().enabled == true)
        {
            Destroy(this);
        }
    }
}
