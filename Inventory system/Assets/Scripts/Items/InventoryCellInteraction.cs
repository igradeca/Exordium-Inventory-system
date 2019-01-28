using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InventoryCellInteraction : ItemCell, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler {
    // Debug.Log("");
    public void OnPointerClick(PointerEventData eventData) {

        if (eventData.button == PointerEventData.InputButton.Left && UIManager.Instance.LeftControlKeyPressed) {
            if (!this.IsEmpty()) {
                ItemSpawnerScript.Instance.Spawn(CellItemData, GameMasterScript.Instance.Player.transform.position);
                Inventory.Instance.RemoveAndUpdateGrid(CellItemData);
            }
        } else if (eventData.button == PointerEventData.InputButton.Left && UIManager.Instance.LeftShiftKeyPressed) {
            if (!this.IsEmpty()) {
                if (CellItemData.CurrentStack > 1 && CellItemData.MaxStack > 1) {
                    UIManager.Instance.ShowSplitPanel();
                    SplitPanelScript.Instance.SetPanel(CellItemData);
                }
            }
        } else if (eventData.button == PointerEventData.InputButton.Left) {
            if (!this.IsEmpty()) {
                if (CursorItemHolder.Instance.CursorHolderIsEmpty()) {
                    CursorItemHolder.Instance.AddItemDataToCursor(CellItemData);
                    //Debug.Log("empty");
                } else {
                    bool newStack = CursorItemHolder.Instance.HoldingItemData.Name == CellItemData.Name ? false : true;
                    Inventory.Instance.AddAndUpdateGrid(CursorItemHolder.Instance.HoldingItemData, newStack);
                    CursorItemHolder.Instance.AddItemDataToCursor(CellItemData);
                    //Debug.Log("NOT empty");
                }
                Inventory.Instance.RemoveAndUpdateGrid(CellItemData);
            } else if (this.IsEmpty() && !CursorItemHolder.Instance.CursorHolderIsEmpty()) {
                Inventory.Instance.AddAndUpdateGrid(CursorItemHolder.Instance.HoldingItemData, true);
                CursorItemHolder.Instance.EmptyItemData();
            }
        } else if (eventData.button == PointerEventData.InputButton.Middle) {
            if (CellItemData.ItemType == AttrAndCharUtils.ItemType.Consumable) {
                // consume item
                Attributes.Instance.AddNewBuffs(CellItemData.Attributes);
                Inventory.Instance.RemoveAndUpdateGrid(CellItemData);
                Debug.Log("Item consumed");
            }
        } else if (eventData.button == PointerEventData.InputButton.Right) {
            if (!this.IsEmpty() && (int)CellItemData.ItemType < 4) {
                if (Equipment.Instance.IsSlotEmpty(CellItemData.ItemType)) {
                    Equipment.Instance.AddAndUpdateGrid(CellItemData);
                    Inventory.Instance.RemoveAndUpdateGrid(CellItemData);
                } else {
                    Inventory.Instance.Add(Equipment.Instance.EquipedItems[(int)CellItemData.ItemType], true);
                    Equipment.Instance.AddAndUpdateGrid(CellItemData);
                    Inventory.Instance.RemoveAndUpdateGrid(CellItemData);
                }
            }
        }
    }
    
    public void OnPointerEnter(PointerEventData eventData) {

        if (!this.IsEmpty()) {
            UIManager.Instance.ShowTooltip(transform.position, CellItemData);
        }
    }

    public void OnPointerExit(PointerEventData eventData) {

        UIManager.Instance.HideTooltip();
    }


}
