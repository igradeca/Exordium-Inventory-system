using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

    public static UIManager instance;

    public GameObject tooltip;
    public GameObject cursorItemInTheAir;

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
