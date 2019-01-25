using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class ItemSpawnerScript : MonoBehaviour {

    public Texture2D itemTexture;
    public Sprite[] sprites;

    public int itemsToSpawn = 5;
    public PickupAbleItemData[] items;
    public GameObject itemPrefab;

    private readonly string filePath = "ItemListData.json";

    // Use this for initialization
    void Start () {

        sprites = Resources.LoadAll<Sprite>(itemTexture.name);

        //CreateItems();
        LoadItems();
    }

    public void CreateItems() {

        items = new PickupAbleItemData[3];

        items[0] = new PickupAbleItemData();
        items[0].maxDurability = 100;
        items[0].currentDurability = 100;
        items[0].maxStack = 1;
        items[0].currentStack = 1;
        items[0].name = "Wizard's Hat";
        items[0].itemType = AttrAndCharUtils.ItemType.Head;
        items[0].itemImageName = sprites[19].name;
        items[0].itemImage = sprites[19];

        items[1] = new PickupAbleItemData();
        items[1].maxDurability = 1;
        items[1].currentDurability = 1;
        items[1].maxStack = 5;
        items[1].currentStack = 1;
        items[1].name = "Viper Eye";
        items[1].itemType = AttrAndCharUtils.ItemType.Other;
        items[1].itemImageName = sprites[52].name;
        items[1].itemImage = sprites[52];

        items[2] = new PickupAbleItemData();
        items[2].maxDurability = 1;
        items[2].currentDurability = 1;
        items[2].maxStack = 2;
        items[2].currentStack = 1;
        items[2].name = "Beer";
        items[2].itemType = AttrAndCharUtils.ItemType.Other;
        items[2].itemImageName = sprites[5].name;
        items[2].itemImage = sprites[5];

        string json = JsonHelper.ToJson(items, true);
        File.WriteAllText(filePath, json);
        //Debug.Log(json);
    }

    public void LoadItems() {

        if (File.Exists(filePath)) {
            string dataAsJson = File.ReadAllText(filePath);

            items = JsonHelper.FromJson<PickupAbleItemData>(dataAsJson);
            //Debug.Log(items);
        }
    }

    public void SpawnItems() {

        for (int i = 0; i < items.Length; i++) {
            Vector2 position = Random.insideUnitCircle * 2;

            GameObject newItem = Instantiate(itemPrefab);
            newItem.GetComponent<ItemScript>().FillItemData(items[i]);

            newItem.transform.position = position;
        }
    }


}
