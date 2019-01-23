﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Permanent item", menuName = "Items/Permanent item")]
public class ItemDataScript : ScriptableObject {

    public new string name;
    public AttrAndCharUtils.ItemType itemType;

    public Sprite itemImage;
    public Sprite backgroundImage;

    public Attribute[] attributes;

}

