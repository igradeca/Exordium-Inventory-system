using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableScript : MonoBehaviour {

    
    public bool playerInProximity;

	// Use this for initialization
	void Start () {
                
        playerInProximity = false;
    }
	
	// Update is called once per frame
	void Update () {

        
	}

    public virtual void Interact() {

        InventoryScript.instance.UpdateInventoryGrid();
    }

    void OnTriggerEnter2D(Collider2D collision) {
        if (collision.tag == "Player") {
            playerInProximity = true;
            Interact();
        }
    }

    void OnTriggerExit2D(Collider2D collision) {
        if (collision.tag == "Player") {
            playerInProximity = false;
        }
    }


}
