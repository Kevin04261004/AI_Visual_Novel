using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueReader : MonoBehaviour
{
    private InputManager input;
    [SerializeField] private Dialogue[] dialogues;
    private Event[] events;
    [SerializeField] private bool isReading = false;
    private float time;
    [SerializeField] private float typingtime = 0.02f;
    private int wordIndex;
    [SerializeField] private int typeIndex = 0;
    private int ContextsIndex = 0;
    [SerializeField] private bool OnlyReadNoPlus;
    [SerializeField] private bool isNeedToClickBtn = false;
    [SerializeField] private bool isTyping = false;
    public void SetDialogue(Dialogue[] _Set, Event[] _Set2)
    {
        dialogues = _Set;
        events = _Set2;
        StartReading();
    }
    public void Update()
    {
        if (isNeedToClickBtn || FadeManager.instance.isFading)
            return;
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
                if (!string.IsNullOrEmpty(dialogues[typeIndex].number[ContextsIndex]) && int.TryParse(dialogues[typeIndex].number[ContextsIndex], out int eventnum))
                {
                    eventnum -= 1;
                    isNeedToClickBtn = true;
                    int length = events[eventnum].context.Length;
                    if (length == 2)
                    {
                        UIManager.instance.ClickBtns_Change(events[eventnum].context[0], events[eventnum].changeLine[0], events[eventnum].context[1], events[eventnum].changeLine[1]);
                    }
                    else if (length == 3)
                    {
                        UIManager.instance.ClickBtns_Change(events[eventnum].context[0], events[eventnum].changeLine[0], events[eventnum].context[1], events[eventnum].changeLine[1],events[eventnum].context[2], events[eventnum].changeLine[2]);
                    }

                }
                if (!string.IsNullOrEmpty(dialogues[typeIndex].skipnum[ContextsIndex]) && int.TryParse(dialogues[typeIndex].skipnum[ContextsIndex], out int skipnum))
                {
                    skipnum -= 1;

                    typeIndex = skipnum;
                    ContextsIndex = 0;
                    OnlyReadNoPlus = true;
                }
                //UIManager.instance.ClickBtns_Change()
            }
            else
            {
                if (!string.IsNullOrEmpty(dialogues[typeIndex].fade[ContextsIndex]) && int.TryParse(dialogues[typeIndex].fade[ContextsIndex], out int Fadenum))
                {
                    if (Fadenum == 0)
                    {
                        UIManager.instance.StoryBackGroundpicture(dialogues[typeIndex+1].background);
                        StartCoroutine(FadeManager.instance.FadeIn());
                    }
                    else if (Fadenum == 1)
                    {
                        StartCoroutine(FadeManager.instance.FadeOut());
                    }
                    else if (Fadenum == 2)
                    {
                        UIManager.instance.StoryBackGroundpicture(dialogues[typeIndex+1].background);
                        StartCoroutine(FadeManager.instance.FlashIn());
                    }
                    else if (Fadenum == 3)
                    {
                        StartCoroutine(FadeManager.instance.FlashOut());
                    }
                    StartCoroutine(fadeAfter());
                }
                else
                {
                    if (OnlyReadNoPlus)
                    {
                        isTyping = true;
                        OnlyReadNoPlus = false;
                        return;
                    }
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
                                typeIndex = -1;
                            }
                            typeIndex++;
                            ContextsIndex = 0;
                        }
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
                    if (!string.IsNullOrEmpty(dialogues[typeIndex].number[ContextsIndex]) && int.TryParse(dialogues[typeIndex].number[ContextsIndex], out int eventnum))
                    {
                        eventnum -= 1;
                        isNeedToClickBtn = true;
                        int length = events[eventnum].context.Length;
                        if (length == 2)
                        {
                            UIManager.instance.ClickBtns_Change(events[eventnum].context[0], events[eventnum].changeLine[0], events[eventnum].context[1], events[eventnum].changeLine[1]);
                        }
                        else if (length == 3)
                        {
                            UIManager.instance.ClickBtns_Change(events[eventnum].context[0], events[eventnum].changeLine[0], events[eventnum].context[1], events[eventnum].changeLine[1], events[eventnum].context[2], events[eventnum].changeLine[2]);
                        }

                    }
                    if (!string.IsNullOrEmpty(dialogues[typeIndex].skipnum[ContextsIndex]) && int.TryParse(dialogues[typeIndex].skipnum[ContextsIndex], out int skipnum))
                    {
                        skipnum -= 1;
                        typeIndex = skipnum;
                        ContextsIndex = 0;
                        OnlyReadNoPlus = true;
                    }
                    wordIndex = 0;
                }
                else
                {
                    UIManager.instance.TalkPanel_Change_WithTyping(dialogues[typeIndex].name, dialogues[typeIndex].background, dialogues[typeIndex].characterPicture, dialogues[typeIndex].contexts[ContextsIndex], wordIndex);
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
    public void isNeedToClickBtnFalse()
    {
        isNeedToClickBtn = false;
    }
    public void TypeIndexChange(int _typeindex)
    {
        typeIndex = _typeindex;
    }
    public IEnumerator fadeAfter()
    {
        yield return new WaitForSeconds(FadeManager.instance.FadeInSpeed);
        if (OnlyReadNoPlus)
        {
            isTyping = true;
            OnlyReadNoPlus = false;
            yield break;
        }
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
                    typeIndex = -1;
                }
                typeIndex++;
                ContextsIndex = 0;
            }
        }
    }
}