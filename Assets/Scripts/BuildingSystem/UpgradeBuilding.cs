using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeBuilding : MonoBehaviour, IConfirmable
{
    //button to listen to
    public Button button;
    //the resource types it costs to upgrade this building
    private List<string> resourceTypes;
    //the resource costs to upgrade the building, matched by index to the types in resourceTypes
    private List<float> costsActual;
    //the building slot to upgrade
    private int slot;
    //the name of the building to upgrade
    private string buildingName;
    //tracks the level to upgrade to
    private int level;

    //add the listener and initializes private variables
    void Start()
    {
        button.onClick.AddListener(upgradeBuilding);
        slot = BuildingManager.managerActual.getCurrentBuildingSlot();
        (string, int) temp1 = BuildingManager.managerActual.getContentName();
        buildingName = temp1.Item1;
        level = temp1.Item2+1;
        (List<string>, List<float>) temp2 = Building.getCostByType(buildingName);
        resourceTypes = temp2.Item1;
        List<float> costs = temp2.Item2;
        costsActual = new List<float>(costs.Count);
        for (int i = 0; i < costs.Count; i++)
        {
            costsActual.Add(costs[i] * Mathf.Pow(level, 1.2f));
        }
    }
    
    //finalizes the building upgrade and returns to the base screen
    public void confirm()
    {
        for (int i = 0; i < resourceTypes.Count; i++)
        {
            ResourceManager resourceManager = ReferenceResourceByType.getManagerOfType(resourceTypes[i]);
            resourceManager.changeTotal(-costsActual[i]);
        }
        BuildingManager.managerActual.getContentsActual().levelUp();
        PlayerPrefs.SetInt(buildingName+"slot"+slot, level);
        SceneLoader.loaderActual.returnToBase();
    }

    //checks if the player has sufficient resources to upgrade and has the cost text display the result
    //if the player does not have the next upgrade level researched, display an error message
    void upgradeBuilding()
    {
        if (UpgradeLevelManager.upgradeManager.getMaxLevel(buildingName) < level)
        {
            CostTextHandler.costHandler.setText("Next Upgrade Level Not Researched!");
            return;
        }
        for(int i = 0; i < resourceTypes.Count; i++)
        {
            ResourceManager resourceManager = ReferenceResourceByType.getManagerOfType(resourceTypes[i]);
            if(costsActual[i] > resourceManager.getTotal())
            {
                CostTextHandler.costHandler.setErrorText(resourceTypes, costsActual);
                return;
            }
        }
        CostTextHandler.costHandler.setConfirmationText(resourceTypes, costsActual, this);
    }
}
