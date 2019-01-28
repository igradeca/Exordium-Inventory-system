using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

    public static UIManager instance;

    public GameObject tooltip;
    public GameObject splitPanel;
    public GameObject cursorItemInTheAir;

    public bool leftControlKeyPressed;
    public bool leftShiftKeyPressed;

    void Awake() {

        if (instance != null) {
            Debug.LogWarning("UIManager instance already exist!");
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

        if (Input.GetKeyDown(KeyCode.C)) {
            Attributes.instance.ShowPanel();
        }

        if (Input.GetKeyDown(KeyCode.E)) {
            Equipment.instance.ShowPanel();
        }

        if (Input.GetKeyDown(KeyCode.I)) {
            Inventory.instance.ShowPanel();
        }

        if (Input.GetKeyDown(KeyCode.LeftControl)) {
            leftControlKeyPressed = true;
        } else if (Input.GetKeyUp(KeyCode.LeftControl)) {
            leftControlKeyPressed = false;
        }

        if (Input.GetKeyDown(KeyCode.LeftShift)) {
            leftShiftKeyPressed = true;
        } else if (Input.GetKeyUp(KeyCode.LeftShift)) {
            leftShiftKeyPressed = false;
        }
    }

    public void PanelsClosed() {

        if (AllPanelsAreClosed()) {
            if (cursorItemInTheAir.activeSelf) {
                CursorItemHolder.instance.EmptyItemData();
            }
            if (tooltip.activeSelf) {
                HideTooltip();
            }
        }
    }

    private bool AllPanelsAreClosed() {

        if (!Attributes.instance.attributesPanel.activeSelf && 
            !Equipment.instance.equipmentPanel.activeSelf && 
            !Inventory.instance.inventoryPanel.activeSelf) {
            return true;
        } else {
            return false;
        }
    }

    public void ShowTooltip(Vector2 position, PickupAbleItemData itemData) {

        tooltip.SetActive(true);
        tooltip.transform.position = position + new Vector2(-16f, 16f);

        string textToDisplay = itemData.name + "\n" +
            " Type: " + itemData.itemType.ToString();
        textToDisplay += AddAttributesStringToTooltip(itemData.attributes);
        textToDisplay += AddDurabilityStringToTooltip(itemData.currentDurability, itemData.maxDurability);

        tooltip.transform.GetChild(0).GetComponent<Text>().text = textToDisplay;
    }

    private string AddAttributesStringToTooltip(Attribute[] attributes) {

        string attributesDisplay = "";

        if (attributes == null) {
            return attributesDisplay;
        }

        for (int i = 0; i < attributes.Length; i++) {

            attributesDisplay += "\n " + attributes[i].attribute.ToString() + " ";
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

    private string AddDurabilityStringToTooltip(int currentDurability, int maxDurability) {

        string durabilityDisplay = "";

        if (maxDurability > 1) {
            durabilityDisplay += "\n\n Durability: " + currentDurability.ToString() + "/" + maxDurability.ToString();
        }

        return durabilityDisplay;
    }

    public void HideTooltip() {

        tooltip.SetActive(false);
    }

    public void ShowSplitPanel() {

        splitPanel.SetActive(true);
    }

    public void HideSplitPanel() {

        splitPanel.SetActive(false);
    }   


}
