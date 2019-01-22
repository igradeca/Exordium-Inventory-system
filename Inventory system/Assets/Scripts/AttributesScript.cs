using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttributesScript : MonoBehaviour {

    public GameObject attributesPanel;
    public GameObject attributesButton;

    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {



    }

    public void ShowPanel() {

        if (attributesPanel.activeSelf == true) {
            attributesPanel.SetActive(false);
            attributesButton.SetActive(true);

        } else {
            attributesPanel.SetActive(true);
            attributesButton.SetActive(false);
        }
    }


}
