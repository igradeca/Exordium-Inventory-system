using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventoryCellScript : MonoBehaviour {

    public Text stackStatus;
    public Image cellImage;
    public Image backGroundImage;

    public PickupAbleItemData itemData;
    public int itemIndex;

	// Use this for initialization
	void Awake () {

        cellImage = transform.GetChild(0).GetComponent<Image>();
        stackStatus = transform.GetChild(1).GetComponent<Text>();
    }

    public void UpdateCell(PickupAbleItemData itemData) {

        this.itemData = itemData;

        stackStatus.text = UpdateStackInfo();
        cellImage.sprite = this.itemData.itemImage;
        cellImage.color = Color.white;        
    }

    private string UpdateStackInfo() {

        string stackText = "";
        if (itemData.maxStack == int.MaxValue) {
            stackText = itemData.currentStack.ToString();
        } else if (itemData.maxStack > 1) {
            stackText = itemData.currentStack.ToString() + "/" + itemData.maxStack.ToString();
            backGroundImage.color = new Color(
                1f,
                1f - (itemData.currentStack / (float)itemData.maxStack),
                1f - (itemData.currentStack / (float)itemData.maxStack),
                0.31f);
        }

        return stackText;
    }


}
