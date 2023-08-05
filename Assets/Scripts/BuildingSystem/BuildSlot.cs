using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;

public class BuildSlot : MonoBehaviour
{
    public Button button;
    public TextMeshProUGUI text;
    public int slotIndex;
    public Resource rtype;
    public BuildBuilding builder;
    public SlotManager myManager;
    private int buildingLevel;
    
    //Adds the button listener and repaints the building slot based on data stored in manager if required
    void Start()
    {
        button.onClick.AddListener(slotClicked);
    }
    
    //initializes the slot values as needed
    public void initialize()
    {
        (string, int) temp = BuildingManager.managerActual.getContentName(slotIndex, rtype);
        if(temp.Item2 != -1)
        {
            buildingLevel = temp.Item2;
            repaintSlot();
        }
    }
    
    //tells the manager to repaint itself
    public void notifyManagerOfChange()
    {
        myManager.repaint();
    }

    //loads the appropriate menu on click
    void slotClicked()
    {
        if (buildingLevel < 1)
        {
            builder.buttonClicked();
        }
        else
        {
            BuildingManager.managerActual.setCurrentBuildingSlot(slotIndex, rtype);
            SceneLoader.loaderActual.loadUpgradeMenu();
        }
    }

    //temp method that sets the slot's text based on the building in it
    void repaintSlot()
    {
        text.text = rtype.buildingName + " " + buildingLevel;
    }
}
