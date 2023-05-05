using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : Singleton<UIManager>
{
    public ChangeName changeName;
    public ClickBtn clickBtn;
    public Image StartPage_Image;
    public Image OptionBackGround_Image;
    public Image Story_Image;
    public Image InputName_Image;
    public Button ClickBtn_1;
    public Button ClickBtn_2;
    public Button ClickBtn_3;
    public TextMeshProUGUI ClickBtn_1_TMP;
    public TextMeshProUGUI ClickBtn_2_TMP;
    public TextMeshProUGUI ClickBtn_3_TMP;
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
            if(name == "엄준식")
            {
                name = changeName.PlayerName;
            }
            content = content.Replace("엄준식", changeName.PlayerName);
            content = content.Replace("준식", changeName.PlayerName);
            content = content.Replace("`", ",");
            TalkPanel_Name_TMP.text = name;
            TalkPanel_Content_TMP.text = content;
        }
    }
    public void TalkPanel_Change_WithTyping(string name, string pictureName, string content, int typingIndex = 0)
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
            if (name == "엄준식")
            {
                name = changeName.PlayerName;
            }
            TalkPanel_Name_TMP.text = name;

            content = content.Replace("엄준식", changeName.PlayerName);
            content = content.Replace("준식", changeName.PlayerName);
            content = content.Replace("`", ",");
            TalkPanel_Content_TMP.text = content.Substring(0, typingIndex);
            if(pictureName == "" || pictureName == null)
            {
                ;
            }
            else
            {
                StoryBackGroundpicture(pictureName);
            }
        }
    }
    public void TalkPanel_Close()
    {
        TalkPanel_Image.gameObject.SetActive(false);
    }
    public void StoryBackGroundpicture(string pictureName)
    {
        Sprite NeedChangePicture = Resources.Load<Sprite>(pictureName);
        Story_Image.sprite = NeedChangePicture;
    }
    public void ClickBtns_Change(string text1,int nextNum1, string text2, int nextNum2, string text3 = null, int nextNum3 = 0)
    {
        if(text3 == null || text3 == "")
        {
            ClickBtn_1.gameObject.SetActive(true);
            clickBtn.ChangeNum1 = nextNum1;
            ClickBtn_2.gameObject.SetActive(true);
            clickBtn.ChangeNum2 = nextNum2;
            ClickBtn_1_TMP.text = text1;
            ClickBtn_2_TMP.text = text2;
        }
        else
        {
            ClickBtn_1.gameObject.SetActive(true);
            clickBtn.ChangeNum1 = nextNum1;
            ClickBtn_2.gameObject.SetActive(true);
            clickBtn.ChangeNum2 = nextNum2;
            ClickBtn_3.gameObject.SetActive(true);
            clickBtn.ChangeNum3 = nextNum3;
            ClickBtn_1_TMP.text = text1;
            ClickBtn_2_TMP.text = text2;
            ClickBtn_3_TMP.text = text3;
        }
    }
}