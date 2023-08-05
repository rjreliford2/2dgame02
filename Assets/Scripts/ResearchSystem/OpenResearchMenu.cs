using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpenResearchMenu : MonoBehaviour
{
    public Button button;
    // Start is called before the first frame update
    void Start()
    {
        button.onClick.AddListener(openResearch);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void openResearch()
    {
        SceneLoader.loaderActual.toResearch();
    }
}
