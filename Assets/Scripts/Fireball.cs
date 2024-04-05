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
        Debug.Log("fireball���� ������:" + damages);
        Damage = damages;
    }
    private void Update()
    {
        //Debug.Log("���� fireball damage���밪��?:" + Damage);
        if (Vector3.Distance(spawnPosition,transform.position) >= Range)
        {
            Extinguish();
        }
    }
    private void OnCollisionEnter(Collision col)
    {
        if(col.transform.tag == "Enemy")
        {
            Debug.Log("�ε��� ������Ʈ��Enemy�ΰ�� �������� �ش�" + col.transform.tag);
            Debug.Log("fireball������ ĳ���ͽ��ȿ� ���� ���������ⵥ����:" + Damage);
            col.transform.GetComponent<IEnemy>().TakeDamage(Damage);
        }
        else if(col.transform.tag == "Projectile")
        {
            Debug.Log("���� �ε��� ������Ʈ�� ���� Projectile������ �ƴѰ�츸 �����ǵ���"+ col.transform.tag);
            return;
        }
        Extinguish();
    }

    void Extinguish()
    {
        Destroy(gameObject);
    }
}
