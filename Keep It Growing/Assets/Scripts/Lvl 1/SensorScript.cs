using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SensorScript : MonoBehaviour
{
    public GameObject Lvl2Wall;
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Weight")
        {
            Lvl2Wall.SetActive(false);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        Lvl2Wall.SetActive(true);
    }
}
