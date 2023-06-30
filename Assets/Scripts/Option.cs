using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Option : MonoBehaviour
{
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            OnClickExitGame_Btn();
        }
    }
    public void OnClickContinue_Btn()
    {
        UIManager.instance.OptionBackGround_Image.gameObject.SetActive(false);
    }
    public void OnClickExitGame_Btn()
    {
        UIManager.instance.RealExit_Image.gameObject.SetActive(true);
    }

    //RealExitâ
    public void OnClickExit_Btn()
    {
        Application.Quit();
    }
    public void OnClickExitNope_Btn()
    {
        UIManager.instance.RealExit_Image.gameObject.SetActive(false);
    }
}
