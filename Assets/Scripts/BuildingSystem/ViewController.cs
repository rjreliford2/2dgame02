using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ViewController : MonoBehaviour, IOrderable
{
    //singleton reference to the controller
    public static ViewController controllerActual;
    //reference to the slot that is currently open in the view
    private SlotManager currentOpenManager = null;
    //whether the menu has been opened in this session
    private bool hasBeenOpened = false;

    private void Start()
    {
        OrderingManager.managerActual.addToStartQueue(this, 6);
    }

    //set the singleton
    public void onStart()
    {
        controllerActual = this;
        hasBeenOpened = false;
    }

    //closes the currently open slot and sets the open manager
    public bool requestOpen(SlotManager requester)
    {
        if (currentOpenManager != null)
        {
            currentOpenManager.closeMenu();
        }
        ScrollSingleton.scrollview.SetActive(true);
        currentOpenManager = requester;
        if (!hasBeenOpened)
        {
            hasBeenOpened = true;
            return true;
        }
        else
        {
            return false;
        }
    }

    public void requestClose()
    {
        ScrollSingleton.scrollview.SetActive(false);
        currentOpenManager = null;
    }
}
