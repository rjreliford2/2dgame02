using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BaseExpansion : MonoBehaviour, IConfirmable
{
    [Tooltip("Button to Listen to")] 
    public Button button;
    //reference to the rp resource manager
    private ResourceManager rpmanager;
    //rp cost
    private float rpcost = 450;
    
    //add the listener and initialize rpmanager
    void Start()
    {
        button.onClick.AddListener(onClick);
        rpmanager = ReferenceResourceByType.getManagerOfType("rp");
    }
    
    //confirms the research
    public void confirm()
    {
        rpmanager.changeTotal(-rpcost * (Mathf.Pow(2.0f, BuildingManager.managerActual.slotsPerType - 1)));
        BuildingManager.managerActual.slotsPerType += 1;
        PlayerPrefs.SetInt("slotsPerType", BuildingManager.managerActual.slotsPerType);
        CostTextHandler.costHandler.setText("");
        BackgroundChanger.changerActual.changeSprite(BuildingManager.managerActual.slotsPerType);
    }

    //checks the cost and displays the cost text
    void onClick()
    {
        float cost = rpcost * (Mathf.Pow(2.0f, BuildingManager.managerActual.slotsPerType - 1));
        List<string> temp1 = new List<string> { "RP" };
        List<float> temp2 = new List<float> { cost };
        if (cost < rpmanager.getTotal())
        {
            CostTextHandler.costHandler.setConfirmationText(temp1, temp2, this);
        }
        else
        {
            CostTextHandler.costHandler.setErrorText(temp1, temp2);
        }
    }
}
