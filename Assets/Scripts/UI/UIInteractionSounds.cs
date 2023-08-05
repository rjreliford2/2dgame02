using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIInteractionSounds : MonoBehaviour, IPointerEnterHandler, IPointerClickHandler
{
    public AudioSource hoverSound;
    public AudioSource clickSound;
    
    public void OnPointerEnter(PointerEventData eventData)
    {
        hoverSound.Play();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        clickSound.Play();
    }
}
