using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PreventClick : MonoBehaviour
{
    public EventSystem eventSystem;
    private GameObject prevSelected;

    void Update()
    {
        GameObject currentSelected = EventSystem.current.currentSelectedGameObject;
        if (currentSelected == null)
            EventSystem.current.SetSelectedGameObject(prevSelected);
        else
            prevSelected = currentSelected;
    }
}
