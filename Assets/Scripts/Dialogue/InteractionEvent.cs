
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionEvent : MonoBehaviour
{
    [SerializeField] DialogueEvent dialogue;
    [SerializeField] Event_GetLine event_getLine;
    public Dialogue[] GetDialogue()
    {
        dialogue.dialogues = DataBaseManager.instance.GetDialogueALL();
        return dialogue.dialogues;
    }
    public Event[] GetEvent()
    {
        event_getLine.dialogues = DataBaseManager.instance.GetEventALL();
        return event_getLine.dialogues;
    }
}