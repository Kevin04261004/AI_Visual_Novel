using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartPage : MonoBehaviour
{
    public void OnClickStartGame_Btn()
    {

        UIManager.instance.InputName_Image.gameObject.SetActive(true);
    }
    public void OnClickOption_Btn()
    {
        UIManager.instance.OptionBackGround_Image.gameObject.SetActive(true);
    }
}
