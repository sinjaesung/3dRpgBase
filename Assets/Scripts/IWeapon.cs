using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IWeapon 
{
    List<BaseStat> Stats { get; set; }
    public int CurrentDamage { get; set; }
    void PerformAttack(int damage);
    void PerformSpecialAtack();
}
