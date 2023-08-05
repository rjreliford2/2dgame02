using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResourceBarFill : MonoBehaviour
{
    [Tooltip("Resource Bar Image")]
    public Image resourceBar;

    [Tooltip("Resource this corresponds to")]
    public Resource rtype;

    public void updateResourceBar()
    {
        ResourceManager rmanager = ReferenceResourceByType.getManagerOfType(rtype);
        resourceBar.fillAmount = (float) rmanager.getTotal() / (float) rmanager.getStorage();
    }
}
