using System;
using System.Collections.Generic;

public abstract class Building : ICostInterface
{
    //this building's building slot
    public int slotNumber;
    
    //name of the building
    public string name;
    
    //level of the building
    public int level = 1;

    //static method to create a building of the appropriate subclass from a string
    public static Building createBuildingOfType(string type, int index)
    {
        type = type.ToLower();
        return type switch
        {
            "cloning vat" => new CloningVat(index),
            "concrete mixer" => new ConcreteMixer(index),
            "farm" => new Farm(index),
            "metal foundry" => new MetalFoundry(index),
            "mint" => new Mint(index),
            "research lab" => new ResearchLab(index),
            "residence" => new Residence(index),
            "warehouse" => new Warehouse(index),
            _ => null
        };
    }
    
    //static method to get the cost lists of a passed string representing a building type
    public static (List<string>, List<float>) getCostByType(string type)
    {
        type = type.ToLower();
        return type switch
        {
            "cloning vat" => CloningVat.getCost(),
            "concrete mixer" => ConcreteMixer.getCost(),
            "farm" => Farm.getCost(),
            "metal foundry" => MetalFoundry.getCost(),
            "mint" => Mint.getCost(),
            "research lab" => ResearchLab.getCost(),
            "residence" => Residence.getCost(),
            "warehouse" => Warehouse.getCost(),
            _=> (null, null)
        };
    }

    //apply the appropriate changes for a levelup of this building
    public abstract void levelUp();

    //apply the appropriate changes for the removal of this building
    public abstract void removeSelf();
}
