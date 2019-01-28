using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class ItemSpawnerScript : MonoBehaviour {

    public static ItemSpawnerScript Instance;

    public Texture2D ItemTexture;
    public Sprite[] Sprites;

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

    public int ItemsToSpawn = 5;
    public PickupAbleItemData[] Items;
    public GameObject ItemPrefab;

    private readonly string _filePath = "ItemListData.json";

    void Awake() {

        if (Instance != null) {
            Debug.LogWarning("ItemSpawnerScript instance already exist!");
            return;
        } else {
            Instance = this;
        }
    }

    // Use this for initialization
    void Start () {

        Sprites = Resources.LoadAll<Sprite>(ItemTexture.name);

        //CreateItems();
        LoadItems();
    }

    public void CreateItems() {

        Items = new PickupAbleItemData[10];

        Items[0] = new PickupAbleItemData();
        Items[0].MaxDurability = 100;
        Items[0].CurrentDurability = 100;
        Items[0].MaxStack = 1;
        Items[0].CurrentStack = 1;
        Items[0].Name = "Wizard's Hat";
        Items[0].ItemType = AttrAndCharUtils.ItemType.Head;
        Items[0].ItemImageName = Sprites[19].name;
        Items[0].ItemImage = Sprites[19];
        //items[0].attributes[0] = new Buff(AttrAndCharUtils.AttributeType.Intelligence, 5);
        //items[0].attributes[1] = new Buff(AttrAndCharUtils.AttributeType.Mana, 20);
        Items[0].Attributes = new Buff[2];
        Items[0].Attributes[0] = new Buff(AttrAndCharUtils.AttributeType.Intelligence, 5);
        Items[0].Attributes[1] = new Buff(AttrAndCharUtils.AttributeType.Mana, 20);

        Items[1] = new PickupAbleItemData();
        Items[1].MaxDurability = 1;
        Items[1].CurrentDurability = 1;
        Items[1].MaxStack = 5;
        Items[1].CurrentStack = 1;
        Items[1].Name = "Viper Eye";
        Items[1].ItemType = AttrAndCharUtils.ItemType.Misc;
        Items[1].ItemImageName = Sprites[52].name;
        Items[1].ItemImage = Sprites[52];

        Items[2] = new PickupAbleItemData();
        Items[2].MaxDurability = 1;
        Items[2].CurrentDurability = 1;
        Items[2].MaxStack = 2;
        Items[2].CurrentStack = 1;
        Items[2].Name = "Beer";
        Items[2].ItemType = AttrAndCharUtils.ItemType.Consumable;
        Items[2].ItemImageName = Sprites[5].name;
        Items[2].ItemImage = Sprites[5];
        //items[2].attributes = new Attribute[2];
        //items[2].attributes[0] = new Attribute(AttrAndCharUtils.AttributeType.Intelligence, -10, 60);
        //items[2].attributes[1] = new Attribute(AttrAndCharUtils.AttributeType.Strength, 15, 60);
        Items[2].Attributes = new Buff[2];
        Items[2].Attributes[0] = new Buff(AttrAndCharUtils.BuffType.HoldBonus, AttrAndCharUtils.AttributeType.Intelligence, -10, 60);
        Items[2].Attributes[0] = new Buff(AttrAndCharUtils.BuffType.HoldBonus, AttrAndCharUtils.AttributeType.Strength, 15, 60);


        Items[3] = new PickupAbleItemData();
        Items[3].MaxDurability = 1;
        Items[3].CurrentDurability = 1;
        Items[3].MaxStack = int.MaxValue;
        Items[3].CurrentStack = 100;
        Items[3].Name = "Gold";
        Items[3].ItemType = AttrAndCharUtils.ItemType.Misc;
        Items[3].ItemImageName = Sprites[17].name;
        Items[3].ItemImage = Sprites[17];

        Items[4] = new PickupAbleItemData();
        Items[4].MaxDurability = 60;
        Items[4].CurrentDurability = 60;
        Items[4].MaxStack = 1;
        Items[4].CurrentStack = 1;
        Items[4].Name = "Black Leather Boots";
        Items[4].ItemType = AttrAndCharUtils.ItemType.Boots;
        Items[4].ItemImageName = Sprites[43].name;
        Items[4].ItemImage = Sprites[43];
        //items[4].attributes = new Attribute[1];
        //items[4].attributes[0] = new Attribute(AttrAndCharUtils.AttributeType.Agility, 20);
        Items[4].Attributes = new Buff[1];
        Items[4].Attributes[0] = new Buff(AttrAndCharUtils.AttributeType.Agility, 20);

        Items[5] = new PickupAbleItemData();
        Items[5].MaxDurability = 140;
        Items[5].CurrentDurability = 140;
        Items[5].MaxStack = 1;
        Items[5].CurrentStack = 1;
        Items[5].Name = "Fire Sword";
        Items[5].ItemType = AttrAndCharUtils.ItemType.Weapon;
        Items[5].ItemImageName = Sprites[47].name;
        Items[5].ItemImage = Sprites[47];

        Items[6] = new PickupAbleItemData();
        Items[6].MaxDurability = 1;
        Items[6].CurrentDurability = 1;
        Items[6].MaxStack = 10;
        Items[6].CurrentStack = 1;
        Items[6].Name = "Mana Potion";
        Items[6].ItemType = AttrAndCharUtils.ItemType.Consumable;
        Items[6].ItemImageName = Sprites[26].name;
        Items[6].ItemImage = Sprites[26];
        //items[6].attributes = new Attribute[1];
        //items[6].attributes[0] = new Attribute(AttrAndCharUtils.AttributeType.Mana, 0.1f);
        Items[6].Attributes = new Buff[1];
        Items[6].Attributes[0] = new Buff(AttrAndCharUtils.AttributeType.Mana, 0.1f);

        Items[7] = new PickupAbleItemData();
        Items[7].MaxDurability = 1;
        Items[7].CurrentDurability = 1;
        Items[7].MaxStack = 10;
        Items[7].CurrentStack = 1;
        Items[7].Name = "Health Potion";
        Items[7].ItemType = AttrAndCharUtils.ItemType.Consumable;
        Items[7].ItemImageName = Sprites[4].name;
        Items[7].ItemImage = Sprites[4];
        //items[7].attributes = new Attribute[1];
        //items[7].attributes[0] = new Attribute(AttrAndCharUtils.AttributeType.Health, 0.1f);
        Items[7].Attributes = new Buff[1];
        Items[7].Attributes[0] = new Buff(AttrAndCharUtils.BuffType.Change, AttrAndCharUtils.AttributeType.Health, 18, 6);

        Items[8] = new PickupAbleItemData();
        Items[8].MaxDurability = 200;
        Items[8].CurrentDurability = 180;
        Items[8].MaxStack = 1;
        Items[8].CurrentStack = 1;
        Items[8].Name = "Catarina Armor";
        Items[8].ItemType = AttrAndCharUtils.ItemType.Armor;
        Items[8].ItemImageName = Sprites[27].name;
        Items[8].ItemImage = Sprites[27];
        //items[8].attributes = new Attribute[2];
        //items[8].attributes[0] = new Attribute(AttrAndCharUtils.AttributeType.Health, 50);
        //items[8].attributes[1] = new Attribute(AttrAndCharUtils.AttributeType.Strength, 20);
        Items[8].Attributes = new Buff[2];
        Items[8].Attributes[0] = new Buff(AttrAndCharUtils.AttributeType.Health, 50);
        Items[8].Attributes[1] = new Buff(AttrAndCharUtils.AttributeType.Strength, 20);

        Items[9] = new PickupAbleItemData();
        Items[9].MaxDurability = 150;
        Items[9].CurrentDurability = 150;
        Items[9].MaxStack = 1;
        Items[9].CurrentStack = 1;
        Items[9].Name = "Catarina Helm";
        Items[9].ItemType = AttrAndCharUtils.ItemType.Head;
        Items[9].ItemImageName = Sprites[35].name;
        Items[9].ItemImage = Sprites[35];
        //items[9].attributes = new Attribute[2];
        //items[9].attributes[0] = new Attribute(AttrAndCharUtils.AttributeType.Dexterity, 10);
        //items[9].attributes[1] = new Attribute(AttrAndCharUtils.AttributeType.Strength, 10);
        Items[9].Attributes = new Buff[2];
        Items[9].Attributes[0] = new Buff(AttrAndCharUtils.AttributeType.Dexterity, 10);
        Items[9].Attributes[1] = new Buff(AttrAndCharUtils.AttributeType.Strength, 12);

        string json = JsonHelper.ToJson(Items, true);
        File.WriteAllText(_filePath, json);
        //Debug.Log(json);
    }

    public void LoadItems() {

        if (File.Exists(_filePath)) {
            string dataAsJson = File.ReadAllText(_filePath);
            Items = JsonHelper.FromJson<PickupAbleItemData>(dataAsJson);

            for (int i = 0; i < Items.Length; i++) {
                Items[i].ItemImage = Sprites[int.Parse(Items[i].ItemImageName.Substring(12))];
            }
        }
    }

    public void SpawnItems() {

        for (int i = 0; i < ItemsToSpawn; i++) {
            Vector3 position = Random.insideUnitCircle * 2;
            int rndIndex = Random.Range(0, Items.Length);
            
            Spawn(Items[rndIndex], position);            
        }
    }

    public void Spawn(PickupAbleItemData itemData, Vector3? position = null) {

        GameObject newItem = Instantiate(ItemPrefab);
        newItem.transform.position = (position == null) ? GameMasterScript.Instance.Player.transform.position : (Vector3)position;

        if (itemData.ItemId == 0) {
            newItem.GetComponent<DroppedItem>().FillItemData(itemData, newItemId);
        } else {
            newItem.GetComponent<DroppedItem>().FillItemData(itemData, itemData.ItemId);
        }
    }


}
