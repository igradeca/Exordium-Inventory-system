using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class AttrAndCharUtils {

    public enum ItemType {
        // Equipable
        Head,
        Chest,
        Legs,
        Boots,
        Gloves,
        Weapon,

        // Other types
        Consumable,
        Other
    }


}

public class Attribute {

    public float percentage;
    public int value;

    public int duration;


}
