using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerCreateFloor : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        FloorCreate Create = FindObjectOfType<FloorCreate>();

        if (other.tag == "Player")
        {
            Debug.Log("Hit CreateFloor");
            Create.CreateFloorTriggered();
        }
    }
}
