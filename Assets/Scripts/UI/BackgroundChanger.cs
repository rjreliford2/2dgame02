using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackgroundChanger : MonoBehaviour
{
    [Tooltip("image to change")] 
    public Image image;
    [Tooltip("sprite set for all the background sprites")]
    public SpriteSet spriteSet;
    //singleton reference to the changer
    public static BackgroundChanger changerActual;
    
    //set the singleton
    void Awake()
    {
        changerActual = this;
    }
    
    //change the background sprite
    public void changeSprite(int level)
    {
        if (level == 1)
        {
            image.sprite = spriteSet.level1;
        }
        else if (level == 2)
        {
            image.sprite = spriteSet.level2;
        }
        else if (level >= 3)
        {
            image.sprite = spriteSet.level3;
        }
    }
}
