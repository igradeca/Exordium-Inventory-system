using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryCellScript : MonoBehaviour {

    public Text stackStatus;
    public Image cellImage;

    public PickupAbleItemData itemData;
    public int itemIndex;

	// Use this for initialization
	void Awake () {

        cellImage = transform.GetChild(0).GetComponent<Image>();
        stackStatus = transform.GetChild(1).GetComponent<Text>();
    }

    public void UpdateCell(PickupAbleItemData itemData) {

        //this.itemIndex = itemIndex;
        this.itemData = itemData;

        string stackText = "";
        if (itemData.maxStack > 1) {
            stackText = itemData.currentStack.ToString() + "/" + itemData.maxStack.ToString();
        } else if (itemData.maxStack == -1) {
            stackText = itemData.currentStack.ToString();
        }

        stackStatus.text = stackText;
        cellImage.sprite = this.itemData.itemImage;
        cellImage.color = Color.white;
        
    }

}
