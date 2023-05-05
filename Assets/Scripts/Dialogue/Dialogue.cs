using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Dialogue
{
    [Tooltip("대사 치는 캐릭터 이름")]
    public string name;
    [Tooltip("상대의 얼굴")]
    public string picture;
    [Tooltip("대사 내용")]
    public string[] contexts;
    [Tooltip("이벤트 번호")]
    public string[] number;
    [Tooltip("스킵라인")]
    public string[] skipnum;
    [Tooltip("fade 기능")]
    public string[] fade;
}

[System.Serializable]
public class DialogueEvent
{
    public string eventName;
    public Dialogue[] dialogues;
}
