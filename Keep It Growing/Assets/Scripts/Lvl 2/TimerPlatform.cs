using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerPlatform : MonoBehaviour
{
    public Text timertext;

    public bool hit = false;
    public bool StopTimer = false;
    // Start is called before the first frame update

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player" && hit == false)
        {
            hit = true;

            timertext.text = "30";
            timertext.gameObject.SetActive(true);

            StartCoroutine(Timer());
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(int.Parse(timertext.text) == 0)
        {
            timertext.text = "TIMER END";
            Debug.Log("Timer hit 0");
        }

        if(StopTimer == true)
        {

            Debug.Log("Hit End Plat");
        }
    }

    IEnumerator Timer()
    {
        while (true)
        {
            if (int.Parse(timertext.text) != 0)
            {
                timertext.text = (int.Parse(timertext.text) - 1).ToString();
                yield return new WaitForSeconds(1);
            }
            else
            {
                hit = false;
                timertext.gameObject.SetActive(false);
                yield break;
            }

            if(StopTimer == true)
            {
                timertext.text = "Hit End Platform";
                yield return new WaitForSeconds(2);

                timertext.gameObject.SetActive(false);

                yield break;
            }
        }
    }
}
