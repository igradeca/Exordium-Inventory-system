using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryCellScript : MonoBehaviour {

    public Text stackStatus;
    public Image cellImage;

	// Use this for initialization
	void Start () {

        stackStatus = transform.GetChild(0).GetComponent<Text>();
    }

    public void UpdateCell(string textToDisplay, Sprite sprite) {
        
        stackStatus.text = textToDisplay;
        cellImage.sprite = sprite;
        cellImage.color = Color.white;
    }

}
