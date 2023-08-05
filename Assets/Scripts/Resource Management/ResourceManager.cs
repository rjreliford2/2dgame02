using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ResourceManager : MonoBehaviour, IOrderable
{
    [Tooltip("Name of the resource")]
    public string resourceName;
    [Tooltip("Default resource income in resources per second")]
    public float defaultIncome;
    [Tooltip("Starting resource amount")]
    public float startingAmount;
    [Tooltip("Whether this resource should have capacity determined by Warehouses")]
    public bool shouldUseWarehouseStorage;
    [Tooltip("Text that should be set by the resourcemanager")]
    public TextMeshProUGUI text;
    [Tooltip("Associated resource bar script")]
    public ResourceBarFill barToFill;
    [Tooltip("resource scriptable object corresponding to this manager")]
    public Resource rtype;

    //total amount of resources
    protected float resourceTotal = 0.0f;

    //income modifier in resources per second
    protected float incomeMod = 0.0f;

    //the amount by which the base income should be multiplied
    protected float incomeMult = 1.0f;

    //the numbers of seconds since the text on screen was last repainted
    private float sinceLastRepaint = 0.0f;

    //static variable tracking the max amount per resource the warehouses can store
    private static float warehouseStorage = 1000.0f;

    void Start()
    {
        OrderingManager.managerActual.addToStartQueue(this, 0);
    }

    //initializes the resource amount and the singleton for the manager
    public virtual void onStart()
    {
        resourceTotal = PlayerPrefs.GetFloat(rtype.rtype+"total", startingAmount);
        warehouseStorage = PlayerPrefs.GetFloat("wstorage", 1000);
        ReferenceResourceByType.setManagerSingleton(resourceName, this);
    }

    //updates the resource amount and the time since the last repaint, repaints the text every tenth of a second
    void Update()
    {
        updateResource();
        checkResourceCap();
        sinceLastRepaint += Time.deltaTime;
        if(sinceLastRepaint >= 0.1f)
        {
            repaint();
            sinceLastRepaint = 0.0f;
        }      
    }

    public static float changeResourceCap(float change)
    {
        warehouseStorage += change;
        return warehouseStorage;
    }

    //called by update to apply appropriate changes to the resource total
    protected virtual void updateResource()
    {
        resourceTotal += (defaultIncome + incomeMod) * incomeMult*TickManager.tickRate*Time.deltaTime;
    }

    //ensures that the total resource count does not exceed capacity
    protected virtual void checkResourceCap()
    {
        if(shouldUseWarehouseStorage && resourceTotal > ResourceManager.warehouseStorage)
        {
            resourceTotal = ResourceManager.warehouseStorage;
        }
    }

    //adds the change value to the income mod
    public float changeMod(float change)
    {
        incomeMod += change;
        return incomeMod;
    }

    //adds the change value to the income mult
    public float changeMult(float change)
    {
        incomeMult += change;
        return incomeMult;
    }

    //adds the change value to the resource total
    //DOES NOT CHECK TO ENSURE THAT CHANGE IS VALID
    //methods calling this should perform checks first for
    //negative change values
    public virtual float changeTotal(float change)
    {
        resourceTotal += change;
        checkResourceCap();
        PlayerPrefs.SetFloat(rtype.rtype+"total", resourceTotal);
        repaint();
        return resourceTotal;
    }

    //returns the current resource total
    public virtual float getTotal()
    {
        return resourceTotal;
    }

    //returns the current resource total
    public virtual float getStorage()
    {
        return warehouseStorage;
    }

    //repaints the resource text and bar based on the rounded resource total
    public virtual void repaint()
    {
        PlayerPrefs.SetFloat(rtype.rtype+"total", resourceTotal);
        text.text = resourceName + "\n" + (int)(resourceTotal);
        if (shouldUseWarehouseStorage)
        {
            text.text += " / " + (int)warehouseStorage;
        }
        if(barToFill != null)
            barToFill.updateResourceBar();
    }
}
