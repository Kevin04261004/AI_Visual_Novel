using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : Singleton<UIManager>
{
    public ChangeName changeName;
    public ClickBtn clickBtn;
    public Image StartPage_Image;
    public Image OptionBackGround_Image;
    public Image Story_Image;
    public Image Character_Image;
    public Image InputName_Image;
    public Image RealExit_Image;
    public Button ClickBtn_1_Btn;
    public Button ClickBtn_2_Btn;
    public Button ClickBtn_3_Btn;
    public Button Exit_Btn;
    public Button ExitNope_Btn;
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
    public void TalkPanel_Change_WithTyping(string name, string backgroundName, string characterName, string content, int typingIndex = 0)
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
            content = content.Replace("준식", changeName.PlayerName.Substring(1,2));
            content = content.Replace("`", ",");

            TalkPanel_Content_TMP.text = content.Substring(0, typingIndex);
            if(string.IsNullOrEmpty(backgroundName))
            {
                ;
            }
            else
            {
                StoryBackGroundpicture(backgroundName);
            }
            if (string.IsNullOrEmpty(characterName))
            {
                ;
            }
            else
            {
                Characterpicture(characterName);
            }

        }
    }
    public void TalkPanel_Close()
    {
        TalkPanel_Image.gameObject.SetActive(false);
    }
    public void TalkPanel_Open()
    {
        TalkPanel_Image.gameObject.SetActive(true);
    }
    public void StoryBackGroundpicture(string pictureName)
    {
        Sprite NeedChangePicture = Resources.Load<Sprite>(pictureName);
        Story_Image.sprite = NeedChangePicture;
    }
    public void Characterpicture(string pictureName)
    {
        if(pictureName == "x" || pictureName == "X")
        {
            Character_Image.gameObject.SetActive(false);
            return;
        }
        Character_Image.gameObject.SetActive(true);
        Sprite NeedChangePicture = Resources.Load<Sprite>(pictureName);
        Character_Image.sprite = NeedChangePicture;
    }
    public void ClickBtns_Change(string text1,int nextNum1, string text2, int nextNum2, string text3 = null, int nextNum3 = 0)
    {
        if(text3 == null || text3 == "")
        {
            ClickBtn_1_Btn.gameObject.SetActive(true);
            clickBtn.ChangeNum1 = nextNum1;
            ClickBtn_2_Btn.gameObject.SetActive(true);
            clickBtn.ChangeNum2 = nextNum2;
            ClickBtn_1_TMP.text = text1;
            ClickBtn_2_TMP.text = text2;
        }
        else
        {
            ClickBtn_1_Btn.gameObject.SetActive(true);
            clickBtn.ChangeNum1 = nextNum1;
            ClickBtn_2_Btn.gameObject.SetActive(true);
            clickBtn.ChangeNum2 = nextNum2;
            ClickBtn_3_Btn.gameObject.SetActive(true);
            clickBtn.ChangeNum3 = nextNum3;
            ClickBtn_1_TMP.text = text1;
            ClickBtn_2_TMP.text = text2;
            ClickBtn_3_TMP.text = text3;
        }
    }
}