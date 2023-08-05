using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GoToSceneByIndex : MonoBehaviour
{
    [Tooltip("reference to the back button")]
    public Button button;

    [Tooltip("build index of the scene to load")]
    public int index;

    //add the listener to the button
    void Start()
    {
        button.onClick.AddListener(onClick);
    }

    void onClick()
    {
        SceneManager.LoadScene(index);
    }
}
