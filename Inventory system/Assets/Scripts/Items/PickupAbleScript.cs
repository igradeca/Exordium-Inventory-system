using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Pickupable item", menuName = "Items/Pickupable item")]
public class PickupAbleScript : ItemDataScript {

    public int durability = -1;
    public AttrAndCharUtils.ItemType itemType;
    /*
    public PickupAbleScript() {

    }
    */
}
