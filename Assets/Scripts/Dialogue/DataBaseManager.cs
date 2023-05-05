using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DataBaseManager : MonoBehaviour
{
    public static DataBaseManager instance;
    [SerializeField] string csv_FileName_Dialogue;
    [SerializeField] string csv_FileName_Event;
    private Dialogue[] dialogues;
    private Event[] events;
    Dictionary<int, Dialogue> dialogueDic = new Dictionary<int, Dialogue>();
    Dictionary<int, Event> eventDic = new Dictionary<int, Event>();
    public static bool isFinish = false;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DialogueParser theParser = GetComponent<DialogueParser>();
            dialogues = theParser.Parse(csv_FileName_Dialogue);
            events = theParser.ParseEvent(csv_FileName_Event);
            for (int i = 0; i < dialogues.Length; i++)
            {
                dialogueDic.Add(i + 1, dialogues[i]);
            }
            for (int i = 0; i < events.Length; i++)
            {
                eventDic.Add(i + 1, events[i]);
            }
            isFinish = true;
        }
    }

    public Dialogue[] GetDialogueALL()
    {
        List<Dialogue> dialogueList = new List<Dialogue>();

        for (int i = 0; i < dialogues.Length; i++)
        {
            dialogueList.Add(dialogueDic[i+1]);
        }
        return dialogueList.ToArray();
    }
    public Event[] GetEventALL()
    {
        List<Event> eventList = new List<Event>();

        for (int i = 0; i < events.Length; i++)
        {
            eventList.Add(eventDic[i+1]);
        }
        return eventList.ToArray();
    }

}