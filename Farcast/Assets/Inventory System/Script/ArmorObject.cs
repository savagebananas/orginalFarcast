using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Armor Object", menuName = "Inventory System/Items/Armor")]
public class ArmorObject : ItemObject
{
    public int defenceBonus;
    public int physicalAttackBonus;
    public int magicAttackBonus;
    public int speedBonus;
    public float knockbackRes;

    private void Awake()
    {
        type = itemType.Armor;
    }
}
