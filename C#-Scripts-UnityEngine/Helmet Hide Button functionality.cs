using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelmetController : MonoBehaviour
{
    public GameObject helmet; // Reference to the helmet object in your scene

    public void ShowHelmet()
    {
        if (helmet != null)
        {
            helmet.SetActive(true); // Show the helmet by enabling its GameObject
        }
    }

    public void HideHelmet()
    {
        if (helmet != null)
        {
            helmet.SetActive(false); // Hide the helmet by disabling its GameObject
        }
    }
}
