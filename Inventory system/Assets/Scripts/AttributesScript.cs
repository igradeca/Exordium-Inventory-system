using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttributesScript : MonoBehaviour {

    public static AttributesScript instance;

    public GameObject attributesPanel;
    public GameObject attributesButton;

    // Use this for initialization
    void Start() {

        if (instance != null) {
            Debug.LogWarning("This instance already exist!");
            return;
        } else {
            instance = this;
        }
    }

    // Update is called once per frame
    void Update() {



    }

    public void ShowPanel() {

        if (attributesPanel.activeSelf == true) {
            attributesPanel.SetActive(false);
            attributesButton.SetActive(true);
            UIManager.instance.PanelsClosed();
        } else {
            attributesPanel.SetActive(true);
            attributesButton.SetActive(false);
        }
    }


}
