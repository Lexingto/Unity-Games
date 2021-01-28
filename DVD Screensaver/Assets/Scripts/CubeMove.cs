using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class CubeMove : MonoBehaviour
{

    public float pushForce = 6;
    public Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        OnCall();
    }

    public void OnCall()
    {
        int xrng = Random.Range(0,360);
        int yrng = Random.Range(0, 360);

        Debug.Log(xrng + " " + yrng);

        Vector2 force = new Vector2(xrng, yrng);

        Debug.Log(force);

        rb.AddForce(force);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Right Wall")
        {
            Debug.Log("pushLeft");
            rb.AddForce(Vector2.left * pushForce, ForceMode2D.Impulse);
        }
        else if (other.gameObject.tag == "Left Wall")
        {
            Debug.Log("pushRight");
            rb.AddForce(Vector2.right * pushForce, ForceMode2D.Impulse);
        }
        else if (other.gameObject.tag == "Top Wall")
        {
            Debug.Log("pushLeft");
            rb.AddForce(Vector2.down * pushForce, ForceMode2D.Impulse);
        }
        else if (other.gameObject.tag == "Bottom Wall")
        {
            Debug.Log("pushRight");
            rb.AddForce(Vector2.up * pushForce, ForceMode2D.Impulse);
        }
    }
}
