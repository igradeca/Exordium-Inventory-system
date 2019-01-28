using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ItemCell : MonoBehaviour {

    public Text StackStatus;
    public Image CellImage;
    public Image BackGroundImage;

    public PickupAbleItemData CellItemData;

	// Use this for initialization
	void Awake () {

        CellImage = transform.GetChild(0).GetComponent<Image>();
        StackStatus = transform.GetChild(1).GetComponent<Text>();
    }

    public void UpdateCell(PickupAbleItemData itemData) {

        this.CellItemData = itemData;

        StackStatus.text = _updateStackInfo();
        CellImage.sprite = this.CellItemData.ItemImage;
        CellImage.color = Color.white;        
    }

    private string _updateStackInfo() {

        string stackText = "";
        if (CellItemData.MaxStack == int.MaxValue) {
            stackText = CellItemData.CurrentStack.ToString();
        } else if (CellItemData.MaxStack > 1) {
            stackText = CellItemData.CurrentStack.ToString() + "/" + CellItemData.MaxStack.ToString();
            BackGroundImage.color = new Color(
                1f,
                1f - (CellItemData.CurrentStack / (float)CellItemData.MaxStack),
                1f - (CellItemData.CurrentStack / (float)CellItemData.MaxStack),
                0.31f);
        } else {
            BackGroundImage.color = new Color(1f, 1f, 1f, 0.31f);
        }

        return stackText;
    }

    public void SetEmptyCell() {

        CellItemData = null;

        StackStatus.text = "";
        CellImage.sprite = null;
        CellImage.color = new Color(1f, 1f, 1f, 0f);
        BackGroundImage.color = new Color(1f, 1f, 1f, 0.31f);
    }

    public bool IsEmpty() {

        if (CellItemData == null) {
            return true;
        } else if (CellItemData.ItemId == 0) {
            return true;
        } else {
            return false;
        }
    }


}
