using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class inventoryScript : MonoBehaviour
{
    //==============================================================================
    //  This script is used to display the contents of an inventory in the UI
    //==============================================================================
    public GameObject inventoryPrefab;
    public InventoryObject inventory;
    public Dictionary<InventorySlot, GameObject> itemsDisplayed = new Dictionary<InventorySlot, GameObject>();

    private void Start()
    {
        createDisplay();
    }

    public void Update()
    {
        updateDisplay();
    }

    public void createDisplay()
    {
        for(int i = 0; i < inventory.Container.Items.Count; i++)
        {
            InventorySlot slot = inventory.Container.Items[i];
            var obj = Instantiate(inventoryPrefab, Vector3.zero, Quaternion.identity, transform);
            obj.transform.GetChild(0).GetComponentInChildren<Image>().sprite = inventory.database.GetItem[slot.item.Id].uiDisplay;
            obj.GetComponentInChildren<TextMeshProUGUI>().text = slot.amount.ToString("n0");
            itemsDisplayed.Add(slot, obj);
        }
    }


    public void updateDisplay()
    {
        for (int i = 0; i < inventory.Container.Items.Count; i++) //for every item in inventory
        {
            InventorySlot slot = inventory.Container.Items[i];
            if (itemsDisplayed.ContainsKey(slot)) //if item is already in inventory, increment
            {
                itemsDisplayed[slot].GetComponentInChildren<TextMeshProUGUI>().text = slot.amount.ToString("n0"); 
            }
            else if(!itemsDisplayed.ContainsKey(slot))
            {
                var obj = Instantiate(inventoryPrefab, Vector3.zero, Quaternion.identity, transform);
                obj.GetComponent<itemInventoryClick>().ItemObject = slot.item;
                addSlot(slot, obj);
                obj.name = slot.item.name + "(inventoryVisual)"; /*ONLY WORKS FOR NON STACKABLE ITEMS*/
                obj.GetComponentInChildren<Image>().sprite = slot.item.uiDisplay; //image
                obj.GetComponentInChildren<TextMeshProUGUI>().text = slot.amount.ToString("n0"); //amount of items
            }
        }
    }

    public void addSlot(InventorySlot inventorySlot, GameObject Object)
    {
        itemsDisplayed.Add(inventorySlot, Object);
        //Debug.Log("Added " + inventorySlot.item.Name);
    }
}

