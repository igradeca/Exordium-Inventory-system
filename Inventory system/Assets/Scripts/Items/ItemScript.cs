using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemScript : InteractableScript {

    //public PickupAbleItemSerializeObject itemSerializedData;
    public PickupAbleItemData itemData;

    public int itemId;
    public SpriteRenderer spriteRenderer;

	// Use this for initialization
	void Start () {

        
	}

    public void FillItemData(PickupAbleItemData serializedData, int newItemId) {

        itemId = newItemId;
        itemData = new PickupAbleItemData(serializedData, itemId);
        spriteRenderer.sprite = itemData.itemImage;
    }

    public override void Interact() {

        PickUp();
        base.Interact();
    }

    private void PickUp() {

        //Debug.Log("Item " + itemSerializedData.name + " has been picked up.");

        InventoryScript.instance.Add(itemData);        
        Destroy(gameObject);
    }


}
