using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEditor;
using System.Runtime.Serialization;

[CreateAssetMenu(fileName = "new Inventory", menuName = "Inventory System/Inventory")]
public class InventoryObject : ScriptableObject
{
    public string savePath;
    public ItemDatabaseObject database;
    public Inventory Container;

    //==============================================================================
    //  Add Item
    //==============================================================================
    public void addItem(ItemObject _item, int _amount)
    {
        for(int i = 0; i < Container.Items.Count; i++)
        {
            if(Container.Items[i].item == _item) //if inventory has item already, increment the amount to slot
            {
                Container.Items[i].AddAmount(_amount);
                return;
            }
        }
        Container.Items.Add(new InventorySlot(_item, _amount));
    }

    public void replaceItem(ItemObject _item, int _amount)
    {
        bool hasItem = false;
        if (Container.Items[0].item == _item && !(_item.type.Equals("Weapon")) && !(_item.type.Equals("Armor"))) //Increase Item amount
        {
            Debug.Log("adding to hotbar slot");
            Container.Items[0].AddAmount(_amount);
            hasItem = true;
        }
        
        if (!hasItem) //if the item is not in inventory already
        {
            Container.Items[0].item = _item; //change item type
        }
    }

    //==============================================================================
    //  Remove Item
    //==============================================================================
    public void deleteItem(ItemObject _item, int amount)
    {
        for (int i = 0; i < Container.Items.Count; i++)
        {
            if (Container.Items[i].item == _item)
            {
                Container.Items[i].AddAmount(-amount);
                break;
            }
        }
    }

    public void inventoryClear()
    {
        for (int i = 0; i < Container.Items.Count; i++)
        {
            Container.Items[i].AddAmount(-Container.Items[i].amount);
        }
    }

    //==============================================================================
    //  Save and Load Inventory
    //==============================================================================
    [ContextMenu("Save")]
    public void Save() 
    {
        //string saveData = JsonUtility.ToJson(this, true);
        //BinaryFormatter bf = new BinaryFormatter();
        //FileStream file = File.Create(string.Concat(Application.persistentDataPath, savePath));
        //bf.Serialize(file, saveData);
        //file.Close();

        IFormatter formatter = new BinaryFormatter();
        FileStream stream = new FileStream(string.Concat(Application.persistentDataPath, savePath), FileMode.Create, FileAccess.Write);
        formatter.Serialize(stream, Container);
        stream.Close();
    }

    [ContextMenu("Load")]
    public void Load()
    {
        if(File.Exists(string.Concat(Application.persistentDataPath, savePath)))
        {
            //BinaryFormatter bf = new BinaryFormatter();
            //FileStream file = File.Open(string.Concat(Application.persistentDataPath, savePath), FileMode.Open);
            //JsonUtility.FromJsonOverwrite(bf.Deserialize(file).ToString(), this);
            //file.Close();

            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream(string.Concat(Application.persistentDataPath, savePath), FileMode.Open, FileAccess.Read);
            Inventory newContainer = (Inventory)formatter.Deserialize(stream);
            stream.Close();
        }
    }

    [ContextMenu("Clear")]
    public void Clear()
    {
        Container = new Inventory();
    }

}

//==============================================================================
//  Inventory Class
//==============================================================================
[System.Serializable]
public class Inventory
{
    public List<InventorySlot> Items = new List<InventorySlot>(); //the inventory
}

//==============================================================================
//  Inventory Slot Class
//==============================================================================

[System.Serializable]
public class InventorySlot
{
    public ItemObject item;
    public int amount;

    public InventorySlot(ItemObject _item, int _amount)
    {
        item = _item;
        amount = _amount;
    }

    public void AddAmount(int value)
    {
        amount += value;
    }
}
