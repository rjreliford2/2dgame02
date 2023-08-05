using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TurboButton : MonoBehaviour
{
    public Button turboButton;
    public float[] speedSettings;
    private int currentSetting = 0;
    // Start is called before the first frame update
    void Start()
    {
        turboButton.onClick.AddListener(changeTickRate);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void changeTickRate()
    {
        currentSetting = (currentSetting + 1) % speedSettings.Length;
        TickManager.tickRate = speedSettings[currentSetting];
    }
}
