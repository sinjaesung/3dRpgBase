using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupItem : Interactable
{
    public Item ItemDrop { get; set; }

    public override void Interact()
    {
        if (ItemDrop != null)
        {
            Debug.Log("itemDrop¹ºµ¥?:" + ItemDrop.ItemName);
            InventoryController.Instance.GiveItem(ItemDrop);
            Destroy(gameObject);
        }
       
    }
}
