using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MenuButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler {

    public GameObject displayPanel;

	public void OnPointerEnter(PointerEventData eventData)
    {
        displayPanel.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        displayPanel.SetActive(false);
    }
}
