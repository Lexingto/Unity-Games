using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallCollider : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player" || other.gameObject.tag == "Improve")
        {
            Vector3 MainSpawn = new Vector3(0, (float)1.75, 0);

            other.transform.position = MainSpawn;
        }
    }
}
