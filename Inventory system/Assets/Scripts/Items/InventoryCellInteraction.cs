﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InventoryCellInteraction : ItemCell, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler {
    // Debug.Log("");
    public void OnPointerClick(PointerEventData eventData) {

        if (eventData.button == PointerEventData.InputButton.Left && UIManager.instance.leftControlKeyPressed) {
            if (cellItemData != null) {
                ItemSpawnerScript.instance.Spawn(cellItemData, GameMasterScript.instance.player.transform.position);
                Inventory.instance.RemoveAndUpdateGrid(cellItemData);
            }
        } else if (eventData.button == PointerEventData.InputButton.Left && UIManager.instance.leftShiftKeyPressed) {
            if (cellItemData != null) {
                if (cellItemData.currentStack > 1 && cellItemData.maxStack > 1) {
                    UIManager.instance.ShowSplitPanel();
                    SplitPanelScript.instance.SetPanel(cellItemData);
                }
            }
        } else if (eventData.button == PointerEventData.InputButton.Left) {
            if (cellItemData != null) {
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
            } else if (cellItemData == null && !CursorItemHolder.instance.CursorHolderIsEmpty()) {
                Inventory.instance.AddAndUpdateGrid(CursorItemHolder.instance.holdingItemData, true);
                CursorItemHolder.instance.EmptyItemData();
            }
        } else if (eventData.button == PointerEventData.InputButton.Middle) {
            if (cellItemData.itemType == AttrAndCharUtils.ItemType.Consumable) {
                // consume item
            }
        } else if (eventData.button == PointerEventData.InputButton.Right) {
            
        }
    }
    
    public void OnPointerEnter(PointerEventData eventData) {

        if (cellItemData != null) {
            UIManager.instance.ShowTooltip(transform.position, cellItemData);
        }
    }

    public void OnPointerExit(PointerEventData eventData) {

        UIManager.instance.HideTooltip();
    }


}
