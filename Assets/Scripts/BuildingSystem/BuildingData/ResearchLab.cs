using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResearchLab : Gatherer
{
    //the amount of RP income per second increase per building level
    public static float rpPerSecondPerLevel = 5.0f;
    
    //defines the resource type this building effects
    private static string rType = "rp";
    
    //private list tracking the types of resources this building costs for level 1
    public static List<string> costTypes = new List<string>() {"Concrete", "Metal", "Funds", "Pops"};
    
    //private list tracking the actual cost per resource (matched by index to the costs in the previous array)
    private static List<float> costActual = new List<float>() {300.0f, 800.0f, 1000.0f, 15.0f };

    //instantiates the research lab and adjusts rp income per second appropriately
    public ResearchLab(int index)
    {
        this.name = "Research Lab";
        this.slotNumber = index;
        ReferenceResourceByType.getManagerOfType("rp").changeMod(rpPerSecondPerLevel);
    }

    //provides the gatherer class with the resource type this class effects
    //and the amount by which it effects it
    protected override (float, string) getChangeInfo()
    {
        return (rpPerSecondPerLevel, rType);
    }
    
    //helper method from the cost interface returning the cost details
    public static (List<string>, List<float>) getCost()
    {
        return (costTypes, costActual);
    }
}
