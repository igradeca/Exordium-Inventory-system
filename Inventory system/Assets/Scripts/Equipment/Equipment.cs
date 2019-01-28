using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Equipment : MonoBehaviour {

    public static Equipment Instance;

    public GameObject EquipmentPanel;
    public GameObject EquipmentUIList;
    public GameObject EquipmentButton;

    public PickupAbleItemData[] EquipedItems;

    void Awake() {

        if (Instance != null) {
            Debug.LogWarning("Equipment instance already exist!");
            return;
        } else {
            Instance = this;
        }
    }

    public void RemoveAndUpdateGrid(AttrAndCharUtils.ItemType itemType) {

        Remove(itemType);
        UpdateEquipmentGrid();
    }

    public void AddAndUpdateGrid(PickupAbleItemData item) {

        Add(item);
        UpdateEquipmentGrid();
        Attributes.Instance.UpdateEquippedBuffs(EquipedItems);
    }

    public void Add(PickupAbleItemData itemData) {

        switch (itemData.ItemType) {
            case AttrAndCharUtils.ItemType.Head:
                EquipedItems[(int)AttrAndCharUtils.ItemType.Head] = itemData;
                break;
            case AttrAndCharUtils.ItemType.Armor:
                EquipedItems[(int)AttrAndCharUtils.ItemType.Armor] = itemData;
                break;
            case AttrAndCharUtils.ItemType.Boots:
                EquipedItems[(int)AttrAndCharUtils.ItemType.Boots] = itemData;
                break;
            case AttrAndCharUtils.ItemType.Weapon:
                EquipedItems[(int)AttrAndCharUtils.ItemType.Weapon] = itemData;
                break;
        }
    }

    public void Remove(AttrAndCharUtils.ItemType itemType) {

        switch (itemType) {
            case AttrAndCharUtils.ItemType.Head:
                EquipedItems[(int)AttrAndCharUtils.ItemType.Head] = new PickupAbleItemData();
                break;
            case AttrAndCharUtils.ItemType.Armor:
                EquipedItems[(int)AttrAndCharUtils.ItemType.Armor] = new PickupAbleItemData();
                break;
            case AttrAndCharUtils.ItemType.Boots:
                EquipedItems[(int)AttrAndCharUtils.ItemType.Boots] = new PickupAbleItemData();
                break;
            case AttrAndCharUtils.ItemType.Weapon:
                EquipedItems[(int)AttrAndCharUtils.ItemType.Weapon] = new PickupAbleItemData();
                break;
        }
    }

    public void UpdateEquipmentGrid() {

        if (EquipmentPanel.activeSelf == false) {
            return;
        }

        ItemCell[] cells = EquipmentUIList.GetComponentsInChildren<ItemCell>();
        for (int i = 0; i < EquipedItems.Length; i++) {
            if (EquipedItems[i].ItemId == 0) {
                cells[i].SetEmptyCell();
            } else {
                cells[i].UpdateCell(EquipedItems[i]);
            }
        }
    }

    public bool IsSlotEmpty(AttrAndCharUtils.ItemType slotType) {

        if (EquipedItems[(int)slotType].ItemId == 0) {
            return true;
        } else {
            return false;
        }
    }

    public void ShowPanel() {

        if (EquipmentPanel.activeSelf == true) {
            EquipmentPanel.SetActive(false);
            EquipmentButton.SetActive(true);
            UIManager.Instance.PanelsClosed();
        } else {
            EquipmentPanel.SetActive(true);
            EquipmentButton.SetActive(false);
            UpdateEquipmentGrid();
        }
    }


}
