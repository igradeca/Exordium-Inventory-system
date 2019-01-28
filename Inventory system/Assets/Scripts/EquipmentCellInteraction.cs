using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class EquipmentCellInteraction : ItemCell, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler {
    // Debug.Log("");

    public AttrAndCharUtils.ItemType cellItemType;

    public void OnPointerClick(PointerEventData eventData) {

        if (!CursorItemHolder.instance.CursorHolderIsEmpty() && CursorItemHolder.instance.holdingItemData.itemType != cellItemType) {
            return;
        }

        OnLeftMouseClick(eventData);

        if (eventData.button == PointerEventData.InputButton.Right) {
            if (!this.IsEmpty()) {
                Inventory.instance.AddAndUpdateGrid(cellItemData, true);
                Equipment.instance.RemoveAndUpdateGrid(cellItemType);
            }            
        }
    }

    private bool ItemTypeIsEquipable(AttrAndCharUtils.ItemType itemType) {

        if (itemType == AttrAndCharUtils.ItemType.Head ||
            itemType == AttrAndCharUtils.ItemType.Armor ||
            itemType == AttrAndCharUtils.ItemType.Boots ||
            itemType == AttrAndCharUtils.ItemType.Weapon) {
            return true;
        } else {
            return false;
        }
    }

    private void OnLeftMouseClick(PointerEventData eventData) {

        if (eventData.button == PointerEventData.InputButton.Left && UIManager.instance.leftControlKeyPressed) {
            if (!this.IsEmpty()) {
                ItemSpawnerScript.instance.Spawn(cellItemData, GameMasterScript.instance.player.transform.position);
                Equipment.instance.RemoveAndUpdateGrid(cellItemType);
            }
        } else if (eventData.button == PointerEventData.InputButton.Left) {
            if (!this.IsEmpty()) {
                if (CursorItemHolder.instance.CursorHolderIsEmpty()) {
                    CursorItemHolder.instance.AddItemDataToCursor(cellItemData);
                    Equipment.instance.RemoveAndUpdateGrid(cellItemData.itemType);
                    Debug.Log("cell is full, cursor is empty.");
                } else {
                    Equipment.instance.Add(CursorItemHolder.instance.holdingItemData);
                    CursorItemHolder.instance.AddItemDataToCursor(cellItemData);
                    Equipment.instance.UpdateEquipmentGrid();
                    Debug.Log("cell is full, cursor is full.");
                }
            } else {
                if (!CursorItemHolder.instance.CursorHolderIsEmpty()) {
                    Equipment.instance.AddAndUpdateGrid(CursorItemHolder.instance.holdingItemData);
                    CursorItemHolder.instance.EmptyItemData();
                    Debug.Log("cell is empty, cursor is full.");
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
