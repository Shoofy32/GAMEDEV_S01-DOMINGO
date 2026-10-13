using System;
using System.Threading.Tasks;
using UnityEngine;

public class lights : MonoBehaviour
{
    private bool isOn = false;
    public static Action on;

    // Update is called once per frame
    void Update()
    {
        GetComponent<Light>().enabled = isOn;
    }

    private void OnEnable()
    {
        DualDoorMovement.startGame += turnOn;
    }
    private void OnDisable()
    {
        DualDoorMovement.startGame -= turnOn;
    }
    public async void turnOn()
    {
        await Task.Delay(2000);
        isOn = true;
        on?.Invoke();
    }
}
