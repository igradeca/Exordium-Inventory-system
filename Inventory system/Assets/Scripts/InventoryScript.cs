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
                } else {
                    inventoryList[i].currentStack += itemData.currentStack;
                    itemData.currentStack = 0;
                    return;
                }
            }
        }
    }

    public void RemoveItem(PickupAbleItemData itemData) {

        if (itemData.maxStack > 1) {
            // stacking code goes here
        } else {
            inventoryList.Remove(itemData);
        }
    }

    public void UpdateInventoryGrid() {

        if (inventoryPanel.activeSelf == false) {
            return;
        }

        if (inventoryUIList.transform.childCount == 0) {
            InstantiateEmptyCells(5);
        }

        InventoryCellScript[] cells = inventoryUIList.GetComponentsInChildren<InventoryCellScript>();

        for (int i = 0; i < inventoryList.Count; i++) {
            if (cells.Length <= i) {
                InstantiateEmptyCells(5);
                cells = inventoryUIList.GetComponentsInChildren<InventoryCellScript>();
            }
            cells[i].UpdateCell(inventoryList[i]);
        }

        if (inventoryList.Count < cells.Length && inventoryList.Count > 0 && (inventoryList.Count % 5) == 0) {
            DestroyEmptyCells(5);
        }
    }

    private void InstantiateEmptyCells(int cellsNumber = 1) {

        for (int i = 0; i < cellsNumber; i++) {
            _cell = Instantiate(inventoryItemCell, inventoryUIList.transform, false);
            _cell.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        }
    }

    private void DestroyEmptyCells(int cellsNumber) {

        int cellsCount = inventoryUIList.transform.childCount;
        for (int i = cellsCount; i >= cellsNumber; i--) {
            Destroy(inventoryUIList.transform.GetChild(i));
        }
    }

    public void ShowPanel() {

        if (inventoryPanel.activeSelf == true) {
            inventoryPanel.SetActive(false);
            inventoryButton.SetActive(true);
            
        } else {
            inventoryPanel.SetActive(true);
            inventoryButton.SetActive(false);
            UpdateInventoryGrid();
        }
    }


}
