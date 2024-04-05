using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal
{
    public Quest Quest { get; set; }
    public string Description { get; set; }
    public bool Completed { get; set; }
    public int CurrentAmount { get; set; }
    public int RequiredAmount { get; set;}

    public virtual void Init()
    {
        // default init stuff
    }
    public void Evalaute()
    {
        if(CurrentAmount >= RequiredAmount)
        {
            Debug.Log("Goal curAmount>=ReqAmount 만족 Completes.퀘스트 checkgoals");
            Complete();
        }
    }

    public void Complete()
    {
        Quest.CheckGoals();
        Completed = true;
        Debug.Log("Goal marked as completed.");
    }
}
