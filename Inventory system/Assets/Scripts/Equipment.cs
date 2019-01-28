using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Equipment : MonoBehaviour {

    public static Equipment instance;

    public GameObject equipmentPanel;
    public GameObject equipmentUIList;
    public GameObject equipmentButton;

    void Awake() {

        if (instance != null) {
            Debug.LogWarning("Equipment instance already exist!");
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
}
