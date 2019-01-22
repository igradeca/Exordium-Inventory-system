using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentScript : MonoBehaviour {

    public GameObject equipmentPanel;
    public GameObject equipmentButton;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    public void ShowPanel() {

        if (equipmentPanel.activeSelf == true) {
            equipmentPanel.SetActive(false);
            equipmentButton.SetActive(true);

        } else {
            equipmentPanel.SetActive(true);
            equipmentButton.SetActive(false);
        }
    }


}
