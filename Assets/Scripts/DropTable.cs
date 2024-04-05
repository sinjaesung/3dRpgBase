using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropTable
{
    public List<LootDrop> loot;

    public Item GetDrop()
    {
        int roll = Random.Range(0, 101);
        Debug.Log("GetDrop roll:" + roll);
        int weightSum = 0;
        int orderIndex = 0;//초기맨위에 순서의 아이템일수록 드랍확률 낮음!!!
        foreach (LootDrop drop in loot)
        {
            weightSum += drop.Weight;
            Debug.Log("초기순서index아이템일수록 드랍확률 낮음! 아래로 내려갈수록 드랍확률 커짐!! drop and weightSum:" + "("+ orderIndex+")"+drop + "," + weightSum);
            if(roll < weightSum)
            {
                Debug.Log("roll0~100범위값이 weightSum보다 더 범위가 작았던경우 범위안으로 아이템 드랍:"+ "(" + orderIndex + ")"+ drop.ItemSlug+":"+ drop.Weight+"|" + "," + roll + "," + weightSum);
                return ItemDatabase.Instance.GetItem(drop.ItemSlug);
            }
            else
            {
                Debug.Log("roll0~100범위값이 weightSum보다 더 범위가 큰경우 범위밖이라는 뜻 아이템 미드랍:" + "(" + orderIndex + ")" + drop.ItemSlug + ":" + drop.Weight + "|" + "," + roll + "," + weightSum);
            }
            orderIndex++;
        }
        return null;
    }
}

public class LootDrop
{
    public string ItemSlug { get; set; }
    public int Weight { get; set; }

    public LootDrop(string itemSlug,int weight)
    {
        this.ItemSlug = itemSlug;
        this.Weight = weight;
    }
}