using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ClickableCellScript : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler {

    public InventoryCellScript cellItemData;

    public void OnPointerClick(PointerEventData eventData) {

        if (cellItemData.itemData != null) {
            if (eventData.button == PointerEventData.InputButton.Left && UIManager.instance.leftControlKeyPressed) {
                InventoryScript.instance.DropItem(cellItemData.itemData);
            } else if (eventData.button == PointerEventData.InputButton.Left && UIManager.instance.leftControlKeyPressed) {

            } else if (eventData.button == PointerEventData.InputButton.Left) {
                UIManager.instance.ActivateCursorItemInTheAir();
                MouseCursor.instance.SetItemDataToCursor(cellItemData.itemData, cellItemData.itemIndex);                
            } else if (eventData.button == PointerEventData.InputButton.Middle) {

                //Debug.Log("Middle click " + cellItemData.itemData.inventoryId);
            } else if (eventData.button == PointerEventData.InputButton.Right) {

                //Debug.Log("Right click " + cellItemData.itemData.inventoryId);
            }
        }

    }
    
    public void OnPointerEnter(PointerEventData eventData) {

        if (cellItemData.itemData != null) {
            UIManager.instance.ShowTooltip(transform.position, cellItemData.itemData);
        }
    }

    public void OnPointerExit(PointerEventData eventData) {

        UIManager.instance.HideTooltip();
    }


}
