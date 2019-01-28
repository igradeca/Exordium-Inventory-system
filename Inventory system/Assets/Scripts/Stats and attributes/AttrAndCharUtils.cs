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

    public AttrAndCharUtils.AttributeType AttributeType;

    public float Value = 0;

    public Attribute() { }

    public Attribute(AttrAndCharUtils.AttributeType attribute, float value) {

        this.AttributeType = attribute;
        this.Value = value;
    } 
}

[System.Serializable]
public class Buff : Attribute {

    public AttrAndCharUtils.BuffType Effect;
    
    /// <summary>
    /// In seconds.
    /// </summary>
    public int StartOffset = 0;
    /// <summary>
    /// In seconds.
    /// </summary>
    public int Duration = 0;

    public delegate float ApplyBuff(int elapsedTime);
    public ApplyBuff Apply;

    public Buff(AttrAndCharUtils.BuffType effect, AttrAndCharUtils.AttributeType attribute, float value, int duration, int startOffset) {

        this.Effect = effect;

        switch (effect) {
            case AttrAndCharUtils.BuffType.Constant:
                Apply = _constantEffect;
                break;
            case AttrAndCharUtils.BuffType.HoldBonus:
                Apply = _holdBonusEffect;
                break;
            case AttrAndCharUtils.BuffType.Ramp:
                Apply = _rampEffect;
                break;
            case AttrAndCharUtils.BuffType.Change:
                Apply = _changeEffect;
                break;
        }

        this.AttributeType = attribute;
        this.Value = value;
        this.Duration = duration;
        this.StartOffset = startOffset;
    }

    public Buff(AttrAndCharUtils.AttributeType attribute, float value) : 
        this(AttrAndCharUtils.BuffType.Change, attribute, value, 0, 0) { }

    public Buff(AttrAndCharUtils.BuffType effect, AttrAndCharUtils.AttributeType attribute, float value, int duration) : 
        this(effect, attribute, value, duration, 0) { }

    private float _constantEffect(int elapsedTime = 0) {

        return Value;
    }

    private float _holdBonusEffect(int elapsedTime) {

        if (elapsedTime < StartOffset) {
            return 0f;
        } else if ((StartOffset + elapsedTime) < (StartOffset + Duration)) {
            return Value;
        } else {
            return 0f;
        }
    }

    private float _rampEffect(int elapsedTime) {

        if (elapsedTime < StartOffset) {
            return 0f;
        } else if ((StartOffset + elapsedTime) < (StartOffset + Duration)) {
            float t = (elapsedTime - StartOffset) / Duration;
            return Mathf.Lerp(0, Value, t);
        } else {
            return 0f;
        }
    }

    private float _changeEffect(int elapsedTime) {

        float res = Value / Duration;

        if (elapsedTime < StartOffset) {
            return 0f;
        } else if ((StartOffset + elapsedTime) < (StartOffset + Duration)) {
            return res;
        } else {
            return 0f;
        }
    }
}
