using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SplitPanelScript : MonoBehaviour {

    public static SplitPanelScript Instance;

    public PickupAbleItemData ItemToSplit;

    public Text StackValueDisplay;
    public Slider StackSlider;

    void Awake() {

        if (Instance != null) {
            Debug.LogWarning("Inventory instance already exist!");
            return;
        } else {
            Instance = this;
        }
    }

    public void SetPanel(PickupAbleItemData itemData) {

        ItemToSplit = itemData;

        StackSlider.maxValue = ItemToSplit.CurrentStack - 1;
        StackSlider.value = 1;
        RefreshTextValue();
    }

    public void RefreshTextValue() {

        StackValueDisplay.text = StackSlider.value.ToString();
    } 

    public void CreateNewStack() {

        ItemToSplit.CurrentStack -= (int)StackSlider.value;
        PickupAbleItemData newItem = new PickupAbleItemData(ItemToSplit, ItemSpawnerScript.Instance.newItemId);
        newItem.CurrentStack = (int)StackSlider.value;

        Inventory.Instance.Add(newItem, true);
        Inventory.Instance.UpdateInventoryGrid();

        UIManager.Instance.HideSplitPanel();
    }

    public void CancelStacking() {

        UIManager.Instance.HideSplitPanel();
    }


}
