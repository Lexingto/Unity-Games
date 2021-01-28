using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Points2 : MonoBehaviour
{
    public Text Points;

    public static int points;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            points += 50;
            Points.text = points.ToString();
        }
    }
    public void Update()
    {
        Restart Restart = FindObjectOfType<Restart>();
        if (Restart.rest == true)
        {
            points = 0;
        }
    }
}
