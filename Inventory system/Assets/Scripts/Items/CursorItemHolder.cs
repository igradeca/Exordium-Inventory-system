using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CursorItemHolder : MonoBehaviour {

    public static CursorItemHolder Instance;

    public Canvas MainCanvas;
    public Image CursorImage;
    public GameObject StackingBackground;
    public Text StackingText;

    public PickupAbleItemData HoldingItemData;
    public bool ItemIsFromInventory;

    void Awake() {

        if (Instance != null) {
            Debug.LogWarning("MouseCursor instance already exist!");
            return;
        } else {
            Instance = this;
        }

        HoldingItemData = null;
    }

    // Update is called once per frame
    void Update() {

        if (Input.GetMouseButtonDown(0)) {
            if (!EventSystem.current.IsPointerOverGameObject()) {
                if (!CursorHolderIsEmpty()) {
                    ItemSpawnerScript.Instance.Spawn(HoldingItemData);
                    Debug.Log(HoldingItemData.Name + " spawned from cursor holder.");
                    EmptyItemData();
                }
            }
        }

        // Follow cursor
        if (HoldingItemData != null) {

            Vector2 pos;
            RectTransformUtility.ScreenPointToLocalPointInRectangle(
                MainCanvas.transform as RectTransform,
                Input.mousePosition,
                MainCanvas.worldCamera,
                out pos);

            transform.position = MainCanvas.transform.TransformPoint(pos) + new Vector3(20f, -25f, 0f);
        }
    }

    public void AddItemDataToCursor(PickupAbleItemData itemData) {

        HoldingItemData = itemData;

        _updateCursor();
    }

    private void _updateCursor() {

        string stackInfo = _updateStackInfo();
        if (stackInfo != "") {
            StackingBackground.SetActive(true);
            StackingText.text = stackInfo;
        } else {
            StackingBackground.SetActive(false);
        }

        CursorImage.sprite = HoldingItemData.ItemImage;

        ShowCursorItem();
    }

    private string _updateStackInfo() {

        string stackText = "";
        if (HoldingItemData.MaxStack == int.MaxValue) {
            stackText = HoldingItemData.CurrentStack.ToString();
        } else if (HoldingItemData.MaxStack > 1) {
            stackText = HoldingItemData.CurrentStack.ToString() + "/" + HoldingItemData.MaxStack.ToString();
        }

        return stackText;
    }

    public void EmptyItemData() {

        CursorImage.sprite = null;
        StackingText.text = "";
        HoldingItemData = null;

        HideCursorItem();
    }

    public void ShowCursorItem() {

        CursorImage.gameObject.SetActive(true);
    }

    public void HideCursorItem() {

        CursorImage.gameObject.SetActive(false);
        StackingBackground.gameObject.SetActive(false);
    }

    public bool CursorHolderIsEmpty() {

        if (HoldingItemData == null) {
            return true;
        } else if (HoldingItemData.ItemId == 0) {
            return true;
        } else {
            return false;
        }
    }


}
