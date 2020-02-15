using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    public QuestObject[] quests;
    public bool[] questCompleted;

    public DialogueManager dMan;

    public string itemCollected;

    public string enemyKilled;

    // Start is called before the first frame update
    void Start()
    {
        questCompleted = new bool[quests.Length];
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowQuestText(string questText)
    {
        dMan.dialogLines = new string[1];
        dMan.dialogLines[0] = questText;


        dMan.currentLine = 0;
        dMan.ShowDialogue();
    }
}
