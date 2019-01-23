using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemScript : InteractableScript {

    public PickupAbleItemScript itemData;

    public int id;
    public SpriteRenderer spriteRenderer;

	// Use this for initialization
	void Start () {

        spriteRenderer.sprite = itemData.itemImage;

	}

    public override void Interact() {
        base.Interact();

        PickUp();
    }
    /*
    private void OnDrawGizmosSelected() {

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, 0.5f);
    }
    */
    private void PickUp() {

        Debug.Log("Item " + itemData.name + " has been picked up.");

        InventoryScript.instance.AddItem(itemData);
        Destroy(gameObject);
    }


}
