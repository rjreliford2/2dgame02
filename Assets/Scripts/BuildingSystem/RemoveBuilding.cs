using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RemoveBuilding : MonoBehaviour
{
    //button to listen to
    public Button button;
    
    // Start is called before the first frame update
    void Start()
    {
        button.onClick.AddListener(removeBuilding);
    }

    //removes the building, restoring half the resources used to build it
    //and all of the pops working there, removing the building's bonuses, 
    //and resetting the building slot to null, then returns to base scene
    void removeBuilding()
    {
        (string, int) temp1 = BuildingManager.managerActual.getContentName();
        string name = temp1.Item1;
        int level = temp1.Item2;
        PopulationManager popManager = (PopulationManager) ReferenceResourceByType.getManagerOfType("pops");
        if (name.ToLower() == "Residence")
        {
            if (popManager.getResidenceCap() - level * Residence.popCapPerLevel < popManager.getUsedPops())
            {
                CostTextHandler.costHandler.setText("Cannot remove Residence: Its residents are currently working!");
                return;
            }
        }
        (List<string>, List<float>) temp2 = Building.getCostByType(name);
        List<string> resourceTypes = temp2.Item1;
        List<float> costs = temp2.Item2;
        for (int i = 0; i < resourceTypes.Count; i++)
        {
            if (resourceTypes[i].ToLower() == "pops" || resourceTypes[i].ToLower() == "population")
            {
                popManager.changeUsedPops(costs[i]);
                continue;
            }
            float costRefund = 0.5f*costs[i]* Mathf.Pow(level, 1.2f);
            ReferenceResourceByType.getManagerOfType(resourceTypes[i]).changeTotal(costRefund);
        }
        BuildingManager.managerActual.getContentsActual().removeSelf();
        BuildingManager.managerActual.setSlotToNull();
        SceneLoader.loaderActual.returnToBase();
    }
}
