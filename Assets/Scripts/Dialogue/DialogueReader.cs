using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueReader : MonoBehaviour
{
    private InputManager input;
    private Dialogue[] dialogues;
    [SerializeField] private bool isReading = false;
    private float time;
    [SerializeField] private float typingtime = 0.02f;
    private int wordIndex;
    private int typeIndex = 0;
    private int ContextsIndex = 0;
    [SerializeField] private bool isTyping = false;
    public void SetDialogue(Dialogue[] _Set)
    {
        dialogues = _Set;
        StartReading();
    }
    public void Update()
    {
        if (isReading && Input.GetKeyDown(KeyCode.Space))
        {
            if (isTyping)
            {
                if(typeIndex == 0)
                {
                    return;
                }
                isTyping = false;
                wordIndex = 0;

                UIManager.instance.TalkPanel_Change(dialogues[typeIndex].name, dialogues[typeIndex].contexts[ContextsIndex]);
            }
            else
            {
                if (typeIndex == dialogues.Length)
                {
                    isTyping = false;
                    isReading = false;
                    UIManager.instance.TalkPanel_Close();
                    typeIndex = 0;
                }
                else
                {
                    isTyping = true;
                    if (dialogues[typeIndex].contexts.Length > ContextsIndex + 1)
                    {
                        ContextsIndex++;
                    }
                    else
                    {
                        if (typeIndex + 1 == dialogues.Length)
                        {
                            isTyping = false;
                            isReading = false;
                            UIManager.instance.TalkPanel_Close();
                            typeIndex = 0;
                        }
                        typeIndex++;
                        ContextsIndex = 0;
                    }
                }
            }
        }
    }
    public void FixedUpdate()
    {
        if (isTyping)
        {
            time += Time.deltaTime;
            if (time > typingtime)
            {
                time = 0;
                wordIndex++;
                if (wordIndex > dialogues[typeIndex].contexts[ContextsIndex].Length)
                {
                    isTyping = false;
                    wordIndex = 0;
                }
                else
                {
                    UIManager.instance.TalkPanel_Change_WithTyping(dialogues[typeIndex].name, dialogues[typeIndex].contexts[ContextsIndex], wordIndex);
                }
            }
        }
    }
    public bool GetisReading()
    {
        return isReading;
    }
    public void StartReading()
    {
        isReading = true;
        isTyping = true;
    }

}