using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData : MonoBehaviour
{
    public InventoryObject playerInventory;
    public float[] playerPosition;
    public int playerHealth;
    public int playerMoney;

    public PlayerData(playerGeneral player)
    {
        playerInventory = player.playerInventory;
        playerHealth = player.currentHealth;
        playerMoney = player.coins;

        //playerPosition[0] = playerReference.transform.position.x;
        //playerPosition[1] = playerReference.transform.position.y;
        //playerPosition[2] = playerReference.transform.position.z;
    }
}
