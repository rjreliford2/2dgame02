using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DisplayTickRate : MonoBehaviour
{
    public TextMeshProUGUI text;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        text.text = "Tick Rate: " + TickManager.tickRate;
    }
}
