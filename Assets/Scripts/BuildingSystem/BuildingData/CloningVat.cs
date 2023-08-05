using System;
using System.Collections.Generic;
using Unity.VisualScripting;

[Serializable]
public class CloningVat : Gatherer
{
    //tracks pops per second granted per level of the building
    public static float popsPerSecondPerLevel = 0.35f;
    
    //defines the resource type this building effects
    private static string rType = "population";
    
    //private list tracking the types of resources this building costs for level 1
    public static List<string> costTypes = new List<string>() {"Concrete", "Metal", "Funds", "Pops"};
    
    //private list tracking the actual cost per resource (matched by index to the costs in the previous array)
    private static List<float> costActual = new List<float>() {500.0f, 500.0f, 1000.0f, 20.0f };

    //instantiates the cloning vat with starting values and adjusts pop income
    public CloningVat(int index)
    {
        this.name = "Cloning Vat";
        this.slotNumber = index;
        ReferenceResourceByType.getManagerOfType("population").changeMod(popsPerSecondPerLevel);
    }

    //provides the gatherer class with the resource type this class effects
    //and the amount by which it effects it
    protected override (float, string) getChangeInfo()
    {
        return (popsPerSecondPerLevel, rType);
    }

    //helper method from the cost interface returning the cost details
    public static (List<string>, List<float>) getCost()
    {
        return (costTypes, costActual);
    }
}
