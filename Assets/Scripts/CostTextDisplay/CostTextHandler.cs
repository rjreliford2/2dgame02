using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class CostTextHandler : MonoBehaviour, IOrderable
{
    //singleton reference to the error handler
    //BE SURE THERE ISN'T MORE THAN ONE IN SCENE
    public static CostTextHandler costHandler;

    //text to set
    public TextMeshProUGUI text;
    
    //attached child button, used to confirm an action
    public GameObject confirmButton;

    public ConfirmButton confirmScript;

    private void Start()
    {
        OrderingManager.managerActual.addToStartQueue(this, 6);
    }

    // set singleton reference on start
    public void onStart()
    {
        CostTextHandler.costHandler = this;
        confirmButton.SetActive(false);
    }
    
    //sets the handler's text manually
    public void setText(string toSet)
    {
        confirmButton.SetActive(false);
        text.text = toSet;
    }

    //appends text to the manager manually
    public void addText(string toAdd)
    {
        text.text += toAdd;
    }

    //sets the error text based on the passed resource requirements
    public void setErrorText(List<string> requiredResourceTypes, List<float> requiredResourceCounts)
    {
        confirmButton.SetActive(false);
        text.text = "Resource Requirements Not Met!\nRequired Resources:\n";
        for(int i = 0; i<requiredResourceTypes.Count; i++)
        {
            text.text += (int) requiredResourceCounts[i] + " " + requiredResourceTypes[i];
            ResourceManager manager = ReferenceResourceByType.getManagerOfType(requiredResourceTypes[i]);
            int dif = (int) requiredResourceCounts[i] - (int) manager.getTotal();
            if (dif > 0)
            {
                text.text += " (Need " + dif + " More)";
            }
            text.text += "\n";
        }
    }
    
    //sets the confirmation text based on the passed resource requirements and activates the confirm button
    public void setConfirmationText(List<string> requiredResourceTypes, List<float> requiredResourceCounts, IConfirmable confirmable)
    {
        text.text = "Required Resources:\n";
        for(int i = 0; i<requiredResourceTypes.Count; i++)
        {
            text.text += (int) requiredResourceCounts[i] + " " + requiredResourceTypes[i]+"\n";
        }
        confirmButton.SetActive(true);
        confirmScript.setConfirmable(confirmable);
    }
}
