using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Script used for dropped items in the scene.
/// </summary>
public class DroppedItem : ItemInteraction {

    public PickupAbleItemData ItemData;

    public int ItemId;
    public SpriteRenderer SpriteRenderer;

    public void FillItemData(PickupAbleItemData serializedData, int newItemId) {

        ItemId = newItemId;
        ItemData = new PickupAbleItemData(serializedData, ItemId);
        SpriteRenderer.sprite = ItemData.ItemImage;
    }

    public override void Interact() {

        _pickUp();
        base.Interact();
    }

    private void _pickUp() {

        if (_itemToEquip()) {
            Equipment.Instance.Add(ItemData);
        } else {
            Inventory.Instance.Add(ItemData, false);
        }
        Destroy(gameObject);
    }

    private bool _itemToEquip() {

        if ((int)ItemData.ItemType < 4 && Equipment.Instance.IsSlotEmpty(ItemData.ItemType)) {
            return true;
        } else {
            return false;
        }
    }


}
