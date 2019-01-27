﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MouseCursor : MonoBehaviour {

    public static MouseCursor instance;

    public Canvas mainCanvas;
    public Image cursorImage;
    public GameObject stackingBackground;
    public Text stackingText;

    public PickupAbleItemData holdingItemData;
    public int inventoryIndex;

    void Awake() {

        if (instance != null) {
            Debug.LogWarning("MouseCursor instance already exist!");
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

        if (Input.GetMouseButtonDown(0)) {
            // If we click on something that is not UI it will be true
            if (!EventSystem.current.IsPointerOverGameObject()) {
                Inventory.instance.DropItem(holdingItemData);
            }
        }

        if (Input.GetMouseButtonDown(1)) {
            RemoveItemDataFromCursor();
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

    public void SetItemDataToCursor(PickupAbleItemData itemData, int inventoryIndex) {

        holdingItemData = itemData;
        this.inventoryIndex = inventoryIndex;

        string stackInfo = UpdateStackInfo();
        if (stackInfo != "") {
            stackingBackground.SetActive(true);
            stackingText.text = stackInfo;
        } else {
            stackingBackground.SetActive(false);
        }

        cursorImage.sprite = itemData.itemImage;
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

    public void RemoveItemDataFromCursor() {

        cursorImage.sprite = null;
        stackingText.text = "";
        inventoryIndex = 0;
        holdingItemData = null;

        UIManager.instance.DeactivateCursorItemInTheAir();
    }


}
