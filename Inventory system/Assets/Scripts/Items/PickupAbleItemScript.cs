using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Pickup-able item", menuName = "Items/Pickup-able item")]
public class PickupAbleItemScript : ItemDataScript {

    public int maxDurability = 100;
    public int currentDurability = 100;

    public int maxStack = 1;
    public int currentStack = 1;

}
