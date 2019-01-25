using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemScript : InteractableScript {

    //public PickupAbleItemSerializeObject itemSerializedData;
    public PickupAbleItemData itemData;

    public int id;
    public SpriteRenderer spriteRenderer;

	// Use this for initialization
	void Start () {

        
	}

    public void FillItemData(PickupAbleItemData serializedData) {

        itemData = new PickupAbleItemData(serializedData);
        spriteRenderer.sprite = itemData.itemImage;
    }

    public override void Interact() {

        PickUp();
        base.Interact();
    }
    /*
    private void OnDrawGizmosSelected() {

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, 0.5f);
    }
    */
    private void PickUp() {

        //Debug.Log("Item " + itemSerializedData.name + " has been picked up.");

        InventoryScript.instance.AddItem(itemData);        
        Destroy(gameObject);
    }


}
