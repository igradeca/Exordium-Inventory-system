using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryCellScript : MonoBehaviour {

    public Text stackStatus;
    public Image cellImage;

    public PickupAbleItemData itemData;

	// Use this for initialization
	void Awake () {

        cellImage = transform.GetChild(0).GetComponent<Image>();
        stackStatus = transform.GetChild(1).GetComponent<Text>();
    }

    public void UpdateCell(PickupAbleItemData itemData) {

        this.itemData = itemData;
        
        string stackText = (itemData.maxStack > 1) ? 
            itemData.currentStack.ToString() + "/" + itemData.maxStack.ToString() :
            "";
        stackStatus.text = stackText;
        cellImage.sprite = this.itemData.itemImage;
        cellImage.color = Color.white;
        
    }

}
