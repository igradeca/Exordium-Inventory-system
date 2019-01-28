using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class EquipmentCellInteraction : ItemCell, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler {
    // Debug.Log("");

    public AttrAndCharUtils.ItemType CellItemType;

    public void OnPointerClick(PointerEventData eventData) {

        if (!CursorItemHolder.Instance.CursorHolderIsEmpty() && CursorItemHolder.Instance.HoldingItemData.ItemType != CellItemType) {
            return;
        }

        _onLeftMouseClick(eventData);

        if (eventData.button == PointerEventData.InputButton.Right) {
            if (!this.IsEmpty()) {
                Inventory.Instance.AddAndUpdateGrid(CellItemData, true);
                Equipment.Instance.RemoveAndUpdateGrid(CellItemType);
            }            
        }
    }

    private void _onLeftMouseClick(PointerEventData eventData) {

        if (eventData.button == PointerEventData.InputButton.Left && UIManager.Instance.LeftControlKeyPressed) {
            if (!this.IsEmpty()) {
                ItemSpawnerScript.Instance.Spawn(CellItemData, GameMasterScript.Instance.Player.transform.position);
                Equipment.Instance.RemoveAndUpdateGrid(CellItemType);
            }
        } else if (eventData.button == PointerEventData.InputButton.Left) {
            if (!this.IsEmpty()) {
                if (CursorItemHolder.Instance.CursorHolderIsEmpty()) {
                    CursorItemHolder.Instance.AddItemDataToCursor(CellItemData);
                    Equipment.Instance.RemoveAndUpdateGrid(CellItemData.ItemType);
                    Debug.Log("cell is full, cursor is empty.");
                } else {
                    Equipment.Instance.Add(CursorItemHolder.Instance.HoldingItemData);
                    CursorItemHolder.Instance.AddItemDataToCursor(CellItemData);
                    Equipment.Instance.UpdateEquipmentGrid();
                    Debug.Log("cell is full, cursor is full.");
                }
            } else {
                if (!CursorItemHolder.Instance.CursorHolderIsEmpty()) {
                    Equipment.Instance.AddAndUpdateGrid(CursorItemHolder.Instance.HoldingItemData);
                    CursorItemHolder.Instance.EmptyItemData();
                    Debug.Log("cell is empty, cursor is full.");
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
