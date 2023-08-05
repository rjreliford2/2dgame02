using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mint : Gatherer
{
    //the amount of money income per second increase per building level
    public static float moneyPerSecondPerLevel = 10.0f;
    
    //defines the resource type this building effects
    private static string rType = "funds";
    
    //private list tracking the types of resources this building costs for level 1
    public static List<string> costTypes = new List<string>() {"Concrete", "Funds", "Pops"};
    
    //private list tracking the actual cost per resource (matched by index to the costs in the previous array)
    private static List<float> costActual = new List<float>() {600.0f, 500.0f, 20.0f };

    //instantiates the mint and adjusts money income per second appropriately
    public Mint(int index)
    {
        this.name = "Mint";
        this.slotNumber = index;
        ReferenceResourceByType.getManagerOfType("funds").changeMod(moneyPerSecondPerLevel);
    }

    //provides the gatherer class with the resource type this class effects
    //and the amount by which it effects it
    protected override (float, string) getChangeInfo()
    {
        return (moneyPerSecondPerLevel, rType);
    }
    
    //helper method from the cost interface returning the cost details
    public static (List<string>, List<float>) getCost()
    {
        return (costTypes, costActual);
    }
}
