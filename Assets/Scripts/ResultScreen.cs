using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; 

public class ResultScreen : MonoBehaviour
{
    public void Open()
    {
        Time.timeScale = 0f;
        gameObject.SetActive(true);                 // show score and quit button
    }

    public void Close()
    {
        gameObject.SetActive(false);
    }

}
