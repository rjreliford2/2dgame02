using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Quit : MonoBehaviour
{
    [Tooltip("Button to listen to")]
    public Button button;
    
    //add the listener
    void Start()
    {
        button.onClick.AddListener(onClick);
    }

    //quit the game
    void onClick()
    {
        Application.Quit();
    }
}
