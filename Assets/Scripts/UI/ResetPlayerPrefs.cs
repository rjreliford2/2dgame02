using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResetPlayerPrefs : MonoBehaviour
{
    [Tooltip("reference to the reset button")]
    public Button button;
    
    //add the listener
    void Start()
    {
       button.onClick.AddListener(onClick); 
    }

    //delete the playerprefs data
    void onClick()
    {
        PlayerPrefs.DeleteAll();
    }
}
