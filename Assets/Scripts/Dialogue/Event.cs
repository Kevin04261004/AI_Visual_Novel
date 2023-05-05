using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Event
{
    [Tooltip("��ư ����")]
    public string[] context;
    [Tooltip("�ű����")]
    public int[] changeLine;
}

[System.Serializable]
public class Event_GetLine
{
    public string eventName;

    public Event[] dialogues;
}