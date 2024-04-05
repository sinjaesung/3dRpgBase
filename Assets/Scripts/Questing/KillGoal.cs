using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class KillGoal : Goal
{
    public int EnemyID { get; set; }

    public KillGoal(Quest quest,int enemyID,string description, bool completed, int currentAmount, int requireAmount)
    {
        this.Quest = quest;
        this.EnemyID = enemyID;
        this.Description = description;
        this.Completed = completed;
        this.CurrentAmount = currentAmount;
        this.RequiredAmount = requireAmount;
    }

    public override void Init()
    {
        base.Init();
        CombatEvents.OnEnemyDeath += EnemyDied;
    }

    void EnemyDied(IEnemy enemy)
    {
        if(enemy.ID == this.EnemyID)
        {
            Debug.Log("enemy.ID ,this.EnemyID: enemyDied" + enemy.ID + "," + this.EnemyID);
            this.CurrentAmount++;
            Evalaute();
        }
    }
}
