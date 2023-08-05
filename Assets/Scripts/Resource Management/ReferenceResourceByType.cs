using System;

//Static class that manages singletons for the resource manager of each resource type
public static class ReferenceResourceByType
{
    private static PopulationManager pops;
    private static ResourceManager food;
    private static ResourceManager metal;
    private static ResourceManager concrete;
    private static ResourceManager rp;
    private static ResourceManager funds;

    //sets the singleton for the appropriate resource type.
    //called by resource managers on start
    public static void setManagerSingleton(string resourceType, ResourceManager toSet)
    {
        resourceType = resourceType.ToLower();
        switch(resourceType)
        {
            case "population":
                pops = (PopulationManager) toSet;
                break;
            case "food":
                food = toSet;
                break;
            case "metal":
                metal = toSet;
                break;
            case "concrete":
                concrete = toSet;
                break;
            case "rp":
                rp = toSet;
                break;
            case "funds":
                funds = toSet;
                break;
        }
    }

    //returns the resource manager for the passed resource type
    public static ResourceManager getManagerOfType(string resourceType)
    {
        resourceType = resourceType.ToLower();
        return resourceType switch
        {
            "population" => pops,
            "pops" => pops,
            "food" => food,
            "metal" => metal,
            "concrete" => concrete,
            "rp" => rp,
            "funds" => funds,
            _ => null
        };
    }
    
    //overload get manager of type to work with resource scriptable objects
    public static ResourceManager getManagerOfType(Resource resourceType)
    {
        string type = resourceType.rtype;
        return type switch
        {
            "population" => pops,
            "food" => food,
            "metal" => metal,
            "concrete" => concrete,
            "rp" => rp,
            "funds" => funds,
            _ => null
        };
    }
    
}
