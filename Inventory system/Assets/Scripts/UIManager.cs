using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

    public static UIManager Instance;

    public GameObject Tooltip;
    public GameObject SplitPanel;
    public GameObject CursorItemInTheAir;

    public bool LeftControlKeyPressed;
    public bool LeftShiftKeyPressed;

    void Awake() {

        if (Instance != null) {
            Debug.LogWarning("UIManager instance already exist!");
            return;
        } else {
            Instance = this;
        }
    }

    // Use this for initialization
    void Start () {		
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.C)) {
            Attributes.Instance.ShowPanel();
        }

        if (Input.GetKeyDown(KeyCode.E)) {
            Equipment.Instance.ShowPanel();
        }

        if (Input.GetKeyDown(KeyCode.I)) {
            Inventory.Instance.ShowPanel();
        }

        if (Input.GetKeyDown(KeyCode.LeftControl)) {
            LeftControlKeyPressed = true;
        } else if (Input.GetKeyUp(KeyCode.LeftControl)) {
            LeftControlKeyPressed = false;
        }

        if (Input.GetKeyDown(KeyCode.LeftShift)) {
            LeftShiftKeyPressed = true;
        } else if (Input.GetKeyUp(KeyCode.LeftShift)) {
            LeftShiftKeyPressed = false;
        }
    }

    public void PanelsClosed() {

        if (_allPanelsAreClosed()) {
            if (CursorItemInTheAir.activeSelf) {
                CursorItemHolder.Instance.EmptyItemData();
            }
            if (Tooltip.activeSelf) {
                HideTooltip();
            }
        }
    }

    private bool _allPanelsAreClosed() {

        if (!Attributes.Instance.AttributesPanel.activeSelf && 
            !Equipment.Instance.EquipmentPanel.activeSelf && 
            !Inventory.Instance.InventoryPanel.activeSelf) {
            return true;
        } else {
            return false;
        }
    }

    public void ShowTooltip(Vector2 position, PickupAbleItemData itemData) {

        Tooltip.SetActive(true);
        Tooltip.transform.position = position + new Vector2(-16f, 16f);

        string textToDisplay = itemData.Name + "\n" +
            " Type: " + itemData.ItemType.ToString();
        textToDisplay += _addAttributesStringToTooltip(itemData.Attributes);
        textToDisplay += _addDurabilityStringToTooltip(itemData.CurrentDurability, itemData.MaxDurability);

        Tooltip.transform.GetChild(0).GetComponent<Text>().text = textToDisplay;
    }

    private string _addAttributesStringToTooltip(Attribute[] attributes) {

        string attributesDisplay = "";

        if (attributes == null) {
            return attributesDisplay;
        }

        for (int i = 0; i < attributes.Length; i++) {

            attributesDisplay += "\n " + attributes[i].AttributeType.ToString() + " ";
            /*
            if (attributes[i].value != 0) {
                attributesDisplay += (attributes[i].value > 0) ? "+" : "";
                attributesDisplay +=  attributes[i].value.ToString();
            } else {
                attributesDisplay += (attributes[i].percentage > 0) ? "+" : "";
                attributesDisplay += (attributes[i].percentage * 100).ToString() + "%";
            }

            if (attributes[i].duration > 0) {
                attributesDisplay += " for " + attributes[i].duration.ToString() + " sec";
            }
            */
        }

        return attributesDisplay;
    }

    private string _addDurabilityStringToTooltip(int currentDurability, int maxDurability) {

        string durabilityDisplay = "";

        if (maxDurability > 1) {
            durabilityDisplay += "\n\n Durability: " + currentDurability.ToString() + "/" + maxDurability.ToString();
        }

        return durabilityDisplay;
    }

    public void HideTooltip() {

        Tooltip.SetActive(false);
    }

    public void ShowSplitPanel() {

        SplitPanel.SetActive(true);
    }

    public void HideSplitPanel() {

        SplitPanel.SetActive(false);
    }   


}
