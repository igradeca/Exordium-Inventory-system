using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class EquipmentCellInteraction : ItemCell, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler {

    public AttrAndCharUtils.ItemType cellType;

    public void OnPointerClick(PointerEventData eventData) {
        
        
    }

    public void OnPointerEnter(PointerEventData eventData) {

        if (cellItemData != null) {
            UIManager.instance.ShowTooltip(transform.position, cellItemData);
        }
    }

    public void OnPointerExit(PointerEventData eventData) {

        UIManager.instance.HideTooltip();
    }


}
