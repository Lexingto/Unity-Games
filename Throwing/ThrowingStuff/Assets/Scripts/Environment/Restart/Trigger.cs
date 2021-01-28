using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Trigger : MonoBehaviour
{
    private void OnTriggerStay(Collider other)
    {
        GameObject text = GameObject.Find("Canvas");
        text.transform.GetChild(0).gameObject.SetActive(true);
        if (Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene(0);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        GameObject text = GameObject.Find("Canvas");
        text.transform.GetChild(0).gameObject.SetActive(false);
    }
}
