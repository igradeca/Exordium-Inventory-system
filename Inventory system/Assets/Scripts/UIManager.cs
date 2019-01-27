using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

    public static UIManager instance;

    public GameObject tooltip;
    public GameObject cursorItemInTheAir;

    public bool leftControlKeyPressed;
    public bool spaceKeyPressed;

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
            AttributesScript.instance.ShowPanel();
        }

        if (Input.GetKeyDown(KeyCode.E)) {
            EquipmentScript.instance.ShowPanel();
        }

        if (Input.GetKeyDown(KeyCode.I)) {
            InventoryScript.instance.ShowPanel();
        }

        if (Input.GetKeyDown(KeyCode.LeftControl)) {
            leftControlKeyPressed = true;
        } else if (Input.GetKeyUp(KeyCode.LeftControl)) {
            leftControlKeyPressed = false;
        }

        if (Input.GetKeyDown(KeyCode.Space)) {
            spaceKeyPressed = true;
        } else if (Input.GetKeyUp(KeyCode.Space)) {
            spaceKeyPressed = false;
        }

    }

    public void PanelsClosed() {

        if (AllPanelsAreClosed()) {
            if (cursorItemInTheAir.activeSelf) {
                MouseCursor.instance.RemoveItemDataFromCursor();
            }            
            DeactivateCursorItemInTheAir();
        }
    }

    private bool AllPanelsAreClosed() {

        if (!AttributesScript.instance.attributesPanel.activeSelf && 
            !EquipmentScript.instance.equipmentPanel.activeSelf && 
            !InventoryScript.instance.inventoryPanel.activeSelf) {
            return true;
        } else {
            return false;
        }
    }

    public void ShowTooltip(Vector2 position, PickupAbleItemData itemData) {

        tooltip.SetActive(true);
        tooltip.transform.position = position + new Vector2(-16f, 16f);

        tooltip.transform.GetChild(0).GetComponent<Text>().text = itemData.name + "\n" +
            " Type: " + itemData.itemType.ToString()/* + "\n"; +
            " Type: " + itemData. + "\n" +
            " Type: " + itemData.itemType.ToString() + "\n" +
            " Type: " + itemData.itemType.ToString()*/;
    }

    public void HideTooltip() {

        tooltip.SetActive(false);
    }

    public void ActivateCursorItemInTheAir() {

        if (!cursorItemInTheAir.activeSelf) {
            cursorItemInTheAir.SetActive(true);
        }
    }

    public void DeactivateCursorItemInTheAir() {

        if (cursorItemInTheAir.activeSelf) {
            cursorItemInTheAir.SetActive(false);
        }
    }


}
