using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollSingleton : MonoBehaviour
{
    public static GameObject scrollview;

    void Awake()
    {
        scrollview = this.gameObject;
        scrollview.SetActive(false);
    }
}
