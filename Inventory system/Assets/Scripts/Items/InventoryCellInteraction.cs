using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InventoryCellInteraction : ItemCell, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler {
    // Debug.Log("");
    public void OnPointerClick(PointerEventData eventData) {

        if (eventData.button == PointerEventData.InputButton.Left && UIManager.instance.leftControlKeyPressed) {
            if (!this.IsEmpty()) {
                ItemSpawnerScript.instance.Spawn(cellItemData, GameMasterScript.instance.player.transform.position);
                Inventory.instance.RemoveAndUpdateGrid(cellItemData);
            }
        } else if (eventData.button == PointerEventData.InputButton.Left && UIManager.instance.leftShiftKeyPressed) {
            if (!this.IsEmpty()) {
                if (cellItemData.currentStack > 1 && cellItemData.maxStack > 1) {
                    UIManager.instance.ShowSplitPanel();
                    SplitPanelScript.instance.SetPanel(cellItemData);
                }
            }
        } else if (eventData.button == PointerEventData.InputButton.Left) {
            if (!this.IsEmpty()) {
                if (CursorItemHolder.instance.CursorHolderIsEmpty()) {
                    CursorItemHolder.instance.AddItemDataToCursor(cellItemData);
                    //Debug.Log("empty");
                } else {
                    bool newStack = CursorItemHolder.instance.holdingItemData.name == cellItemData.name ? false : true;
                    Inventory.instance.AddAndUpdateGrid(CursorItemHolder.instance.holdingItemData, newStack);
                    CursorItemHolder.instance.AddItemDataToCursor(cellItemData);
                    //Debug.Log("NOT empty");
                }
                Inventory.instance.RemoveAndUpdateGrid(cellItemData);
            } else if (this.IsEmpty() && !CursorItemHolder.instance.CursorHolderIsEmpty()) {
                Inventory.instance.AddAndUpdateGrid(CursorItemHolder.instance.holdingItemData, true);
                CursorItemHolder.instance.EmptyItemData();
            }
        } else if (eventData.button == PointerEventData.InputButton.Middle) {
            if (cellItemData.itemType == AttrAndCharUtils.ItemType.Consumable) {
                // consume item
                Attributes.instance.AddNewBuffs(cellItemData.attributes);
                Inventory.instance.RemoveAndUpdateGrid(cellItemData);
                Debug.Log("Item consumed");
            }
        } else if (eventData.button == PointerEventData.InputButton.Right) {
            if (!this.IsEmpty() && (int)cellItemData.itemType < 4) {
                if (Equipment.instance.IsSlotEmpty(cellItemData.itemType)) {
                    Equipment.instance.AddAndUpdateGrid(cellItemData);
                    Inventory.instance.RemoveAndUpdateGrid(cellItemData);
                } else {
                    Inventory.instance.Add(Equipment.instance.equipedItems[(int)cellItemData.itemType], true);
                    Equipment.instance.AddAndUpdateGrid(cellItemData);
                    Inventory.instance.RemoveAndUpdateGrid(cellItemData);
                }
            }
        }
    }
    
    public void OnPointerEnter(PointerEventData eventData) {

        if (!this.IsEmpty()) {
            UIManager.instance.ShowTooltip(transform.position, cellItemData);
        }
    }

    public void OnPointerExit(PointerEventData eventData) {

        UIManager.instance.HideTooltip();
    }


}
