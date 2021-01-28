using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorCreate : MonoBehaviour
{
    public GameObject itemSpread;

    // Start is called before the first frame update
    void Start()
    {
        CreateFloor();
    }

    public void CreateFloor()
    {
        var YspreadValue = Random.Range((float)-1.5, (float)1.5);

        if (YspreadValue < -1.5)
        {
            YspreadValue = 0;
        }

        if (YspreadValue > 1.5)
        {
            YspreadValue = 0;
        }

        Vector3 randPosition = new Vector3(36, YspreadValue) + transform.position;

        Debug.Log(randPosition + " " + "START randPosition");

        GameObject clone = Instantiate(itemSpread, randPosition, Quaternion.identity);
    }

    public void CreateFloorTriggered()
    {
        Vector3 add = new Vector3(8, 0);
        
        var Add = transform.position + add;

        var YspreadValue = Random.Range((float)-1.5, (float)1.5);

        var YspreadValueDoOver = Random.Range((float)-1.5, (float)1.5);

        if (YspreadValue < -1.5)
        {
            YspreadValue = 0;
        }

        if (YspreadValue > 1.5)
        {
            YspreadValue = 0;
        }

        Vector3 randPosition = new Vector3(36, YspreadValue) + Add;
        Vector3 randPosition2 = new Vector3(36, YspreadValueDoOver) + Add;

        if (randPosition.y <= -7)
        {
            randPosition.y = YspreadValueDoOver;
            GameObject clone = Instantiate(itemSpread, randPosition, Quaternion.identity);

            Debug.Log("randPosition.y <= -7");
        }

        if (randPosition2.y <= -7)
        {
            randPosition2.y = YspreadValueDoOver;
            GameObject clone = Instantiate(itemSpread, randPosition, Quaternion.identity);

            Debug.Log("randPosition2.y <= -7)");
        }
        GameObject clone2 = Instantiate(itemSpread, randPosition, Quaternion.identity);
    }
}