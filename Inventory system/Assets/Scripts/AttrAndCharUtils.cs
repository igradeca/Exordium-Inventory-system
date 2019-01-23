using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class AttrAndCharUtils {

    public enum ItemType {

        // Other types
        Permanent,
        Consumable,
        Other,

        // Equipable
        Head,
        Chest,
        Legs,
        Boots,
        Gloves,
        Weapon
    }

    public enum AttributeType {

        Strength,
        Dexterity,
        Agility,
        Intelligence,

        Health,
        Mana
    }


}

[CreateAssetMenu(fileName = "Item attribute", menuName = "Items/Item attribute")]
public class Attribute : ScriptableObject {

    public AttrAndCharUtils.AttributeType attribute;
    public float percentage = 1.0f;
    public int value = 0;

    public int duration = -1;
}
