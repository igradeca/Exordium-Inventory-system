using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InteractableScript : MonoBehaviour {
        
    public bool playerInProximity;

	// Use this for initialization
	void Start () {
                
        playerInProximity = false;
    }
	
	// Update is called once per frame
	void Update () {

        
	}
    
    void OnMouseDown() {

        if (Input.GetMouseButtonDown(0) && playerInProximity == true) {
            //Debug.Log("left click");
            Interact();
        }
    }

    public virtual void Interact() {

        InventoryScript.instance.UpdateInventoryGrid();
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
