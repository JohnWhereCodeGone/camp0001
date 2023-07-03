using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public abstract class Item
{
    [Header("Weapon Variables")]
    public Sprite itemImage;
    public string itemID;
    public string itemName;
    [TextArea(2,5)]
    public string itemDescription;


    public virtual string GetDescription()
    {
        string NEW_DESCRIPTION = itemDescription;

        return itemDescription;
    }
}
[System.Serializable]
public class Weapon : Item
{
    public int damage;

    public void EquipItem()
    {

    }
    public override string GetDescription()
    {
        string NEW_DESCRIPTION = base.GetDescription();
        NEW_DESCRIPTION = NEW_DESCRIPTION.Replace("DMG", damage.ToString());
        return NEW_DESCRIPTION;
    }
}
[System.Serializable]
public class Metal : Item
{
    [Header("Metal Variables")]
    public string atomicMass;
    public string isItShiny;

    public override string GetDescription()
    {
        string NEW_DESCRIPTION = base.GetDescription();
        NEW_DESCRIPTION = NEW_DESCRIPTION.Replace("AtomicMass", atomicMass.ToString());
        NEW_DESCRIPTION = NEW_DESCRIPTION.Replace("isItShiny", isItShiny.ToString());
        return NEW_DESCRIPTION;
    }
}

[System.Serializable]
public class Armor : Item
{
    [Header("Armor Variables")]
    public EquipSlot equipSlot;

    public override string GetDescription()
    {
        string NEW_DESCRIPTION = base.GetDescription();

        NEW_DESCRIPTION = NEW_DESCRIPTION.Replace("DMG", equipSlot.ToString());
        return NEW_DESCRIPTION;
    }

   
}
public enum EquipSlot
{
    Chest, Head, Feet, LeftHand, RightHand, oneHand, BothHands
}

