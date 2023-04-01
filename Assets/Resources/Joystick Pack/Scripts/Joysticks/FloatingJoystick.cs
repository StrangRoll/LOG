using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class FloatingJoystick : Joystick
{
    public override void OnPointerDown(PointerEventData eventData)
    {
        background.gameObject.SetActive(true);
        background.anchoredPosition = ScreenPointToAnchoredPosition(eventData.position);
        //base.OnPointerDown(eventData);
    }

    public override void OnPointerUp(PointerEventData eventData)
    {
        background.gameObject.SetActive(false);
        //base.OnPointerUp(eventData);
    }
}