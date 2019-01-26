using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentScript : MonoBehaviour {

    public static EquipmentScript instance;

    public GameObject equipmentPanel;
    public GameObject equipmentButton;

    void Awake() {

        if (instance != null) {
            Debug.LogWarning("This instance already exist!");
            return;
        } else {
            instance = this;
        }
    }

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
            UIManager.instance.PanelsClosed();
        } else {
            equipmentPanel.SetActive(true);
            equipmentButton.SetActive(false);
        }
    }


}
