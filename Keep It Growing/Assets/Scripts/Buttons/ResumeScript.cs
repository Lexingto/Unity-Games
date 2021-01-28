using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResumeScript : MonoBehaviour
{
    public void OnClick()
    {
        NewPlayerMovement player = FindObjectOfType<NewPlayerMovement>();
        player.resume = true;
    }
}
