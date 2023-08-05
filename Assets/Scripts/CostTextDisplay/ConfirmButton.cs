using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConfirmButton : MonoBehaviour
{
    //button to listen to
    public Button button;

    private IConfirmable scriptToConfirm;
    
    //set the listener
    void Start()
    {
        button.onClick.AddListener(confirm);
    }
    
    //set the confirmable
    public void setConfirmable(IConfirmable confirmable)
    {
        scriptToConfirm = confirmable;
    }

    //tells the confirmable that it is confirmed and can proceed
    void confirm()
    {
        scriptToConfirm.confirm();
    }
}
