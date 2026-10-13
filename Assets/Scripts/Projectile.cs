using System.Collections;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public Ammo Ammo { get; set; }
    
    private void Update()
    {
        if(Physics.Raycast(new Ray(transform.position, transform.forward), out RaycastHit hit, Ammo.speed * Time.deltaTime))
        {
            transform.position = hit.point;
            GetComponent<MeshRenderer>().enabled = false; 
            Destroy(gameObject, 1f);
            Destroy(this);
        }
        else
        {
            transform.Translate(Vector3.forward * Ammo.speed * Time.deltaTime);
        }
    }
}
