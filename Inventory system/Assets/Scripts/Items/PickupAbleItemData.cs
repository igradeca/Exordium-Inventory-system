﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PickupAbleItemData : ItemData {

    public int itemId = 0;

	public int maxDurability = 100;
    public int currentDurability = 100;

    public int maxStack = 1;
    public int currentStack = 1;
    
    public PickupAbleItemData() {}
    
    public PickupAbleItemData(PickupAbleItemData data, int newItemId) {

        this.itemId = newItemId;

        this.name = data.name;
        this.itemType = data.itemType;

        this.itemImageName = data.itemImageName;
        this.itemImage = data.itemImage;

        this.maxDurability = data.maxDurability;
        this.currentDurability = data.currentDurability;

        this.maxStack = data.maxStack;
        this.currentStack = data.currentStack;

        this.attributes = data.attributes;
    }


}
