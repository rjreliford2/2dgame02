using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class atommanager : MonoBehaviour
{
    //to display the correct text of what the current atom is pulls it from atomcollector script
    public TextMeshProUGUI atomText;
    public GameObject otherGameObject;

    private string atom = "";
    // Start is called before the first frame update
    void Start()
    {
        atom = otherGameObject.GetComponent<atomcollector>().currentatom;
        atomText.text = "Current Atom: " + atom.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        atom = otherGameObject.GetComponent<atomcollector>().currentatom;
        atomText.text = "Current Atom: " + atom.ToString();
    }
}
