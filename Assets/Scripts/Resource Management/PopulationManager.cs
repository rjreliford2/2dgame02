using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopulationManager : ResourceManager
{
    [Tooltip("Defines the amount of food required to make a clone")]
    public float foodPerClone;
    
    //tracks the number of pops currently working
    private float popsUsed;
    
    //tracker used for fractional clones per second values, since the
    //player shouldn't create fractional people
    private float cloneProgress = 0.0f;
    
    //static variable tracking the total amount of space for pops
    private static float residenceCapacity = 100.0f;
    
    //load the values necessary for the population manager
    public override void onStart()
    {
        resourceTotal = PlayerPrefs.GetFloat(rtype.rtype+"total", startingAmount);
        popsUsed = PlayerPrefs.GetFloat("popsUsed", 0);
        incomeMod = PlayerPrefs.GetFloat(rtype.rtype+"mod");
        incomeMult = PlayerPrefs.GetFloat(rtype.rtype+"mult", incomeMult);
        residenceCapacity = PlayerPrefs.GetFloat("rcap", 100);
        ReferenceResourceByType.setManagerSingleton(resourceName, this);
    }
    
    //changes the residence capacity
    public float changeResidenceCap(float changeMod)
    {
        residenceCapacity += changeMod;
        return residenceCapacity;
    }

    //allows the number of currently employed pops to be changed directly
    public float changeUsedPops(float change)
    {
        popsUsed -= change;
        PlayerPrefs.SetFloat("popsUsed", popsUsed);
        return popsUsed;
    }
    
    //getter for residence capacity
    public float getResidenceCap()
    {
        return residenceCapacity;
    }
    
    //generic override to get residence capacity rather than warehouse storage
    public override float getStorage()
    {
        return residenceCapacity;
    }
    
    //getter for used pops
    public float getUsedPops()
    {
        return popsUsed;
    }

    //overrides change total to work with population. 
    //DOES NOT CHECK TO ENSURE THAT CHANGE IS VALID
    //methods calling this should perform checks first for
    //negative change values
    public override float changeTotal(float change)
    {
        if (change > 0)
        {
            resourceTotal += change;
            PlayerPrefs.SetFloat(rtype.rtype+"total", resourceTotal);
        }
        else
        {
            popsUsed -= change;
            PlayerPrefs.SetFloat("popsUsed", popsUsed);
        }
        return resourceTotal-popsUsed;
    }
    
    //override getTotal to provide a total number more accurate to population
    public override float getTotal()
    {
        return resourceTotal - popsUsed;
    }
    
    //overrides repaint to provide a more accurate display for population
    public override void repaint()
    {
        text.text = resourceName + "\n" + (int)(resourceTotal) + " / " + (int)(residenceCapacity) + "\n" + (int)(popsUsed) + " Working" + "\n" + (int)(resourceTotal-popsUsed) + " Available";
    }

    //overrides resource update to be more appropriate to population
    protected override void updateResource()
    {
        cloneProgress += (defaultIncome + incomeMod) * incomeMult*TickManager.tickRate*Time.deltaTime;
        ResourceManager foodManager = ReferenceResourceByType.getManagerOfType("Food");
        while (cloneProgress >= 1)
        {
            if (foodManager.getTotal() >= foodPerClone && resourceTotal < residenceCapacity)
            {
                cloneProgress--;
                foodManager.changeTotal(-foodPerClone);
                changeTotal(1);
            }
            else
            {
                cloneProgress--;
            }
        }
    }
    
    //checks the number of people against the residency cap.
    //if the player ever has more people than space to house them, they will lose people
    protected override void checkResourceCap()
    {
        if (resourceTotal > residenceCapacity)
        {
            resourceTotal = residenceCapacity;
        }
    }
}
