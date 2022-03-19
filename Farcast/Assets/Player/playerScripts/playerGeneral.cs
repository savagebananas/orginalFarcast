using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class playerGeneral : MonoBehaviour
{
    public PlayerData data;
    public int maxHealth = 100;
    public int currentHealth;
    public int damage = 5;
    public int defence = 0;
    public int coins = 0;

    public float flashTime;

    public SpriteRenderer headRenderer;
    public SpriteRenderer bodyRenderer;
    public SpriteRenderer legRenderer;
    public Color damagedColor;

    public healthBar healthbar;

    CursorController playerInput;
    public InventoryObject playerInventory;
    public GameObject InventoryDisplay;
    public bool inventoryShowing = false;
    public GameObject cursor;
    public LayerMask itemLayer;
    public float interactRange;
    public ItemObject selectedItem;

    private void Start()
    {
        healthbar.SetMaxHealth(maxHealth);
        currentHealth = maxHealth;

        playerInput = cursor.GetComponent<CursorController>();
    }

    private void Update()
    {
        //=================inventory related=================
        checkInventoryEmpty();
        if (Physics2D.OverlapCircle(transform.position, interactRange, itemLayer) != null)
        { //within certain range, allow player to pickup items
            Collider2D other = Physics2D.OverlapCircle(transform.position, interactRange, itemLayer);
            pickupItem(other);
        }

    }



    //==============================================================================
    //  Interactables (NPCs and PickupItems)
    //==============================================================================

    public void pickupItem(Collider2D other)
    {
        if (playerInput.InteractPressed)
        {
            var item = other.GetComponent<GroundItem>();
            playerInventory.addItem(item.item, item.amount);
            Destroy(item.gameObject);
        }
    }

    public GameObject droppedItemPrefab;
    public void dropItem()
    {
        //Debug.Log("dropped item: " + selectedItem); 
        Vector3 offset = new Vector3(0, 0, 10);
        playerInventory.deleteItem(selectedItem, 1);
        var obj = Instantiate(droppedItemPrefab, transform.position +  offset, transform.rotation);
        obj.GetComponent<GroundItem>().item = selectedItem;
        obj.GetComponent<GroundItem>().amount = 1;
    }

    public void checkInventoryEmpty()
    {
        for (int i = 0; i < playerInventory.Container.Items.Count; i++)
        {
            if (playerInventory.Container.Items[i].amount <= 0)
            {
                Destroy(GameObject.Find(playerInventory.Container.Items[i].item.name + "(inventoryVisual)"));
                GameObject.Find("itemNameDisplay").GetComponent<TextMeshProUGUI>().text = "";
                GameObject.Find("description").GetComponent<TextMeshProUGUI>().text = "";
                selectedItem = null;
                playerInventory.Container.Items.Remove(playerInventory.Container.Items[i]);
            }
        }
    }

    void OnDrawGizmosSelected() //displays the area in of interact range
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(transform.position, interactRange);
    }
    //==============================================================================
    //  Take Damage and Heal and Dead
    //==============================================================================

    public void takeDamage(int damage)
    {
        currentHealth -= (damage - defence);
        FlashRed();
        healthbar.damageHealth(damage);
    }

    public void heal(int health)
    {
        currentHealth += health;
        healthbar.heal(health);
    }

    public void checkDead() //When the player dies
    {
        if (currentHealth <= 0)
        {
            playerInventory.inventoryClear();
        }
    }

    //==============================================================================
    //  Inventory
    //==============================================================================

    public void onOffInventory()
    {
        if (Input.)
        {

        }
    }

    public void openInventory()
    {
        InventoryDisplay.SetActive(true);
    }

    public void closeInventory()
    {
        InventoryDisplay.SetActive(false);
    }

    public void saveInventory()
    {
        //playerInventory.Save();
        SaveSystem.savePlayer(this);
    }

    public void loadInventory()
    {
        //playerInventory.Load();
        data = SaveSystem.loadPlayer();
        playerInventory = data.playerInventory;
        currentHealth = data.playerHealth;
        coins = data.playerMoney;
        //transform.position = new Vector3(data.playerPosition[0], data.playerPosition[1], data.playerPosition[2]);
    }
    //==============================================================================
    //  Change Color after hit
    //==============================================================================
    void FlashRed()
    {
        headRenderer.color = damagedColor;
        bodyRenderer.color = damagedColor;
        legRenderer.color = damagedColor;
        Invoke("ResetColor", flashTime);
    }
    void ResetColor()
    {
        headRenderer.color = Color.white;
        bodyRenderer.color = Color.white;
        legRenderer.color = Color.white;
    }

    private void OnApplicationQuit()
    {
        playerInventory.Container.Items.Clear();
    }
}
