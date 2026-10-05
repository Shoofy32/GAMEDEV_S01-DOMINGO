using System;
using System.Collections;
using UnityEngine;

public class Laser : MonoBehaviour
{
    public static Action damage;

    float superChargeSpeed = 1;
    bool startLeon = false;

    void Update()
    {
        if (CompareTag("Start") && startLeon)
        {
            transform.Translate(new Vector3(0, 0, -2 * superChargeSpeed) * Time.deltaTime);
        }
        else if (CompareTag("HorizontalDown"))
        {
            transform.Translate(new Vector3(0, 0, -10 * superChargeSpeed) * Time.deltaTime);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            damage?.Invoke();
        }
    }

    public void OnEnable()
    {
        GameManager.gameStart += gameStart;
        CheckpointTrigger.finale += superCharge;
        CheckpointTrigger.Stop += end;
    }

    public void OnDisable()
    {
        GameManager.gameStart -= gameStart;
        CheckpointTrigger.finale -= superCharge;
        CheckpointTrigger.Stop -= end;
    }

    private void superCharge()
    {
        superChargeSpeed = 3f;
    }

    private void end()
    {
        superChargeSpeed = 0;
    }

    private void gameStart()
    {
        startLeon = true;
    }
}
