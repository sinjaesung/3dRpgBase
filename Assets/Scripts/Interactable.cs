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
                //stoppingDISTANCE가 3이 되었던경우에만 이러한 구조 성립
                //(즉 interactable오브젝트 클릭하여
                //그쪽으로 달려간경우에만 해당) 근처도달했던경우만 interacted=true로 하여 도달한이후엔 interacted실행안되게
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
