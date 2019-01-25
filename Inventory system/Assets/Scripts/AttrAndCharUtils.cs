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
