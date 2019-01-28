using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Equipment : MonoBehaviour {

    public static Equipment instance;

    public GameObject equipmentPanel;
    public GameObject equipmentUIList;
    public GameObject equipmentButton;

    public PickupAbleItemData[] equipedItems;

    void Awake() {

        if (instance != null) {
            Debug.LogWarning("Equipment instance already exist!");
            return;
        } else {
            instance = this;
        }
    }

    public void RemoveAndUpdateGrid(AttrAndCharUtils.ItemType itemType) {

        Remove(itemType);
        UpdateEquipmentGrid();
    }

    public void AddAndUpdateGrid(PickupAbleItemData item) {

        Add(item);
        UpdateEquipmentGrid();
    }

    public void Add(PickupAbleItemData itemData) {

        switch (itemData.itemType) {
            case AttrAndCharUtils.ItemType.Head:
                equipedItems[(int)AttrAndCharUtils.ItemType.Head] = itemData;
                break;
            case AttrAndCharUtils.ItemType.Armor:
                equipedItems[(int)AttrAndCharUtils.ItemType.Armor] = itemData;
                break;
            case AttrAndCharUtils.ItemType.Boots:
                equipedItems[(int)AttrAndCharUtils.ItemType.Boots] = itemData;
                break;
            case AttrAndCharUtils.ItemType.Weapon:
                equipedItems[(int)AttrAndCharUtils.ItemType.Weapon] = itemData;
                break;
        }
    }

    public void Remove(AttrAndCharUtils.ItemType itemType) {

        switch (itemType) {
            case AttrAndCharUtils.ItemType.Head:
                equipedItems[(int)AttrAndCharUtils.ItemType.Head] = new PickupAbleItemData();
                break;
            case AttrAndCharUtils.ItemType.Armor:
                equipedItems[(int)AttrAndCharUtils.ItemType.Armor] = new PickupAbleItemData();
                break;
            case AttrAndCharUtils.ItemType.Boots:
                equipedItems[(int)AttrAndCharUtils.ItemType.Boots] = new PickupAbleItemData();
                break;
            case AttrAndCharUtils.ItemType.Weapon:
                equipedItems[(int)AttrAndCharUtils.ItemType.Weapon] = new PickupAbleItemData();
                break;
        }
    }

    //
    // This function needs to be changed. It is too chaotic right now.
    //
    public void UpdateEquipmentGrid() {

        if (equipmentPanel.activeSelf == false) {
            return;
        }

        ItemCell[] cells = equipmentUIList.GetComponentsInChildren<ItemCell>();
        for (int i = 0; i < equipedItems.Length; i++) {
            if (equipedItems[i].itemId == 0) {
                cells[i].SetEmptyCell();
            } else {
                cells[i].UpdateCell(equipedItems[i]);
            }
        }
    }

    public void ShowPanel() {

        if (equipmentPanel.activeSelf == true) {
            equipmentPanel.SetActive(false);
            equipmentButton.SetActive(true);
            UIManager.instance.PanelsClosed();
        } else {
            equipmentPanel.SetActive(true);
            equipmentButton.SetActive(false);
            UpdateEquipmentGrid();
        }
    }


}
