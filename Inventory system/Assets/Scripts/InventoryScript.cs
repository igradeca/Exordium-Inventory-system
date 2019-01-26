using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryScript : MonoBehaviour {

    public static InventoryScript instance;

    public readonly int gridRowLength = 5;
    public GameObject inventoryPanel;
    public GameObject inventoryUIList;
    public GameObject inventoryButton;

    public GameObject inventoryItemCell;
    private GameObject _cell;
    
    public List<PickupAbleItemData> inventoryList;

    void Awake() {

        if (instance != null) {
            Debug.LogWarning("Inventory instance already exist!");
            return;
        } else {
            instance = this;
        }
    }

    // Use this for initialization
    void Start () {

        inventoryList = new List<PickupAbleItemData>();
    }

    public void DropItem(PickupAbleItemData item) {

        ItemSpawnerScript.instance.Spawn(GameMasterScript.instance.player.transform.position, item);
        Remove(item.itemId);
        UpdateInventoryGrid();
        UIManager.instance.DeactivateCursorItemInTheAir();
    }

    public void Add(PickupAbleItemData itemData) {

        if (itemData.maxStack >= 2 || itemData.maxStack == int.MaxValue) {
            _AddToExistingElement(itemData);
        }
        
        if (itemData.currentStack > 0) {
            // If there is no such stacked item or there is some of them left, add a new one.
            inventoryList.Add(itemData);
        }
    }
    
    private void _AddToExistingElement(PickupAbleItemData itemData) {

        for (int i = 0; i < inventoryList.Count; i++) {
            if (inventoryList[i].name == itemData.name && 
                (inventoryList[i].currentStack < itemData.maxStack || itemData.maxStack == int.MaxValue)) {

                if ((inventoryList[i].currentStack + itemData.currentStack) > itemData.maxStack && itemData.maxStack != int.MaxValue) {
                    itemData.currentStack -= itemData.maxStack - inventoryList[i].currentStack;
                    inventoryList[i].currentStack = itemData.maxStack;
                } else {
                    inventoryList[i].currentStack += itemData.currentStack;
                    itemData.currentStack = 0;
                    return;
                }
            }
        }
    }

    public void Remove(int inventoryId) {

        RemoveItemByInventoryId(inventoryId);
        /*
        if (itemData.maxStack > 1) {
            // stacking code goes here
        } else {
            inventoryList.Remove(itemData);
        }
        */
    }

    private void RemoveItemByInventoryId(int inventoryId) {

        for (int i = 0; i < inventoryList.Count; i++) {
            if (inventoryList[i].itemId == inventoryId) {
                inventoryList.RemoveAt(i);
            }
        }
    }

    public void UpdateInventoryGrid() {

        if (inventoryPanel.activeSelf == false) {
            return;
        }

        if (inventoryUIList.transform.childCount == 0) {
            InstantiateNewEmptyCells(5);
        }

        InventoryCellScript[] cells = inventoryUIList.GetComponentsInChildren<InventoryCellScript>();
        for (int i = 0; i < inventoryList.Count; i++) {
            if (cells.Length <= i + 1) {
                InstantiateNewEmptyCells(5);
                cells = inventoryUIList.GetComponentsInChildren<InventoryCellScript>();
            }
            cells[i].UpdateCell(inventoryList[i]);
        }
        
        if (cells.Length > inventoryList.Count) {
            for (int i = inventoryList.Count; i < cells.Length; i++) {
                cells[i].SetEmptyCell();
            }
        }

        if (inventoryList.Count + 5 < cells.Length && inventoryList.Count > 0) {
            DestroyEmptyCells(5);
        }

    }

    private void InstantiateNewEmptyCells(int cellsNumber = 1) {

        for (int i = 0; i < cellsNumber; i++) {
            _cell = Instantiate(inventoryItemCell, inventoryUIList.transform, false);
            _cell.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        }
    }

    private void DestroyEmptyCells(int cellsNumber) {

        int cellsCount = inventoryUIList.transform.childCount;
        for (int i = (cellsCount - 1), j = cellsNumber; i >= 0 && j > 0; i--, j--) {
            Destroy(inventoryUIList.transform.GetChild(i).gameObject);
        }
    }

    public void ShowPanel() {

        if (inventoryPanel.activeSelf == true) {
            inventoryPanel.SetActive(false);
            inventoryButton.SetActive(true);
            UIManager.instance.PanelsClosed();
        } else {
            inventoryPanel.SetActive(true);
            inventoryButton.SetActive(false);
            UpdateInventoryGrid();
        }
    }


}
