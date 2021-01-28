using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveScript : MonoBehaviour
{
    public Rigidbody rb;
    public Text weightText;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        NewPlayerMovement player = FindObjectOfType<NewPlayerMovement>();

        if(player.strength > 1)
        {
            rb.isKinematic = false;
        }
        else
        {
            rb.isKinematic = true;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        NewPlayerMovement player = FindObjectOfType<NewPlayerMovement>();

        if (player.strength < 1)
        {
            rb.isKinematic = true;

            if (other.gameObject.tag == "Player")
            {
                weightText.gameObject.SetActive(true);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        weightText.gameObject.SetActive(false);
    }
}
