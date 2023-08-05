using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeLevelManager : MonoBehaviour, IOrderable
{
    //manager singleton
    public static UpgradeLevelManager upgradeManager;

    //tracks the building upgrades which have been researched
    //CloningVat, ConcreteMixer, Farm, MetalFoundry, Mint, ResearchLab, Residence, Warehouse
    private List<int> upgradeLevelMax = new List<int> {1, 1, 1, 1, 1, 1, 1, 1};

    void Start()
    {
        OrderingManager.managerActual.addToStartQueue(this, 4);
    }
    
    //set manager singleton
    public void onStart()
    {
        UpgradeLevelManager.upgradeManager = this;
        for (int i = 0; i < 8; i++)
        {
            int upgradeLevelForSlot = PlayerPrefs.GetInt("upgradeLevel" + i, 1);
            if (upgradeLevelForSlot > 1)
            {
                upgradeLevelMax[i] = upgradeLevelForSlot;
            }
        }
    }

    //returns the maximum level of the passed building type
    public int getMaxLevel(Resource type)
    {
        int index = getUpgradeIndexByType(type);
        if (index == -1)
        {
            return -1;
        }
        return upgradeLevelMax[index];
    }
    
    //overload of getMaxLevel to interface with preexisting string based system
    public int getMaxLevel(string type)
    {
        int index = getUpgradeIndexByType(type);
        if (index == -1)
        {
            return -1;
        }
        return upgradeLevelMax[index];
    }

    //increases the maximum allowed level of the passed building type
    public void increaseMaxLevel(Resource type)
    {
        int index = getUpgradeIndexByType(type);
        if (index >= 0)
        {
            upgradeLevelMax[index] += 1;
            PlayerPrefs.SetInt("upgradeLevel"+index, upgradeLevelMax[index]);
        }
    }

    //gets the index in the upgrade list from a string type
    private int getUpgradeIndexByType(Resource resource)
    {
        string type = resource.rtype;
        return type switch
        {
            "population" => 0,
            "concrete" => 1,
            "food" => 2,
            "metal" => 3,
            "funds" => 4,
            "rp" => 5,
            "rcap" => 6,
            "wcap" => 7,
            _ => -1

        };
    }
    
    //overload of getUpgradeIndex to interface with existing string based system
    private int getUpgradeIndexByType(string type)
    {
        type = type.ToLower();
        return type switch
        {
            "cloning vat" => 0,
            "concrete mixer" => 1,
            "farm" => 2,
            "metal foundry" => 3,
            "mint" => 4,
            "research lab" => 5,
            "residence" => 6,
            "warehouse" => 7,
            _ => -1

        };
    }
}
