using System;
using UnityEngine;
using TMPro;

public class PlayerStats : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI hpText;
    public static Action dead;
    private int hp = 5;
    
    void Start()
    {
        hpText.text = $"HP: {hp}";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnEnable()
    {
        Laser.damage += TakeDamage;
        CheckpointTrigger.heal += Heal;
    }

    private void OnDisable()
    {
        Laser.damage -= TakeDamage;
        CheckpointTrigger.heal -= Heal;
    }

    private void TakeDamage()
    {
        hp--;
        hpText.text = $"HP: {hp}";
        if (hp <= 0)
        {
            dead?.Invoke();
        }
    }

    private void Heal()
    {
        hp++;
        hpText.text = $"HP: {hp}";
    }
}   

