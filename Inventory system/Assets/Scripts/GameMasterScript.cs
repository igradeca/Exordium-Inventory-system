using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMasterScript : MonoBehaviour {

    public static GameMasterScript instance;

    public GameObject player;

    void Awake() {

        if (instance != null) {
            Debug.LogWarning("GameMasterScript instance already exist!");
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
