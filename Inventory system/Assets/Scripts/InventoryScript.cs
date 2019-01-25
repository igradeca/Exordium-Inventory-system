using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryScript : MonoBehaviour {

    public static InventoryScript instance;

    public GameObject inventoryPanel;
    public GameObject inventoryUIList;
    public GameObject inventoryButton;

    public GameObject inventoryItemCell;

    public List<PickupAbleItemData> inventoryList;

    void Awake() {

        if (instance != null) {
            Debug.LogWarning("This instance already exist!");
            return;
        } else {
            instance = this;
        }
    }

    // Use this for initialization
    void Start () {

        inventoryList = new List<PickupAbleItemData>();
        GameObject cell = Instantiate(inventoryItemCell, inventoryUIList.transform, true);
        cell.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
    }

    public void AddItem(PickupAbleItemData itemData) {

        if (itemData.maxStack > 1) {
            _AddToExistingElement(itemData);
        }
        
        if (itemData.currentStack > 0) {
            // If there is no such stacked item or there is some of them left, add a new one.
            inventoryList.Add(itemData);
        }
    }

    private void _AddToExistingElement(PickupAbleItemData itemData) {

        for (int i = 0; i < inventoryList.Count; i++) {
            if (inventoryList[i].name == itemData.name && inventoryList[i].currentStack < itemData.maxStack) {

                if ((inventoryList[i].currentStack + itemData.currentStack) > itemData.maxStack) {
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

        foreach (Transform child in inventoryUIList.transform) {
            Destroy(child.gameObject);
        }

        GameObject cell;
        foreach (PickupAbleItemData item in inventoryList) {
            cell = Instantiate(inventoryItemCell, inventoryUIList.transform, false);
            cell.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
            cell.GetComponent<InventoryCellScript>().UpdateCell(item);
        }
        cell = Instantiate(inventoryItemCell, inventoryUIList.transform, false);
        cell.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
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
