using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUIItem : MonoBehaviour
{
    public Item item;

    public TextMeshProUGUI itemText;
    public Image itemImage;

    public void SetItem(Item item)
    {
        Debug.Log("SetItem:" + item);
        this.item = item;
        SetupItemValues();
    }
    
    void SetupItemValues()
    {
        Debug.Log("setupItemValuess:" + item.ItemName);
        itemText.text = item.ItemName;
        itemImage.sprite = Resources.Load<Sprite>("UI/Icons/Items/" + item.ObjectSlug);
    }

    public void OnSelectItemButton()
    {
        Debug.Log("OnSelectItemButton:" + GetComponent<Button>());
        InventoryController.Instance.SetItemDetails(item, GetComponent<Button>());
    }
}
