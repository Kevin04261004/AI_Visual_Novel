using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickBtn : MonoBehaviour
{
    public DialogueReader reader;
    public int btn1_ChangeLine = 0;
    public int btn2_ChangeLine = 0;
    public int btn3_ChangeLine = 0;
    public int ChangeNum1;
    public int ChangeNum2;
    public int ChangeNum3;
    public void OnClickClickBtn_1()
    {
        UIManager.instance.ClickBtn_1.gameObject.SetActive(false);
        UIManager.instance.ClickBtn_2.gameObject.SetActive(false);
        UIManager.instance.ClickBtn_3.gameObject.SetActive(false);
        reader.isNeedToClickBtnFalse();
        reader.TypeIndexChange(ChangeNum1-2);
    }
    public void OnClickClickBtn_2()
    {
        UIManager.instance.ClickBtn_1.gameObject.SetActive(false);
        UIManager.instance.ClickBtn_2.gameObject.SetActive(false);
        UIManager.instance.ClickBtn_3.gameObject.SetActive(false);
        reader.isNeedToClickBtnFalse();
        reader.TypeIndexChange(ChangeNum2 - 2);
    }
    public void OnClickClickBtn_3()
    {
        UIManager.instance.ClickBtn_1.gameObject.SetActive(false);
        UIManager.instance.ClickBtn_2.gameObject.SetActive(false);
        UIManager.instance.ClickBtn_3.gameObject.SetActive(false);
        reader.isNeedToClickBtnFalse();
        reader.TypeIndexChange(ChangeNum3 - 2);
    }
}
