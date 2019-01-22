using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryScript : MonoBehaviour {

    public GameObject inventoryPanel;
    public GameObject inventoryButton;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {


		
	}

    public void ShowPanel() {

        if (inventoryPanel.activeSelf == true) {
            inventoryPanel.SetActive(false);
            inventoryButton.SetActive(true);
            
        } else {
            inventoryPanel.SetActive(true);
            inventoryButton.SetActive(false);
        }
    }


}
