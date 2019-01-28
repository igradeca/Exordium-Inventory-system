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

    public enum BuffType {

        /// <summary>
        /// Applied on use until item is unequiped.
        /// </summary>
        Constant,
        /// <summary>
        /// Constantly applied over some time period.
        /// </summary>
        HoldBonus,
        /// <summary>
        /// Increase/decrease value to some limit over time.
        /// </summary>
        Ramp,
        /// <summary>
        /// Apply value over some time period.
        /// </summary>
        Change
    }


}

[System.Serializable]
public class Attribute {

    public AttrAndCharUtils.AttributeType attribute;

    public float value = 0;

    public Attribute() { }

    public Attribute(AttrAndCharUtils.AttributeType attribute, float value) {

        this.attribute = attribute;
        this.value = value;
    } 
}

[System.Serializable]
public class Buff : Attribute {

    public AttrAndCharUtils.BuffType effect;
    
    /// <summary>
    /// In seconds.
    /// </summary>
    public int startOffset = 0;
    /// <summary>
    /// In seconds.
    /// </summary>
    public int duration = 0;

    public delegate float ApplyBuff(int elapsedTime);
    public ApplyBuff apply;

    public Buff(AttrAndCharUtils.BuffType effect, AttrAndCharUtils.AttributeType attribute, float value, int duration, int startOffset) {

        this.effect = effect;

        switch (effect) {
            case AttrAndCharUtils.BuffType.Constant:
                apply = ConstantEffect;
                break;
            case AttrAndCharUtils.BuffType.HoldBonus:
                apply = HoldBonusEffect;
                break;
            case AttrAndCharUtils.BuffType.Ramp:
                apply = RampEffect;
                break;
            case AttrAndCharUtils.BuffType.Change:
                apply = ChangeEffect;
                break;
        }

        this.attribute = attribute;
        this.value = value;
        this.duration = duration;
        this.startOffset = startOffset;
    }

    public Buff(AttrAndCharUtils.AttributeType attribute, float value) : 
        this(AttrAndCharUtils.BuffType.Change, attribute, value, 0, 0) { }

    public Buff(AttrAndCharUtils.BuffType effect, AttrAndCharUtils.AttributeType attribute, float value, int duration) : 
        this(effect, attribute, value, duration, 0) { }

    private float ConstantEffect(int elapsedTime = 0) {

        return value;
    }

    private float HoldBonusEffect(int elapsedTime) {

        if (elapsedTime < startOffset) {
            return 0f;
        } else if ((startOffset + elapsedTime) < (startOffset + duration)) {
            return value;
        } else {
            return 0f;
        }
    }

    private float RampEffect(int elapsedTime) {

        if (elapsedTime < startOffset) {
            return 0f;
        } else if ((startOffset + elapsedTime) < (startOffset + duration)) {
            float t = (elapsedTime - startOffset) / duration;
            return Mathf.Lerp(0, value, t);
        } else {
            return 0f;
        }
    }

    private float ChangeEffect(int elapsedTime) {

        float res = value / duration;

        if (elapsedTime < startOffset) {
            return 0f;
        } else if ((startOffset + elapsedTime) < (startOffset + duration)) {
            return res;
        } else {
            return 0f;
        }
    }
}
