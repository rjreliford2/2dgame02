using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class SlotManager : MonoBehaviour, IOrderable
{
    [Tooltip("resource type this manager corresponds to")]
    public Resource rtype;
    [Tooltip("the button that this manager should listen to")]
    public Button button;
    [Tooltip("reference to the prefab building button")]
    public GameObject prefabButton;
    [Tooltip("sprite set for this building type")]
    public SpriteSet spriteSet;
    //list of the buttons this manager should activate in the scrollview
    private List<GameObject> buttons = new List<GameObject>();
    //whether the menu for the slot is currently open
    private bool open = false;

    private void Start()
    {
        OrderingManager.managerActual.addToStartQueue(this, 10);
    }

    //add the onclick listener, set the appropriate sprite from the spriteset
    public void onStart()
    {
        button.onClick.AddListener(onClick);
        repaint();
    }

    void onClick()
    {
        if (open)
        {
            closeMenu();
            ViewController.controllerActual.requestClose();
        }
        else
        {
            float offset;
            if (ViewController.controllerActual.requestOpen(this))
            {
                offset = -70.0f;
            }
            else
            {
                offset = 0.0f;
            }
            openMenu(offset);
        }
    }

    //open this menu
    void openMenu(float offset)
    {
        for (int i = 0; i < BuildingManager.managerActual.slotsPerType; i++)
        {
            if (i >= buttons.Count)
            {
                buttons.Add(Instantiate(prefabButton));
                GameObject newButton = buttons[i];
                newButton.transform.SetParent(GameObject.FindGameObjectWithTag("viewcontent").transform);
                newButton.transform.localScale = new Vector3(1, 1, 1);
                RectTransform newButtonTransform = newButton.GetComponent<RectTransform>();
                newButtonTransform.localPosition = new Vector3(60.03055f+offset, -30 - (i * 45), 0);
                TextMeshProUGUI text = newButton.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
                (string, int) temp = BuildingManager.managerActual.getContentName(i, rtype);
                BuildBuilding builder = newButton.GetComponent<BuildBuilding>();
                builder.setRType(rtype);
                builder.setIndex(i);
                BuildSlot upgrader = newButton.GetComponent<BuildSlot>();
                upgrader.rtype = rtype;
                upgrader.slotIndex = i;
                upgrader.myManager = this;
                upgrader.initialize();
                if (temp.Item1 == null)
                {
                    text.text = "Empty Slot";
                    
                }
            }
            else
            {
                buttons[i].SetActive(true);
                buttons[i].GetComponent<BuildSlot>().initialize();
            }
        }
        open = true;
    }

    //close this menu
    public void closeMenu()
    {
        foreach (GameObject _button in buttons)
        {
            _button.SetActive(false);
        }
        CostTextHandler.costHandler.setText("");
        open = false;
    }
    
    //repaint the sprite
    public void repaint()
    {
        int highestLevel = BuildingManager.managerActual.queryHighestBuildingLevel(rtype);
        Image image = this.gameObject.GetComponent<Image>();
        if (highestLevel == 1)
        {
            image.sprite = spriteSet.level1;
        }
        else if (highestLevel == 2)
        {
            image.sprite = spriteSet.level2;
        }
        else if (highestLevel >= 3)
        {
            image.sprite = spriteSet.level3;
        }
    }
}
