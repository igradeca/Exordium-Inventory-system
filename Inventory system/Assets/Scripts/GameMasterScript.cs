using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMasterScript : MonoBehaviour {

    public static GameMasterScript Instance;
    public GameObject Player;

    void Awake() {

        if (Instance != null) {
            Debug.LogWarning("GameMasterScript instance already exist!");
            return;
        } else {
            Instance = this;
        }
    }


}
