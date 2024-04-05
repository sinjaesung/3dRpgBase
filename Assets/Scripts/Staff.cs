using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Staff : MonoBehaviour, IWeapon, IProjectileWeapon
{
    private Animator animator;
    public List<BaseStat> Stats { get; set; }
    public int CurrentDamage { get; set; }
    public Transform ProjectileSpawn { get; set; }
    Fireball fireball;

    void Start()
    {
        fireball = Resources.Load<Fireball>("Weapons/Projectiles/Fireball");
        animator = GetComponent<Animator>();
    }
    public void PerformAttack(int damage)
    {
        CurrentDamage = damage;
        Debug.Log("���� fireball������!:" + damage);
        Fireball.SetDamage(damage);
        animator.SetTrigger("Base_Attack");
    }

    public void PerformSpecialAtack()
    {
        animator.SetTrigger("Special_Attack");
    }

    public void CastProjectile()
    {
        Debug.Log("CastProjectileȣ��");
        Fireball fireballInstance = (Fireball)Instantiate(fireball, ProjectileSpawn.position, ProjectileSpawn.rotation);
        fireballInstance.Direction = ProjectileSpawn.forward;
    }

}
