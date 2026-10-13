using System.Collections;
using UnityEngine;

[CreateAssetMenu]
public class Ammo : ScriptableObject
{
    [Range(25, 100)]
    public float speed = 50f;


}
