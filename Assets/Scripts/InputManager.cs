using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public Dialogue[] dialogues;
    public Event[] events;
    public DialogueReader reader;
    public bool isReaded;
    private void Start()
    {
        dialogues = gameObject.GetComponent<InteractionEvent>().GetDialogue();
        events = gameObject.GetComponent<InteractionEvent>().GetEvent();
    }
    public void StartReading()
    {
        if(isReaded)
        {
            return;
        }
        reader.SetDialogue(dialogues, events);
    }
}
