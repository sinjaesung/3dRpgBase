using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    public Vector3 Direction { get; set; }
    public float Range { get; set; }
    public static int Damage { get; set; }

    Vector3 spawnPosition;

    private void Start()
    {
        Range = 20f;
        //Damage = 4;
        spawnPosition = transform.position;
        GetComponent<Rigidbody>().AddForce(Direction * 50f);
    }
    public static void SetDamage(int damages)
    {
        Debug.Log("fireball적용 데미지:" + damages);
        Damage = damages;
    }
    private void Update()
    {
        //Debug.Log("현재 fireball damage적용값은?:" + Damage);
        if (Vector3.Distance(spawnPosition,transform.position) >= Range)
        {
            Extinguish();
        }
    }
    private void OnCollisionEnter(Collision col)
    {
        if(col.transform.tag == "Enemy")
        {
            Debug.Log("부딪힌 오브젝트가Enemy인경우 데미지를 준다" + col.transform.tag);
            Debug.Log("fireball데미지 캐릭터스탯에 더한 최종적산출데미지:" + Damage);
            col.transform.GetComponent<IEnemy>().TakeDamage(Damage);
        }
        else if(col.transform.tag == "Projectile")
        {
            Debug.Log("서로 부딪힌 오브젝트가 서로 Projectile끼리가 아닌경우만 삭제되도록"+ col.transform.tag);
            return;
        }
        Extinguish();
    }

    void Extinguish()
    {
        Destroy(gameObject);
    }
}
