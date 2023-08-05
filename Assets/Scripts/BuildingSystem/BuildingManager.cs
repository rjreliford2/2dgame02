using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BuildingManager : MonoBehaviour, IOrderable
{
    [Tooltip("List of all resources")] 
    public List<Resource> resources;
    
    //singleton reference to the building manager. do not add additional building managers
    public static BuildingManager managerActual;
    
    //the number of available building slots per type of building
    public int slotsPerType;

    //internal list of buildings in order of building slot
    private List<List<Building>> buildings = new List<List<Building>>();
    
    //the building slot corresponding to the currently open menu
    private int currentBuildingSlot;
    
    //the resource corresponding to the currently open menu
    private Resource currentRType;

    private void Start()
    {
        OrderingManager.managerActual.addToStartQueue(this, 5);
    }

    // Set singleton reference and populate the building list with the saved buildings
    public void onStart()
    {
        for (int i = 0; i < resources.Count; i++)
        {
            buildings.Add(new List<Building>());
        }
        BuildingManager.managerActual = this;
        slotsPerType = PlayerPrefs.GetInt("slotsPerType", 1);
        BackgroundChanger.changerActual.changeSprite(slotsPerType);
        foreach (Resource resource in resources)
        {
            for (int i = 0; i < slotsPerType; i++)
            {
                int level = PlayerPrefs.GetInt(resource.buildingName+"slot" + i, -1);
                if (level == -1)
                {
                    buildings[getIndexOfResourceType(resource)].Add(null);
                }
                else
                {
                    setBuilding(resource, i);
                    Building building = getContentsActual(i, resource);
                    while (level > 1)
                    {
                        building.levelUp();
                        level--;
                    }
                    PlayerPrefs.SetInt(resource.buildingName+"slot"+i, building.level);
                }
            }
        }
    }
    
    //return the highest level building for the passed resource
    public int queryHighestBuildingLevel(Resource resource)
    {
        int index = getIndexOfResourceType(resource);
        int max = 0;
        for (int i = 0; i < buildings[index].Count; i++)
        {
            if (buildings[index][i] != null)
            {
                int level = buildings[index][i].level;
                if (level > max)
                {
                    max = level;
                }
            }
        }
        return max;
    }

    //gets the name and level of a building at the passed slot for the passed resource as a tuple
    public (string, int) getContentName(int slotNumber, Resource rtype)
    {
        List<Building> listActual = buildings[getIndexOfResourceType(rtype)];
        if(slotNumber < listActual.Count)
        {
            if(listActual[slotNumber] != null)
                return (listActual[slotNumber].name, listActual[slotNumber].level);
        }
        return (null, -1);
    }
    
    //gets the name and level of a building at the passed slot for the passed resource as a tuple
    //overloaded to use the currently set resourcetype and slot
    public (string, int) getContentName()
    {
        List<Building> listActual = buildings[getIndexOfResourceType(currentRType)];
        if(listActual[currentBuildingSlot] != null)
            return (listActual[currentBuildingSlot].name, listActual[currentBuildingSlot].level);
        return (null, -1);
    }

    //returns the actual building object in the passed slot for the passed resource
    public Building getContentsActual(int slotNumber, Resource rtype)
    {
        List<Building> listActual = buildings[getIndexOfResourceType(rtype)];
        return listActual[slotNumber];
    }
    
    //overload to get the object in the slot corresponding to the currently open menu
    public Building getContentsActual()
    {
        List<Building> listActual = buildings[getIndexOfResourceType(currentRType)];
        return listActual[currentBuildingSlot];
    }

    //sets the building in the current slot to a level 1 building of the passed building type
    public void setBuilding(string building)
    {
        buildings[getIndexOfResourceType(currentRType)][currentBuildingSlot] = Building.createBuildingOfType(building, currentBuildingSlot);
        PlayerPrefs.SetInt(currentRType.buildingName+"slot"+currentBuildingSlot, 1);
    }
    
    //sets the building at the passed index to a level 1 building of the passed building type, expands the array if needed
    public void setBuilding(Resource rtype, int index)
    {
        List<Building> listActual = buildings[getIndexOfResourceType(rtype)];
        while (index >= listActual.Count)
        {
            listActual.Add(null);
        }
        listActual[index] = Building.createBuildingOfType(rtype.buildingName, index);
        PlayerPrefs.SetInt(rtype.buildingName+"slot"+index, 1);
    }

    //resets the passed slot for the passed rtype to null
    public void setSlotToNull(Resource rtype, int slot)
    {
        List<Building> listActual = buildings[getIndexOfResourceType(rtype)];
        listActual[slot] = null;
        PlayerPrefs.DeleteKey(rtype.buildingName+"slot"+slot);
    }
    
    //overload to set the slot for the currently open menu to null
    public void setSlotToNull()
    {
        List<Building> listActual = buildings[getIndexOfResourceType(currentRType)];
        listActual[currentBuildingSlot] = null;
        PlayerPrefs.DeleteKey(currentRType.buildingName+"slot"+currentBuildingSlot);
    }

    //sets the building slot whose menu is currently active
    public void setCurrentBuildingSlot(int index, Resource rtype)
    {
        currentBuildingSlot = index;
        currentRType = rtype;
    }
    
    //get the current building slot
    public int getCurrentBuildingSlot()
    {
        return currentBuildingSlot;
    }

    //private method to find the index of the list of buildings for a particular resource type
    private int getIndexOfResourceType(Resource resource)
    {
        for (int i = 0; i < resources.Count; i++)
        {
            if (resources[i] == resource)
            {
                return i;
            }
        }
        return -1;
    }
}
