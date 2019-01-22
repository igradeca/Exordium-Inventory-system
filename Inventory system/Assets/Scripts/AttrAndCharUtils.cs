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

[CreateAssetMenu(fileName = "Item attribute", menuName = "Items/Item attribute")]
public class Attribute : ScriptableObject {

    public float percentage = 1.0f;
    public int value = 0;

    public int duration = -1;
}
