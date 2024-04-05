using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Quest : MonoBehaviour
{
    public List<Goal> Goals { get; set; }
    public string QuestName { get; set; }
    public string Description { get; set; }
    public int ExperienceReward { get; set; }
    public Item ItemReward { get; set; }
    public bool Completed { get; set; }

    public void CheckGoals()
    {
        for(int i=0; i<Goals.Count; i++)
        {
            Debug.Log("nowGoal countingss:" + Goals[i].CurrentAmount + "/" + Goals[i].RequiredAmount);
        }
        Completed = Goals.All(g => g.Completed);//모든 goal개별적으로 completed 만족하는지 여부 검사.
    }

    public void GiveReward()
    {
        if (ItemReward != null)
            InventoryController.Instance.GiveItem(ItemReward);
    }
}
