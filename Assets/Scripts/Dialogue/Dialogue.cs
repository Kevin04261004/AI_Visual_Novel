using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Dialogue
{
    [Tooltip("��� ġ�� ĳ���� �̸�")]
    public string name;
    [Tooltip("���ȭ��")]
    public string background;
    [Tooltip("ĳ�����̸�_ǥ��")]
    public string characterPicture;
    [Tooltip("��� ����")]
    public string[] contexts;
    [Tooltip("�̺�Ʈ ��ȣ")]
    public string[] number;
    [Tooltip("��ŵ����")]
    public string[] skipnum;
    [Tooltip("fade ���")]
    public string[] fade;
}

[System.Serializable]
public class DialogueEvent
{
    public string eventName;
    public Dialogue[] dialogues;
}
