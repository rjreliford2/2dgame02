using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Residence : Storage
{
    //defines the number of pops a residence can hold per level
    public static float popCapPerLevel = 50.0f;
    
    //private list tracking the types of resources this building costs for level 1
    public static List<string> costTypes = new List<string>() {"Concrete", "Metal", "Funds"};
    
    //private list tracking the actual cost per resource (matched by index to the costs in the previous array)
    private static List<float> costActual = new List<float>() {300.0f, 100.0f, 500.0f };
    
    //Instantiates the residence and changes the residence cap
    public Residence(int index)
    {
        this.slotNumber = index;
        this.name = "Residence";
        PopulationManager pops = (PopulationManager) (ReferenceResourceByType.getManagerOfType("population"));
        pops.changeResidenceCap(popCapPerLevel);
    }

    //increases the structure's level, providing an appropriate capacity increase
    public override void levelUp()
    {
        this.level++;
        PopulationManager pops = (PopulationManager) (ReferenceResourceByType.getManagerOfType("population"));
        pops.changeResidenceCap(popCapPerLevel);
    }

    //removes this building's bonuses to capacity
    //DOES NOT CHECK IF REMOVAL IS VALID
    public override void removeSelf()
    {
        PopulationManager pops = (PopulationManager) (ReferenceResourceByType.getManagerOfType("population"));
        pops.changeResidenceCap(-popCapPerLevel*this.level);
    }
    
    //helper method from the cost interface returning the cost details
    public static (List<string>, List<float>) getCost()
    {
        return (costTypes, costActual);
    }
}
