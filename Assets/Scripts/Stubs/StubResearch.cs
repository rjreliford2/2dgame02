using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StubResearch : MonoBehaviour
{
    public Button button;
    // Start is called before the first frame update
    void Start()
    {
        button.onClick.AddListener(ree);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ree()
    {
        Debug.Log("you spended some RP to research a thingie");
    }
}
