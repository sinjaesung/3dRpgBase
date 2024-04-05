using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Interactable : MonoBehaviour
{
    [HideInInspector]
    public NavMeshAgent playerAgent;
    private bool hasInteracted;
    bool isEnemy;

    public virtual void MoveToInteraction(NavMeshAgent playerAgent)
    {
        Debug.Log("MoveToInteracdtion");
        isEnemy = gameObject.tag == "Enemy";
        hasInteracted = false;
        this.playerAgent = playerAgent;
        playerAgent.stoppingDistance = 3f;
        playerAgent.destination = this.transform.position;
    }

    private void Update()
    {
        if (!hasInteracted && playerAgent != null && !playerAgent.pathPending)
        {
            Debug.Log("remainingDistance??:" + playerAgent.remainingDistance);
            Debug.Log("stoppingDistance??:" + playerAgent.stoppingDistance);
            Debug.Log("pathPending??:" + !playerAgent.pathPending);
            if (playerAgent.remainingDistance < playerAgent.stoppingDistance)
            {
                if (!isEnemy)
                    Interact();
                //stoppingDISTANCE�� 3�� �Ǿ�����쿡�� �̷��� ���� ����
                //(�� interactable������Ʈ Ŭ���Ͽ�
                //�������� �޷�����쿡�� �ش�) ��ó�����ߴ���츸 interacted=true�� �Ͽ� ���������Ŀ� interacted����ȵǰ�
                EnsureLookDirection();
                hasInteracted = true;
            }
        }
    }

    void EnsureLookDirection()
    {
        Debug.Log("EnsureLookDirection:");
        playerAgent.updateRotation = false;
        Vector3 lookDirection = new Vector3(transform.position.x, playerAgent.transform.position.y, transform.position.z);
        playerAgent.transform.LookAt(lookDirection);
        playerAgent.updateRotation = true;
    }
    public virtual void Interact()
    {
        Debug.Log("Interacting with base class.");
    }
}
