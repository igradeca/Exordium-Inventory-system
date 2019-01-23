using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryScript : MonoBehaviour {

    public static InventoryScript instance;

    public GameObject inventoryPanel;
    public GameObject inventoryContentList;
    public GameObject inventoryButton;
    public GameObject inventoryItemCell;

    public List<PickupAbleItemScript> inventoryList;

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

        inventoryList = new List<PickupAbleItemScript>();
        Object cell = Instantiate(inventoryItemCell, inventoryContentList.transform, true);
    }
	
	// Update is called once per frame
	void Update () {

        		
	}

    public void AddItem(PickupAbleItemScript item) {

        if (item.maxStack > 1) {
            _AddToExistingElement(item);
        } else {
            inventoryList.Add(item);
        }
    }

    private void _AddToExistingElement(PickupAbleItemScript item) {

        for (int i = 0; i < inventoryList.Count; i++) {
            if (inventoryList[i].name == item.name && inventoryList[i].currentStack < item.maxStack) {
                if (inventoryList[i].currentStack + item.currentStack > item.maxStack) {
                    item.currentStack -= item.maxStack - inventoryList[i].currentStack;                    
                } else {
                    inventoryList[i].currentStack += item.currentStack;
                    return;
                }
            }
        }

        // If there is no such stacked item or there is some of them left, add a new one.
        inventoryList.Add(item);
    }    

    public void RemoveItem(PickupAbleItemScript item) {

        if (item.maxStack > 1) {
            // stacking code goes here
        } else {
            inventoryList.Remove(item);
        }
    }

    public void UpdateInventoryGrid() {

        if (inventoryList.Count != inventoryContentList.transform.childCount) {
            Debug.Log("b1");
            foreach (Transform child in inventoryContentList.transform) {
                Destroy(child.gameObject);
            }

            for (int i = 0; i < inventoryList.Count; i++) {
                Object cell = Instantiate(inventoryItemCell, inventoryContentList.transform, true);
            }
            //Instantiate(inventoryItemCell, inventoryContentList.transform, true);

        } else {
            for (int i = 0; i < inventoryContentList.transform.childCount; i++) {

                string stackStatus = (inventoryList[i].maxStack == 1) ? "" : inventoryList[i].currentStack + "/" + inventoryList[i].maxStack;
                inventoryContentList.transform.GetChild(i).GetComponent<InventoryCellScript>().UpdateCell(stackStatus, inventoryList[i].itemImage);
            }
            
        }

    }

    public void ShowPanel() {

        if (inventoryPanel.activeSelf == true) {
            inventoryPanel.SetActive(false);
            inventoryButton.SetActive(true);
            
        } else {
            inventoryPanel.SetActive(true);
            inventoryButton.SetActive(false);
        }
    }


}
