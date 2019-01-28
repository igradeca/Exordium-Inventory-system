using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ItemCell : MonoBehaviour {

    public Text stackStatus;
    public Image cellImage;
    public Image backGroundImage;

    public PickupAbleItemData cellItemData;

	// Use this for initialization
	void Awake () {

        cellImage = transform.GetChild(0).GetComponent<Image>();
        stackStatus = transform.GetChild(1).GetComponent<Text>();
    }

    public void UpdateCell(PickupAbleItemData itemData) {

        this.cellItemData = itemData;

        stackStatus.text = UpdateStackInfo();
        cellImage.sprite = this.cellItemData.itemImage;
        cellImage.color = Color.white;        
    }

    private string UpdateStackInfo() {

        string stackText = "";
        if (cellItemData.maxStack == int.MaxValue) {
            stackText = cellItemData.currentStack.ToString();
        } else if (cellItemData.maxStack > 1) {
            stackText = cellItemData.currentStack.ToString() + "/" + cellItemData.maxStack.ToString();
            backGroundImage.color = new Color(
                1f,
                1f - (cellItemData.currentStack / (float)cellItemData.maxStack),
                1f - (cellItemData.currentStack / (float)cellItemData.maxStack),
                0.31f);
        } else {
            backGroundImage.color = new Color(1f, 1f, 1f, 0.31f);
        }

        return stackText;
    }

    public void SetEmptyCell() {

        cellItemData = null;

        stackStatus.text = "";
        cellImage.sprite = null;
        cellImage.color = new Color(1f, 1f, 1f, 0f);
        backGroundImage.color = new Color(1f, 1f, 1f, 0.31f);
    }

    public bool IsEmpty() {

        if (cellItemData == null) {
            return true;
        } else if (cellItemData.itemId == 0) {
            return true;
        } else {
            return false;
        }
    }


}
