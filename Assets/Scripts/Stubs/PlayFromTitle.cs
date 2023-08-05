using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayFromTitle : MonoBehaviour
{
    //
    public Button button;
    
    // Start is called before the first frame update
    void Start()
    {
        button.onClick.AddListener(goToMainScene);
    }

    void goToMainScene()
    {
        SceneManager.LoadScene(0);
    }
}
