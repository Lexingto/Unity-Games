using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndTimerPlatform : MonoBehaviour
{
    public GameObject Lvl3Wall;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            TimerPlatform timer = FindObjectOfType<TimerPlatform>();
            timer.StopTimer = true;

            Lvl3Wall.gameObject.SetActive(false);
        }
    }
}
