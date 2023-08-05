using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeResearchButton : MonoBehaviour, IConfirmable
{
    //button to listen to
    public Button button;
    
    //text corresponding to the button to listen to
    public TextMeshProUGUI text;

    //resource appropriate to the building 
    public Resource resource;
    
    //tracks the level the button upgrades to
    private int level;
    
    //stores the rpmanager for use in multiple functions
    private ResourceManager rpmanager;

    //stores the initial text in case the level changes
    private string initialText;
    
    //Add the listener, gets the appropriate level and updates text to match, gets the resource manager
    void Start()
    {
        button.onClick.AddListener(buttonClicked);
        level = UpgradeLevelManager.upgradeManager.getMaxLevel(resource)+1;
        initialText = text.text;
        text.text += " "+level;
        rpmanager = ReferenceResourceByType.getManagerOfType("rp");
    }

    //finalizes the research
    public void confirm()
    {
        rpmanager.changeTotal(-resource.baseRPCost * (Mathf.Pow(1.5f, level - 1)));
        UpgradeLevelManager.upgradeManager.increaseMaxLevel(resource);
        level += 1;
        text.text = initialText + " " + level;
        CostTextHandler.costHandler.setText("");
    }
    
    //checks the cost of the research against the current rp total and 
    //calls the cost text handler to output the result
    void buttonClicked()
    {
        float cost = resource.baseRPCost * (Mathf.Pow(1.5f, level - 1));
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
