using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : Singleton<UIManager>
{
    public ChangeName changeName;
    public Image StartPage_Image;
    public Image OptionBackGround_Image;
    public Image Story_Image;
    public Image InputName_Image;
    [SerializeField] private GameObject TalkPanel_Image;
    [SerializeField] private TextMeshProUGUI TalkPanel_Name_TMP;
    [SerializeField] private TextMeshProUGUI TalkPanel_Content_TMP;

    public void TalkPanel_Change(string name, string content = null)
    {
        if (!TalkPanel_Image.gameObject.activeSelf)
        {
            TalkPanel_Image.gameObject.SetActive(true);
        }
        if (content == null)
        {
            TalkPanel_Image.gameObject.SetActive(false);
        }
        else
        {
            if(name == "���ؽ�")
            {
                name = changeName.PlayerName;
            }
            content = content.Replace("���ؽ�", changeName.PlayerName);
            content = content.Replace("`", ",");
            TalkPanel_Name_TMP.text = name;
            TalkPanel_Content_TMP.text = content;
        }
    }
    public void TalkPanel_Change_WithTyping(string name, string content = null, int typingIndex = 0)
    {
        if (!TalkPanel_Image.gameObject.activeSelf)
        {
            TalkPanel_Image.gameObject.SetActive(true);
        }
        if (content == null)
        {
            TalkPanel_Image.gameObject.SetActive(false);
        }
        else
        {
            if (name == "���ؽ�")
            {
                name = changeName.PlayerName;
            }
            TalkPanel_Name_TMP.text = name;

            content = content.Replace("���ؽ�", changeName.PlayerName);
            content = content.Replace("`", ",");
            TalkPanel_Content_TMP.text = content.Substring(0, typingIndex);

        }
    }
    public void TalkPanel_Close()
    {
        TalkPanel_Image.gameObject.SetActive(false);
    }
}
