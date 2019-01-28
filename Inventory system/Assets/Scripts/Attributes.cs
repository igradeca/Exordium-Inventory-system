using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attributes : MonoBehaviour {

    public static Attributes instance;

    public GameObject attributesPanel;
    public GameObject attributesButton;

    public readonly Attribute[] baseStats;
    public Attribute[] currentStats;

    public List<Buff> activeBuffs;

    void Awake() {

        if (instance != null) {
            Debug.LogWarning("Attributes instance already exist!");
            return;
        } else {
            instance = this;
        }
    }

    // Use this for initialization
    void Start() {


    }

    private void Update() {

        
    }

    private void BuffManager() {

        if (activeBuffs.Count == 0) {
            return;
        } else {
            ApplyBuffs();
        }

    }

    private void ApplyBuffs() {

    }

    public void AddNewBuffs(Buff[] buffs) {


        //CancelInvoke()
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
