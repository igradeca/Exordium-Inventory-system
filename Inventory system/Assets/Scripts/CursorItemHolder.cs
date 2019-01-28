using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CursorItemHolder : MonoBehaviour {

    public static CursorItemHolder instance;

    public Canvas mainCanvas;
    public Image cursorImage;
    public GameObject stackingBackground;
    public Text stackingText;

    public PickupAbleItemData holdingItemData;
    public bool itemIsFromInventory;

    void Awake() {

        if (instance != null) {
            Debug.LogWarning("MouseCursor instance already exist!");
            return;
        } else {
            instance = this;
        }

        holdingItemData = null;
    }
	
	// Update is called once per frame
	void Update () {

        if (Input.GetMouseButtonDown(0)) {
            if (!EventSystem.current.IsPointerOverGameObject()) {
                if (!CursorHolderIsEmpty()) {
                    ItemSpawnerScript.instance.Spawn(holdingItemData);
                    Debug.Log(holdingItemData.name + " spawned from cursor holder.");
                    EmptyItemData();                    
                }                
            }
        }

        // Follow cursor
        if (holdingItemData != null) {

            Vector2 pos;
            RectTransformUtility.ScreenPointToLocalPointInRectangle(
                mainCanvas.transform as RectTransform, 
                Input.mousePosition, 
                mainCanvas.worldCamera, 
                out pos);

            transform.position = mainCanvas.transform.TransformPoint(pos) + new Vector3(20f, -25f, 0f);
        }
	}

    public void AddItemDataToCursor(PickupAbleItemData itemData) {

        holdingItemData = itemData;

        UpdateCursor();
    }

    private void UpdateCursor() {

        string stackInfo = UpdateStackInfo();
        if (stackInfo != "") {
            stackingBackground.SetActive(true);
            stackingText.text = stackInfo;
        } else {
            stackingBackground.SetActive(false);
        }

        cursorImage.sprite = holdingItemData.itemImage;

        ShowCursorItem();
    }

    private string UpdateStackInfo() {

        string stackText = "";
        if (holdingItemData.maxStack == int.MaxValue) {
            stackText = holdingItemData.currentStack.ToString();
        } else if (holdingItemData.maxStack > 1) {
            stackText = holdingItemData.currentStack.ToString() + "/" + holdingItemData.maxStack.ToString();
        }

        return stackText;
    }

    public void EmptyItemData() {

        cursorImage.sprite = null;
        stackingText.text = "";
        holdingItemData = null;

        HideCursorItem();
    }

    public void ShowCursorItem() {

        cursorImage.gameObject.SetActive(true);
    }

    public void HideCursorItem() {

        cursorImage.gameObject.SetActive(false);
        stackingBackground.gameObject.SetActive(false);
    }

    public bool CursorHolderIsEmpty() {

        if (holdingItemData == null) {
            return true;
        } else if (holdingItemData.itemId == 0) {
            return true;
        } else {
            return false;
        }
    }


}
