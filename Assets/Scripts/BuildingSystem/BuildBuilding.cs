using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;

public class BuildBuilding : MonoBehaviour, IConfirmable
{
    [Tooltip("Text component to change")]
    public TextMeshProUGUI text;
    [Tooltip("Build slot component of the build button this is on")]
    public BuildSlot buildSlot;
    //the resource type to which this building corresponds 
    private Resource rtype;
    //the slot this building is in
    private int index;
    //tracks the resource types in the cost
    private List<string> resourceTypesToChange;
    //tracks the cost to each resource, matched by index to the types in resourceTypesToChange
    private List<float> changeAmount;

    //sets the resource type of this building and gets the appropriate costs.
    public void setRType(Resource resource)
    {
        rtype = resource;
        (List<string>, List<float>) temp = Building.getCostByType(rtype.buildingName);
        resourceTypesToChange = temp.Item1;
        changeAmount = temp.Item2;
    }
    
    //sets the slot number this script corresponds to
    public void setIndex(int _index)
    {
        index = _index;
    }

    //build the building
    public void confirm()
    {
        for (int i = 0; i < resourceTypesToChange.Count; i++)
        {
            ResourceManager resourceManager = ReferenceResourceByType.getManagerOfType(resourceTypesToChange[i]);
            resourceManager.changeTotal(-changeAmount[i]);
        }
        BuildingManager.managerActual.setBuilding(rtype, index);
        CostTextHandler.costHandler.setText("");
        buildSlot.initialize();
        buildSlot.notifyManagerOfChange();
    }

    //checks if the player has sufficient resources to build this building and tells the cost text to display the result
    public void buttonClicked()
    {
        for (int i = 0; i < resourceTypesToChange.Count; i++)
        {
            ResourceManager resourceManager = ReferenceResourceByType.getManagerOfType(resourceTypesToChange[i]);
            if (changeAmount[i] > resourceManager.getTotal())
            {
                CostTextHandler.costHandler.setErrorText(resourceTypesToChange, changeAmount);
                return;
            }
        }
        CostTextHandler.costHandler.setConfirmationText(resourceTypesToChange, changeAmount, this);
    }
}
