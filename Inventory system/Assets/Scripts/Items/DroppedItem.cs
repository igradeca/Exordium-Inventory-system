using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Script used for dropped items in the scene.
/// </summary>
public class DroppedItem : ItemInteraction {

    public PickupAbleItemData itemData;

    public int itemId;
    public SpriteRenderer spriteRenderer;

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

        if (ItemToEquip()) {
            Equipment.instance.Add(itemData);
        } else {
            Inventory.instance.Add(itemData, false);
        }
        Destroy(gameObject);
    }

    private bool ItemToEquip() {

        if ((int)itemData.itemType < 4 && Equipment.instance.IsSlotEmpty(itemData.itemType)) {
            return true;
        } else {
            return false;
        }
    }


}
