using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class ItemSpawnerScript : MonoBehaviour {

    public static ItemSpawnerScript instance;

    public Texture2D itemTexture;
    public Sprite[] sprites;

    private int _itemId;

    /// <summary>
    /// Auto incrementing variable.
    /// </summary>
    public int newItemId {        
        get {
            ++_itemId;
            return _itemId;
        } set { }
    }

    public int itemsToSpawn = 5;
    public PickupAbleItemData[] items;
    public GameObject itemPrefab;

    private readonly string filePath = "ItemListData.json";

    void Awake() {

        if (instance != null) {
            Debug.LogWarning("ItemSpawnerScript instance already exist!");
            return;
        } else {
            instance = this;
        }

        //itemId = 0;
    }

    // Use this for initialization
    void Start () {

        sprites = Resources.LoadAll<Sprite>(itemTexture.name);

        //CreateItems();
        LoadItems();
    }

    public void CreateItems() {

        items = new PickupAbleItemData[10];

        items[0] = new PickupAbleItemData();
        items[0].maxDurability = 100;
        items[0].currentDurability = 100;
        items[0].maxStack = 1;
        items[0].currentStack = 1;
        items[0].name = "Wizard's Hat";
        items[0].itemType = AttrAndCharUtils.ItemType.Head;
        items[0].itemImageName = sprites[19].name;
        items[0].itemImage = sprites[19];
        items[0].attributes = new Attribute[2];
        items[0].attributes[0] = new Attribute(AttrAndCharUtils.AttributeType.Intelligence, 5);
        items[0].attributes[1] = new Attribute(AttrAndCharUtils.AttributeType.Mana, 20);

        items[1] = new PickupAbleItemData();
        items[1].maxDurability = 1;
        items[1].currentDurability = 1;
        items[1].maxStack = 5;
        items[1].currentStack = 1;
        items[1].name = "Viper Eye";
        items[1].itemType = AttrAndCharUtils.ItemType.Misc;
        items[1].itemImageName = sprites[52].name;
        items[1].itemImage = sprites[52];

        items[2] = new PickupAbleItemData();
        items[2].maxDurability = 1;
        items[2].currentDurability = 1;
        items[2].maxStack = 2;
        items[2].currentStack = 1;
        items[2].name = "Beer";
        items[2].itemType = AttrAndCharUtils.ItemType.Consumable;
        items[2].itemImageName = sprites[5].name;
        items[2].itemImage = sprites[5];
        items[2].attributes = new Attribute[2];
        items[2].attributes[0] = new Attribute(AttrAndCharUtils.AttributeType.Intelligence, -10, 60);
        items[2].attributes[1] = new Attribute(AttrAndCharUtils.AttributeType.Strength, 15, 60);

        items[3] = new PickupAbleItemData();
        items[3].maxDurability = 1;
        items[3].currentDurability = 1;
        items[3].maxStack = int.MaxValue;
        items[3].currentStack = 100;
        items[3].name = "Gold";
        items[3].itemType = AttrAndCharUtils.ItemType.Misc;
        items[3].itemImageName = sprites[17].name;
        items[3].itemImage = sprites[17];

        items[4] = new PickupAbleItemData();
        items[4].maxDurability = 60;
        items[4].currentDurability = 60;
        items[4].maxStack = 1;
        items[4].currentStack = 1;
        items[4].name = "Black Leather Boots";
        items[4].itemType = AttrAndCharUtils.ItemType.Boots;
        items[4].itemImageName = sprites[43].name;
        items[4].itemImage = sprites[43];
        items[4].attributes = new Attribute[1];
        items[4].attributes[0] = new Attribute(AttrAndCharUtils.AttributeType.Agility, 20);

        items[5] = new PickupAbleItemData();
        items[5].maxDurability = 140;
        items[5].currentDurability = 140;
        items[5].maxStack = 1;
        items[5].currentStack = 1;
        items[5].name = "Fire Sword";
        items[5].itemType = AttrAndCharUtils.ItemType.Weapon;
        items[5].itemImageName = sprites[47].name;
        items[5].itemImage = sprites[47];

        items[6] = new PickupAbleItemData();
        items[6].maxDurability = 1;
        items[6].currentDurability = 1;
        items[6].maxStack = 10;
        items[6].currentStack = 1;
        items[6].name = "Mana Potion";
        items[6].itemType = AttrAndCharUtils.ItemType.Consumable;
        items[6].itemImageName = sprites[26].name;
        items[6].itemImage = sprites[26];
        items[6].attributes = new Attribute[1];
        items[6].attributes[0] = new Attribute(AttrAndCharUtils.AttributeType.Mana, 0.1f);

        items[7] = new PickupAbleItemData();
        items[7].maxDurability = 1;
        items[7].currentDurability = 1;
        items[7].maxStack = 10;
        items[7].currentStack = 1;
        items[7].name = "Health Potion";
        items[7].itemType = AttrAndCharUtils.ItemType.Consumable;
        items[7].itemImageName = sprites[4].name;
        items[7].itemImage = sprites[4];
        items[7].attributes = new Attribute[1];
        items[7].attributes[0] = new Attribute(AttrAndCharUtils.AttributeType.Health, 0.1f);

        items[8] = new PickupAbleItemData();
        items[8].maxDurability = 200;
        items[8].currentDurability = 180;
        items[8].maxStack = 1;
        items[8].currentStack = 1;
        items[8].name = "Catarina Armor";
        items[8].itemType = AttrAndCharUtils.ItemType.Chest;
        items[8].itemImageName = sprites[27].name;
        items[8].itemImage = sprites[27];
        items[8].attributes = new Attribute[2];
        items[8].attributes[0] = new Attribute(AttrAndCharUtils.AttributeType.Health, 50);
        items[8].attributes[1] = new Attribute(AttrAndCharUtils.AttributeType.Strength, 20);

        items[9] = new PickupAbleItemData();
        items[9].maxDurability = 150;
        items[9].currentDurability = 150;
        items[9].maxStack = 1;
        items[9].currentStack = 1;
        items[9].name = "Catarina Helm";
        items[9].itemType = AttrAndCharUtils.ItemType.Head;
        items[9].itemImageName = sprites[35].name;
        items[9].itemImage = sprites[35];
        items[9].attributes = new Attribute[2];
        items[9].attributes[0] = new Attribute(AttrAndCharUtils.AttributeType.Dexterity, 10);
        items[9].attributes[1] = new Attribute(AttrAndCharUtils.AttributeType.Strength, 10);

        string json = JsonHelper.ToJson(items, true);
        File.WriteAllText(filePath, json);
        //Debug.Log(json);
    }

    public void LoadItems() {

        if (File.Exists(filePath)) {
            string dataAsJson = File.ReadAllText(filePath);

            items = JsonHelper.FromJson<PickupAbleItemData>(dataAsJson);

            for (int i = 0; i < items.Length; i++) {
                items[i].itemImage = sprites[int.Parse(items[i].itemImageName.Substring(12))];
            }
        }
    }

    public void SpawnItems() {

        for (int i = 0; i < itemsToSpawn; i++) {
            Vector2 position = Random.insideUnitCircle * 2;
            int rndIndex = Random.Range(0, items.Length);
            
            Spawn(position, items[rndIndex]);            
        }
    }

    public void Spawn(Vector2 position, PickupAbleItemData itemData) {

        GameObject newItem = Instantiate(itemPrefab);
        if (itemData.itemId == 0) {
            newItem.GetComponent<ItemScript>().FillItemData(itemData, newItemId);
        } else {
            newItem.GetComponent<ItemScript>().FillItemData(itemData, itemData.itemId);
        }
        
        newItem.transform.position = position;
    }


}
