using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Trampoline : MonoBehaviour
{
    public float jump;
    public Text jumptext;
    private void OnTriggerEnter(Collider other)
    {
        NewPlayerMovement player = FindObjectOfType<NewPlayerMovement>();

        if (other.gameObject.tag == "Player")
        {
            if (Input.GetButtonDown("Jump") || Input.GetButton("Jump"))
            {
                Debug.Log("jump = player tag");
                player.rb.AddForce(new Vector3(0, 20, 0), ForceMode.Impulse);
            }
        }

        if (other.gameObject.tag != "Player")
        {
            Debug.Log("jump != player tag");
            other.attachedRigidbody.AddForce(new Vector3(0, 20, 0), ForceMode.Impulse);
        }

        if(other.gameObject.tag == "Player")
        {
            Debug.Log("Collided");

            player.jumpForce += (float)0.1;

            jump = (float)System.Math.Round(player.jumpForce);

            if (jump > player.jumpForce)
            {
                player.jumpForce = jump;
            }

            jumptext.text = "Jump - " + jump;
        }
    }
}
