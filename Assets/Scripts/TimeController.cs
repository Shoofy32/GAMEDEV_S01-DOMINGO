using UnityEngine;
using System;
using TMPro;
using System.Collections;


public class TimeController : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI TimerText;

    private float countdownDuration = 30f;
    public static Action laserSpawn;
    public static Action timeOut;
    public static Action laserWallSpawn;
    public static Action timeStart;

    public void OnEnable()
    {
        CheckpointTrigger.StartCountdown += StartCountdownTimer;
        CheckpointTrigger.Stop += StopCountdownTimer;
    }
    public void OnDisable()
    {
        CheckpointTrigger.StartCountdown -= StartCountdownTimer;
        CheckpointTrigger.Stop -= StopCountdownTimer;
    }
    IEnumerator StartTimer()
    {
        float timeRemaining = countdownDuration;

        while (timeRemaining > 0)
        {
            timeRemaining -= 1;
            TimerText.text = $"{Mathf.FloorToInt(timeRemaining / 60)}:{Mathf.FloorToInt(timeRemaining % 60):D2}";
            yield return new WaitForSeconds(1f);
        }
        timeOut?.Invoke();
    }

    IEnumerator lasers()
    {
        float timeRemaining = countdownDuration;

        while (timeRemaining > 0)
        {
            timeRemaining -= 1.9f;
            laserSpawn?.Invoke();
            yield return new WaitForSeconds(2f);
        }
    }

    IEnumerator laserWall()
    {
        float timeRemaining = countdownDuration;

        while (timeRemaining > 0)
        {
            timeRemaining -= 5;
            laserWallSpawn?.Invoke();
            yield return new WaitForSeconds(5f);
        }
    }
    void StartCountdownTimer()
    {
        StartCoroutine(StartTimer());
        StartCoroutine(lasers());
        StartCoroutine(laserWall());
        timeStart?.Invoke();
    }

    void StopCountdownTimer()
    {
        StopAllCoroutines();
    }
}
