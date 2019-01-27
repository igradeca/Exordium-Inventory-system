using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemInteraction : MonoBehaviour {

    public bool playerInProximity;

	// Use this for initialization
	void Start () {
                
        playerInProximity = false;
    }
    
    void OnMouseDown() {

        if (Input.GetMouseButtonDown(0) && playerInProximity == true) {
            Interact();
        }
    }

    public virtual void Interact() {

        Inventory.instance.UpdateInventoryGrid();
    }

    void OnTriggerEnter2D(Collider2D collision) {
        if (collision.tag == "Player") {
            playerInProximity = true;
        }
    }

    void OnTriggerExit2D(Collider2D collision) {
        if (collision.tag == "Player") {
            playerInProximity = false;
        }
    }


}
