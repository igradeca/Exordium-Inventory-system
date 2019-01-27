using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SplitPanelScript : MonoBehaviour {

    public static SplitPanelScript instance;

    public PickupAbleItemData itemToSplit;

    public Text stackValueDisplay;
    public Slider stackSlider;

    void Awake() {

        if (instance != null) {
            Debug.LogWarning("Inventory instance already exist!");
            return;
        } else {
            instance = this;
        }
    }

    public void SetPanel(PickupAbleItemData itemData) {

        itemToSplit = itemData;

        stackSlider.maxValue = itemToSplit.currentStack - 1;
        stackSlider.value = 1;
        RefreshTextValue();
    }

    public void RefreshTextValue() {

        stackValueDisplay.text = stackSlider.value.ToString();
    } 

    public void CreateNewStack() {

        itemToSplit.currentStack -= (int)stackSlider.value;
        PickupAbleItemData newItem = new PickupAbleItemData(itemToSplit, ItemSpawnerScript.instance.newItemId);
        newItem.currentStack = (int)stackSlider.value;

        Inventory.instance.Add(newItem, true);
        Inventory.instance.UpdateInventoryGrid();

        UIManager.instance.HideSplitPanel();
    }

    public void CancelStacking() {

        UIManager.instance.HideSplitPanel();
    }


}
