using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Event
{
    [Tooltip("버튼 글자")]
    public string[] context;
    [Tooltip("옮길라인")]
    public int[] changeLine;
}

[System.Serializable]
public class Event_GetLine
{
    public string eventName;

    public Event[] dialogues;
}