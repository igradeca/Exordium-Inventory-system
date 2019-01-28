using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Attributes : MonoBehaviour {

    public static Attributes instance;

    public GameObject attributesPanel;
    public GameObject AttributesInnerPanel;
    public GameObject attributesButton;

    public Text HealthAndManaText;
    public Text StatsText;

    public Attribute[] baseStats;
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

        baseStats = new Attribute[6];
        for (int i = 0; i < baseStats.Length; i++) {
            int rndVal = UnityEngine.Random.Range(10, 25);
            baseStats[i] = new Attribute((AttrAndCharUtils.AttributeType)i, rndVal);            
        }

        ResetStats();
    }

    private void Update() {

        
    }

    private void ResetStats() {

        currentStats = new Attribute[6];
        for (int i = 0; i < currentStats.Length; i++) {
            currentStats[i] = baseStats[i];
        }
    }

    private void BuffManager() {

        if (activeBuffs.Count == 0) {
            return;
        } else {
            InvokeRepeating("ApplyBuffs", 0f, 1f);
            ApplyBuffs();
        }
    }

    private void ApplyBuffs() {

        //Invoke()
        //CancelInvoke()
    }

    public void AddNewBuffs(Buff[] buffs) {

        for (int i = 0; i < buffs.Length; i++) {
            if (buffs[i].effect == AttrAndCharUtils.BuffType.Constant) {
                currentStats[(int)buffs[i].attribute].value += buffs[i].value;
            } else {
                // buffs with duration
            }
        }
    }

    public void UpdateEquippedBuffs(PickupAbleItemData[] equipedItems) {

        for (int i = 0; i < equipedItems.Length; i++) {
            if (equipedItems[i] != null && equipedItems[i].itemId != 0) {
                if (equipedItems[i].attributes.Length > 0) {
                    AddNewBuffs(equipedItems[i].attributes);
                }
            }
        }

        UpdateAttributePanel();
    }

    public void UpdateAttributePanel() {

        if (attributesPanel.activeSelf == false) {
            return;
        }

        string textToAdd = "";
        for (int i = 0; i < (currentStats.Length - 2); i++) {
            textToAdd += currentStats[i].attribute.ToString() + " " + currentStats[i].value + "\n";
        }
        StatsText.text = textToAdd;

        textToAdd = "";
        for (int i = (currentStats.Length - 2); i < currentStats.Length; i++) {
            textToAdd += currentStats[i].attribute.ToString() + " " + currentStats[i].value + "\n";
        }
        HealthAndManaText.text = textToAdd;
    }


    public void ShowPanel() {

        if (attributesPanel.activeSelf == true) {
            attributesPanel.SetActive(false);
            attributesButton.SetActive(true);
            UIManager.instance.PanelsClosed();
        } else {
            attributesPanel.SetActive(true);
            attributesButton.SetActive(false);
            UpdateAttributePanel();
        }
    }


}
