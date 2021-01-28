using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TreadmillScript : MonoBehaviour
{
    public Text speedtext;
    public Text staminatext;

    public Text leaveText;

    public float speed;
    public float stamina;

    private void OnTriggerStay(Collider other)
    {
        Vector3 runpos = new Vector3((float)0.07099853, (float)1.64, (float)5.582119);
        Vector3 exitrunpos = new Vector3((float)-0.5538632, (float)1.498459, (float)4.091729);

        if (other.gameObject.tag == "Player")
        {
            GameObject leavetext = GameObject.Find("Canvas");
            leavetext.transform.GetChild(0).gameObject.SetActive(true);

            NewPlayerMovement player = FindObjectOfType<NewPlayerMovement>();
            Debug.Log("Stayed On Treadmill");

            if(Input.GetKeyDown("w") || Input.GetKey("w"))
            {
                player.transform.position = runpos;
                SpeedRound();
                StartCoroutine(SpeedImprove());
            }

            if(Input.GetKeyDown("q"))
            {
                player.transform.position = exitrunpos;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Left Treadmill");

            GameObject leavetext = GameObject.Find("Canvas");
            leavetext.transform.GetChild(0).gameObject.SetActive(false);
        }
    }

    public void SpeedRound()
    {
        NewPlayerMovement player = FindObjectOfType<NewPlayerMovement>();

        speed = (float)System.Math.Round(player.runSpeed);
        stamina = (float)System.Math.Round(player.staminaDepleteTime);

        if(stamina > player.staminaDepleteTime)
        {
            player.staminaDepleteTime = stamina;
        }

        if (speed > player.runSpeed)
        {
            player.runSpeed = speed;
        }
    }

    IEnumerator SpeedImprove()
    {
        NewPlayerMovement player = FindObjectOfType<NewPlayerMovement>();
        while (true)
        {
            speedtext.text = "Speed - " + speed;
            staminatext.text = "Stamina - " + stamina;

            Debug.Log("Running On Treadmill");
            player.runSpeed += (float)0.001;
            player.staminaDepleteTime += (float)0.001;
            yield break;
        }
    }
}
