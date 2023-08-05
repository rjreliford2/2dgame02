using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class ConcreteMixer : Gatherer
{
    //the amount of concrete income per second increase per building level
    public static float concretePerSecondPerLevel = 10.0f;
    
    //defines the resource type this building effects
    private static string rType = "concrete";
    
    //private list tracking the types of resources this building costs for level 1
    public static List<string> costTypes = new List<string>() {"Concrete", "Metal", "Funds", "Pops"};
    
    //private list tracking the actual cost per resource (matched by index to the costs in the previous array)
    private static List<float> costActual = new List<float>() {200.0f, 300.0f, 200.0f, 10.0f };
    
    //instantiates the mixer and adjusts concrete income per second appropriately
    public ConcreteMixer(int index)
    {
        this.name = "Concrete Mixer";
        this.slotNumber = index;
        ReferenceResourceByType.getManagerOfType("concrete").changeMod(concretePerSecondPerLevel);
    }

    //provides the gatherer class with the resource type this class effects
    //and the amount by which it effects it
    protected override (float, string) getChangeInfo()
    {
        return (concretePerSecondPerLevel, rType);
    }
    
    //helper method from the cost interface returning the cost details
    public static (List<string>, List<float>) getCost()
    {
        return (costTypes, costActual);
    }
}
