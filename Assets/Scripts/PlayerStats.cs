using System;
using UnityEngine;
using TMPro;

public class PlayerStats : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI hpText;
    public static Action dead;
    
    void Start()
    {
        hpText.text = $"Press F for Flashlight";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnEnable()
    {
        Spotlight.playerSpotted += TakeDamage;
    }

    private void OnDisable()
    {
        Spotlight.playerSpotted -= TakeDamage;
    }

    private void TakeDamage()
    {
        dead?.Invoke(); 
    }
}   

