using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine;

public class ButtonController : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerEnterHandler, IPointerExitHandler {
	//[HideInInspector]
    public bool Pressed = false;
 
    public UnityEvent onPressed;
 
    public void OnPointerDown(PointerEventData eventData)
    {
        Pressed = true;
    }
 
    public void OnPointerEnter(PointerEventData eventData)
    {
        Pressed = true;
    }
 
    public void OnPointerExit(PointerEventData eventData)
    {
        Pressed = false;
    }
 
    public void OnPointerUp(PointerEventData eventData)
    {
        Pressed = false;
    }
 
    public void Update()
    {
		//Debug.Log(onPressed.IsInvoking());
        if (Pressed)
        {
            onPressed.Invoke();
        } else {
			onPressed.RemoveAllListeners();
		}
    }
	
}
