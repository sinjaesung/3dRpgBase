using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLevel : MonoBehaviour
{
    public int Level { get; set; }
    public int CurrentExperience { get; set; }
    public int RequiredExperience { get { return Level * 25; } }

    private void Start()
    {
        CombatEvents.OnEnemyDeath += EnemyToExperience;
        Level = 1;
    }

    public void EnemyToExperience(IEnemy enemy)
    {
        GrantExperience(enemy.Experience);
    }
    public void GrantExperience(int amount)
    {
        CurrentExperience += amount;
        while(CurrentExperience >= RequiredExperience)
        {
            Debug.Log("현재 레벨과 필요 경험치:" + Level+","+RequiredExperience);

            CurrentExperience -= RequiredExperience;
            Level++;
        }
        UIEventHandler.PlayerLevelChanged();
    }
}
