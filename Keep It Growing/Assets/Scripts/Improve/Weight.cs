using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Weight : MonoBehaviour
{
    public float strength;
    public Text strengthtext;
    private void OnTriggerStay(Collider other)
    {

        if (other.gameObject.tag == "Player")
        {
            NewPlayerMovement player = FindObjectOfType<NewPlayerMovement>();
            Debug.Log("Stayed at Weight");

            if (Input.GetKeyDown("w") || Input.GetKey("w"))
            {
                SpeedRound();
                StartCoroutine(SpeedImprove());
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Left Weight");
        }
    }

    public void SpeedRound()
    {
        NewPlayerMovement player = FindObjectOfType<NewPlayerMovement>();

        strength = (float)System.Math.Round(player.strength);

        if(strength > player.strength)
        {
            player.strength = strength;
        }
    }

    IEnumerator SpeedImprove()
    {
        NewPlayerMovement player = FindObjectOfType<NewPlayerMovement>();
        while (true)
        {
            strengthtext.text = "Strength - " + strength;

            Debug.Log("Pushing Weight");
            player.strength += (float)0.001;
            yield break;
        }
    }
}
