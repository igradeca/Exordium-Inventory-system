using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Equipment : MonoBehaviour {

    public static Equipment instance;

    public GameObject equipmentPanel;
    public GameObject equipmentButton;

    public EquipmentCellInteraction[] equipmentSlots;

    public PickupAbleItemData test;

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

        for (int i = 0; i < equipmentSlots.Length; i++) {
            equipmentSlots[i].cellItemData = null;
        }
    }

    public void OnDrop(PickupAbleItemData item) {

        //Remove(item.itemId);
        //UpdateInventoryGrid();

        Debug.Log("You have entered Equip. OnDrop func.");
    }

    public void Add(PickupAbleItemData itemData) {

        switch (itemData.itemType) {
            case AttrAndCharUtils.ItemType.Head:
                equipmentSlots[0].UpdateCell(itemData);
                break;
            case AttrAndCharUtils.ItemType.Armor:
                equipmentSlots[1].UpdateCell(itemData);
                break;
            case AttrAndCharUtils.ItemType.Boots:
                equipmentSlots[2].UpdateCell(itemData);
                break;
            case AttrAndCharUtils.ItemType.Weapon:
                equipmentSlots[3].UpdateCell(itemData);
                break;
        }
    }

    public void UpdateGrid() {


    }


    public void ShowPanel() {

        if (equipmentPanel.activeSelf == true) {
            equipmentPanel.SetActive(false);
            equipmentButton.SetActive(true);
            UIManager.instance.PanelsClosed();
        } else {
            equipmentPanel.SetActive(true);
            equipmentButton.SetActive(false);
            UpdateGrid();
        }
    }


}
