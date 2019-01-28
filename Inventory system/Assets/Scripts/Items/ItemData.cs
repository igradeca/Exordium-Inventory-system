using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ItemData {

    public string Name;
    public AttrAndCharUtils.ItemType ItemType;

    public string ItemImageName;
    public Sprite ItemImage;
    public Sprite BackgroundImage;

    public Buff[] Attributes;
}
