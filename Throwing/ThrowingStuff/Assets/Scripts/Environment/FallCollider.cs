using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallCollider : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        int RNG = Random.Range(0, 7);

        other.attachedRigidbody.Sleep();

        Vector3 catc = new Vector3(RNG, 4, 0);
        other.transform.position = catc;

        other.attachedRigidbody.WakeUp();
    }
}
