using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InteractCell : ItemCell, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler {

    public void OnPointerClick(PointerEventData eventData) {

        if (itemData != null) {
            if (eventData.button == PointerEventData.InputButton.Left && UIManager.instance.leftControlKeyPressed) {
                Inventory.instance.DropItem(itemData);
            } else if (eventData.button == PointerEventData.InputButton.Left && UIManager.instance.leftShiftKeyPressed) {
                if (itemData.currentStack > 1 && itemData.maxStack > 1) {
                    UIManager.instance.ShowSplitPanel();
                    SplitPanelScript.instance.SetPanel(itemData);
                }
            } else if (eventData.button == PointerEventData.InputButton.Left) {
                UIManager.instance.ActivateCursorItemInTheAir();
                MouseCursor.instance.SetItemDataToCursor(itemData, itemIndex);
            } else if (eventData.button == PointerEventData.InputButton.Middle) {
                // consume item
                //Debug.Log("Middle click " + cellItemData.itemData.inventoryId);
            } else if (eventData.button == PointerEventData.InputButton.Right) {
                // if in inventory - equip that item
                // if equiped - put it in inventory
                //Debug.Log("Right click " + cellItemData.itemData.inventoryId);
            }
        }

    }
    
    public void OnPointerEnter(PointerEventData eventData) {

        if (itemData != null) {
            UIManager.instance.ShowTooltip(transform.position, itemData);
        }
    }

    public void OnPointerExit(PointerEventData eventData) {

        UIManager.instance.HideTooltip();
    }


}
