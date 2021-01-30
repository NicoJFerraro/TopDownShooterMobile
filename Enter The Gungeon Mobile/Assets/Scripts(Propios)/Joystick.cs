using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Joystick : MonoBehaviour, IDragHandler, IEndDragHandler {
    public Vector3 InitialPosition;
    public Vector3 stickValue;

    public void OnDrag(PointerEventData eventData)
    {
        stickValue = Vector3.ClampMagnitude((Vector3)eventData.position - InitialPosition, 25);
        this.transform.position = new Vector3 (stickValue.x, stickValue.y,0) + InitialPosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        this.transform.position = InitialPosition;
        stickValue = Vector3.zero;
    }
    
    void Start () {
        InitialPosition = this.transform.position;
	}

}
