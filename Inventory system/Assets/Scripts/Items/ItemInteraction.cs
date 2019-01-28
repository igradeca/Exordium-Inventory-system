using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemInteraction : MonoBehaviour {

    public bool PlayerInProximity;

	// Use this for initialization
	void Start () {
                
        PlayerInProximity = false;
    }
    
    void OnMouseDown() {

        if (Input.GetMouseButtonDown(0) && PlayerInProximity == true) {
            Interact();
        }
    }

    public virtual void Interact() {

        Inventory.Instance.UpdateInventoryGrid();
    }

    void OnTriggerEnter2D(Collider2D collision) {
        if (collision.tag == "Player") {
            PlayerInProximity = true;
        }
    }

    void OnTriggerExit2D(Collider2D collision) {
        if (collision.tag == "Player") {
            PlayerInProximity = false;
        }
    }


}
