using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackButton : MonoBehaviour
{
    public Button button;
    // Start is called before the first frame update
    void Start()
    {
        button.onClick.AddListener(goBack);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void goBack()
    {
        SceneLoader.loaderActual.returnToBase();
    }
}
