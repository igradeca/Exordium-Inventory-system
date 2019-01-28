using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Attributes : MonoBehaviour {

    public static Attributes Instance;

    public GameObject AttributesPanel;
    public GameObject AttributesInnerPanel;
    public GameObject AttributesButton;

    public Text HealthAndManaText;
    public Text StatsText;

    public Attribute[] BaseStats;
    public Attribute[] CurrentStats;

    public List<Buff> ActiveBuffs;

    void Awake() {

        if (Instance != null) {
            Debug.LogWarning("Attributes instance already exist!");
            return;
        } else {
            Instance = this;
        }
    }

    // Use this for initialization
    void Start() {

        BaseStats = new Attribute[6];
        for (int i = 0; i < BaseStats.Length; i++) {
            int rndVal = UnityEngine.Random.Range(10, 25);
            BaseStats[i] = new Attribute((AttrAndCharUtils.AttributeType)i, rndVal);            
        }

        _resetStats();
    }

    private void _resetStats() {

        CurrentStats = new Attribute[6];
        for (int i = 0; i < CurrentStats.Length; i++) {
            CurrentStats[i] = BaseStats[i];
        }
    }

    private void _buffManager() {

        if (ActiveBuffs.Count == 0) {
            return;
        } else {
            InvokeRepeating("ApplyBuffs", 0f, 1f);
            _applyBuffs();
        }
    }

    private void _applyBuffs() {

        //Invoke()
        //CancelInvoke()
    }

    public void AddNewBuffs(Buff[] buffs) {

        for (int i = 0; i < buffs.Length; i++) {
            if (buffs[i].Effect == AttrAndCharUtils.BuffType.Constant) {
                CurrentStats[(int)buffs[i].AttributeType].Value += buffs[i].Value;
            } else {
                // buffs with duration
            }
        }
    }

    public void UpdateEquippedBuffs(PickupAbleItemData[] equipedItems) {

        for (int i = 0; i < equipedItems.Length; i++) {
            if (equipedItems[i] != null && equipedItems[i].ItemId != 0) {
                if (equipedItems[i].Attributes.Length > 0) {
                    AddNewBuffs(equipedItems[i].Attributes);
                }
            }
        }

        UpdateAttributePanel();
    }

    public void UpdateAttributePanel() {

        if (AttributesPanel.activeSelf == false) {
            return;
        }

        string textToAdd = "";
        for (int i = 0; i < (CurrentStats.Length - 2); i++) {
            textToAdd += CurrentStats[i].AttributeType.ToString() + " " + CurrentStats[i].Value + "\n";
        }
        StatsText.text = textToAdd;

        textToAdd = "";
        for (int i = (CurrentStats.Length - 2); i < CurrentStats.Length; i++) {
            textToAdd += CurrentStats[i].AttributeType.ToString() + " " + CurrentStats[i].Value + "\n";
        }
        HealthAndManaText.text = textToAdd;
    }


    public void ShowPanel() {

        if (AttributesPanel.activeSelf == true) {
            AttributesPanel.SetActive(false);
            AttributesButton.SetActive(true);
            UIManager.Instance.PanelsClosed();
        } else {
            AttributesPanel.SetActive(true);
            AttributesButton.SetActive(false);
            UpdateAttributePanel();
        }
    }


}
