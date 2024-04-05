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
        int orderIndex = 0;//�ʱ������ ������ �������ϼ��� ���Ȯ�� ����!!!
        foreach (LootDrop drop in loot)
        {
            weightSum += drop.Weight;
            Debug.Log("�ʱ����index�������ϼ��� ���Ȯ�� ����! �Ʒ��� ���������� ���Ȯ�� Ŀ��!! drop and weightSum:" + "("+ orderIndex+")"+drop + "," + weightSum);
            if(roll < weightSum)
            {
                Debug.Log("roll0~100�������� weightSum���� �� ������ �۾Ҵ���� ���������� ������ ���:"+ "(" + orderIndex + ")"+ drop.ItemSlug+":"+ drop.Weight+"|" + "," + roll + "," + weightSum);
                return ItemDatabase.Instance.GetItem(drop.ItemSlug);
            }
            else
            {
                Debug.Log("roll0~100�������� weightSum���� �� ������ ū��� �������̶�� �� ������ �̵��:" + "(" + orderIndex + ")" + drop.ItemSlug + ":" + drop.Weight + "|" + "," + roll + "," + weightSum);
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