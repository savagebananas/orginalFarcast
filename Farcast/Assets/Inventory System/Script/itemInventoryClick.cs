using UnityEngine;
using UnityEngine.UI;
using TMPro;

//This script is on every specific item object in UI inventory

public class itemInventoryClick : MonoBehaviour
{
    private TextMeshProUGUI descripton;
    private TextMeshProUGUI itemName;
    private playerGeneral playerGeneral;

    public ItemObject ItemObject;

    private void Awake()
    {
        descripton = GameObject.Find("description").GetComponent<TextMeshProUGUI>();
        itemName = GameObject.Find("itemNameDisplay").GetComponent<TextMeshProUGUI>();
        playerGeneral = GameObject.Find("Player").GetComponent<playerGeneral>();
    }

    public void displayDescription()
    {
        displayText(ItemObject);
    }

    public void displayText(ItemObject inventoryItemPrefab)
    {
        descripton.text = inventoryItemPrefab.description;
        itemName.text = inventoryItemPrefab.name;
        playerGeneral.selectedItem = inventoryItemPrefab;
    }

    public void resetDescription()
    {
        descripton.text = "";
    }

    private void OnApplicationQuit()
    {
        resetDescription();
    }

}
