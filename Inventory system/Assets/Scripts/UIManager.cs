using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

    public static UIManager instance;

    public GameObject tooltip;

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
		
	}

    public void ShowTooltip(Vector2 position, PickupAbleItemData itemData) {

        tooltip.SetActive(true);
        tooltip.transform.position = position;

        tooltip.transform.GetChild(0).GetComponent<Text>().text = itemData.name + "\n" +
            " Type: " + itemData.itemType.ToString()/* + "\n"; +
            " Type: " + itemData. + "\n" +
            " Type: " + itemData.itemType.ToString() + "\n" +
            " Type: " + itemData.itemType.ToString()*/;
    }

    public void HideTooltip() {

        tooltip.SetActive(false);
    }


}
