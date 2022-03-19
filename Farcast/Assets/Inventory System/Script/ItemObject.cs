using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum itemType
{
    Food,
    Weapon,
    Armor,
    Default
}

public class ItemObject : ScriptableObject
{
    public int Id;
    public Sprite uiDisplay;
    public itemType type;
    [TextArea(15,20)]
    public string description;

}

