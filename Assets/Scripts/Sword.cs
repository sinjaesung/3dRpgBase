using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour, IWeapon
{
    private Animator animator;
    public List<BaseStat> Stats { get; set; }
    Player Player { get; set; }
    public int CurrentDamage{ get; set; }

    void Start()
    {
        animator = GetComponent<Animator>();
    }
    public void PerformAttack(int damage)
    {
        CurrentDamage = damage;
        animator.SetTrigger("Base_Attack");
    }

    public void PerformSpecialAtack()
    {
        animator.SetTrigger("Special_Attack");
    }

    void OnTriggerEnter(Collider col)
    {
        if(col.tag == "Enemy")
        {
            //characterStats = Player.getStatus();
            //int damage= CharacterStats.GetStat(BaseStat.BaseStatType.Power).GetCalculatedStatValue();
            Debug.Log("계산된 캐릭터의 데미지 적용:" + CurrentDamage);
            col.GetComponent<IEnemy>().TakeDamage(CurrentDamage);
        }
    }
}
