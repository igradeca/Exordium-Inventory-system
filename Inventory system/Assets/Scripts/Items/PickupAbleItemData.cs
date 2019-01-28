using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PickupAbleItemData : ItemData {

    public int ItemId = 0;

	public int MaxDurability = 100;
    public int CurrentDurability = 100;

    public int MaxStack = 1;
    public int CurrentStack = 1;
    
    public PickupAbleItemData() {}
    
    public PickupAbleItemData(PickupAbleItemData data, int newItemId) {

        this.ItemId = newItemId;

        this.Name = data.Name;
        this.ItemType = data.ItemType;

        this.ItemImageName = data.ItemImageName;
        this.ItemImage = data.ItemImage;

        this.MaxDurability = data.MaxDurability;
        this.CurrentDurability = data.CurrentDurability;

        this.MaxStack = data.MaxStack;
        this.CurrentStack = data.CurrentStack;

        this.Attributes = data.Attributes;
    }


}
