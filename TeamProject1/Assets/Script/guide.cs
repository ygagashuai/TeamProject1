using System;
using TMPro;
using UnityEngine;

public class guide : MonoBehaviour
{
    public TextMeshProUGUI text;
    private float timer = 0.0f;
    private float waitTime = 3.0f;
    private bool startTimer;
    private string[] textOptions = {"Press G", "Press K"};
    
    private void OnTriggerEnter2D(Collider2D other)
    {
       if (other.CompareTag("Player"))
        {
            text.text = "Press G";
            startTimer = true;
        } else if (other.CompareTag("ShootAbility"))
        {
            text.text = "Press J";
            startTimer = true;
        }

    }

    private void Update()
    {
        if (startTimer == true)
        {
            TimerLogic();
        }
    }
    void TimerLogic()
    {
        timer += Time.deltaTime;
        
        if (timer > waitTime)
        {
            text.text = "";
        }
    }
}
