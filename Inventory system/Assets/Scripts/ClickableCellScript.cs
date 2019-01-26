using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ClickableCellScript : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler { // 

    public InventoryCellScript cellItemData;

    private bool _pointerIsOver;
    
    public void OnPointerClick(PointerEventData eventData) {

        if (cellItemData.itemData.inventoryId != 0) {
            if (eventData.button == PointerEventData.InputButton.Left) {
                UIManager.instance.ActivateCursorItemInTheAir();   
                MouseCursor.instance.SetItemDataToCursor(cellItemData.itemData, cellItemData.itemIndex);
                //Debug.Log("Left click " + cellItemData.itemData.inventoryId);
            } else if (eventData.button == PointerEventData.InputButton.Middle) {
                //Debug.Log("Middle click " + cellItemData.itemData.inventoryId);
            } else if (eventData.button == PointerEventData.InputButton.Right) {
                //Debug.Log("Right click " + cellItemData.itemData.inventoryId);
            }
        }
    }
    
    public void OnPointerEnter(PointerEventData eventData) {
        Debug.Log("Mouse enter");
        _pointerIsOver = true;

        if (cellItemData.itemData.inventoryId != 0) {
            UIManager.instance.ShowTooltip(transform.position, cellItemData.itemData);
        }
    }

    public void OnPointerExit(PointerEventData eventData) {
        Debug.Log("Mouse exit");
        _pointerIsOver = false;

        UIManager.instance.HideTooltip();
    }


}
