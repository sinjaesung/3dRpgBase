using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestGiver : NPC
{
    public bool AssignedQuest { get; set; }
    public bool Helped { get; set; }

    [SerializeField]
    private GameObject quests;

    [SerializeField]
    private string questType;
    public Quest Quest { get; set; }
    public override void Interact()
    {
        if(!AssignedQuest && !Helped)
        {
            // assign 완전처음상태라면 다이아로그띄우기랑, 퀘스트개체 설정작업
            Debug.Log("초기 대화창 설정 최초questGiver interact");
            base.Interact();
            AssignQuest();
        }
        else if(AssignedQuest && !Helped)
        {
            // check, 퀘스트설정되어있고 미완료퀘스트상태라면 checkQuest진행
            CheckQuest();
        }
        else
        {
            //완료된 퀘스트상태라면 처리.
            DialogueSystem.Instance.AddNewDialogue(new string[] { "Thanks for that stuff that one time." }, name);
        }
    }

    void AssignQuest()
    {
        AssignedQuest = true;
        Quest = (Quest)quests.AddComponent(System.Type.GetType(questType));
    }

    void CheckQuest()
    {
        if (Quest.Completed)
        {
            Quest.GiveReward();
            Helped = true;
            AssignedQuest = false;
            DialogueSystem.Instance.AddNewDialogue(new string[] { "Thanks for that! Here's your reward.", "More dialogue" }, name);
        }
        else
        {
            DialogueSystem.Instance.AddNewDialogue(new string[] { "You're still in the middle of helping me. Get back at it!"}, name);
        }
    }
}
