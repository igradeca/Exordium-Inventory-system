using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class AttrAndCharUtils {

    public enum ItemType {

        // Equipable
        Head,
        Armor,
        Boots,
        Weapon,

        // Other types
        Permanent,
        Consumable,
        Misc
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

[System.Serializable]
public class Attribute {

    public AttrAndCharUtils.AttributeType attribute;

    public float percentage = 1f;
    public int value = 0;

    public int duration = 0;

    public Attribute(AttrAndCharUtils.AttributeType attribute, float percentage, int duration = 0) {

        this.attribute = attribute;
        this.percentage = percentage;
        this.duration = duration;
    }

    public Attribute(AttrAndCharUtils.AttributeType attribute, int value, int duration = 0) {

        this.attribute = attribute;
        this.value = value;
        this.duration = duration;
    }
}
