using System.Collections.Generic;
using UnityEngine;

public enum ItemType { Consumable, Equipment, Material, Quest, Currency}

[CreateAssetMenu(fileName = "Item_New", menuName = "RPG Data/Item")]
public class ItemData : ScriptableObject
{
    [Header("Info")]
    public string itemId;
    public string itemName;
    public ItemType itemType;
    public Sprite icon;

    [TextArea]
    public string description;

    [Header("Info")]
    public int buyPrice;
    public int sellPrice;

    [Header("Info")]
    public bool canUse;
    public bool canStack;
    public int maxStackCount = 99;

    [Header("Effect")]
    public List<ItemEffect> effects = new List<ItemEffect>();
}