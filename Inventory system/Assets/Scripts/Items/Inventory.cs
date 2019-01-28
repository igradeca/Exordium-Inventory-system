using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour {

    public static Inventory Instance;

    public readonly int GridRowLength = 5;
    public GameObject InventoryPanel;
    public GameObject InventoryUIList;
    public GameObject InventoryButton;

    public GameObject EmptyInventoryItemCell;
    private GameObject _cell;
    
    public List<PickupAbleItemData> InventoryList;

    void Awake() {

        if (Instance != null) {
            Debug.LogWarning("Inventory instance already exist!");
            return;
        } else {
            Instance = this;
        }
    }

    // Use this for initialization
    void Start () {

        InventoryList = new List<PickupAbleItemData>();
    }

    public void AddAndUpdateGrid(PickupAbleItemData item, bool newStack) {

        Add(item, newStack);
        UpdateInventoryGrid();
    }

    public void RemoveAndUpdateGrid(PickupAbleItemData item) {

        Remove(item.ItemId);
        UpdateInventoryGrid();
    }

    public void Add(PickupAbleItemData itemData, bool newStack) {

        if (newStack == false && (itemData.MaxStack >= 2 || itemData.MaxStack == int.MaxValue)) {
            _addToExistingElement(itemData);
        }
        
        if (itemData.CurrentStack > 0) {
            // If there is no such stacked item or there is some of them left, add a new one.
            InventoryList.Add(itemData);
        }
    }
    
    private void _addToExistingElement(PickupAbleItemData itemData) {

        for (int i = 0; i < InventoryList.Count; i++) {
            if (InventoryList[i].Name == itemData.Name && 
                (InventoryList[i].CurrentStack < itemData.MaxStack || itemData.MaxStack == int.MaxValue)) {

                if ((InventoryList[i].CurrentStack + itemData.CurrentStack) > itemData.MaxStack && itemData.MaxStack != int.MaxValue) {
                    itemData.CurrentStack -= itemData.MaxStack - InventoryList[i].CurrentStack;
                    InventoryList[i].CurrentStack = itemData.MaxStack;
                } else {
                    InventoryList[i].CurrentStack += itemData.CurrentStack;
                    itemData.CurrentStack = 0;
                    return;
                }
            }
        }
    }

    public void Remove(int itemId) {

        for (int i = 0; i < InventoryList.Count; i++) {
            if (InventoryList[i].ItemId == itemId) {
                InventoryList.RemoveAt(i);
            }
        }
    }

    public void UpdateInventoryGrid() {

        if (InventoryPanel.activeSelf == false) {
            return;
        }

        if (InventoryUIList.transform.childCount == 0) {
            _instantiateNewEmptyCells(5);
        }

        ItemCell[] cells = InventoryUIList.GetComponentsInChildren<ItemCell>();
        for (int i = 0; i < InventoryList.Count; i++) {
            if (cells.Length <= i + 1) {
                _instantiateNewEmptyCells(5);
                cells = InventoryUIList.GetComponentsInChildren<ItemCell>();
            }
            cells[i].UpdateCell(InventoryList[i]);
        }
        
        if (cells.Length > InventoryList.Count) {
            for (int i = InventoryList.Count; i < cells.Length; i++) {
                cells[i].SetEmptyCell();
            }
        }

        if (InventoryList.Count + 5 < cells.Length && InventoryList.Count > 0) {
            _destroyEmptyCells(5);
        }

    }

    private void _instantiateNewEmptyCells(int cellsNumber = 1) {

        for (int i = 0; i < cellsNumber; i++) {
            _cell = Instantiate(EmptyInventoryItemCell, InventoryUIList.transform, false);
            _cell.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        }
    }

    private void _destroyEmptyCells(int cellsNumber) {

        int cellsCount = InventoryUIList.transform.childCount;
        for (int i = (cellsCount - 1), j = cellsNumber; i >= 0 && j > 0; i--, j--) {
            Destroy(InventoryUIList.transform.GetChild(i).gameObject);
        }
    }

    public void ShowPanel() {

        if (InventoryPanel.activeSelf == true) {
            InventoryPanel.SetActive(false);
            InventoryButton.SetActive(true);
            UIManager.Instance.PanelsClosed();
        } else {
            InventoryPanel.SetActive(true);
            InventoryButton.SetActive(false);
            UpdateInventoryGrid();
        }
    }


}
