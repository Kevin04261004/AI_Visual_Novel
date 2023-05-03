using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Option : MonoBehaviour
{
    public void OnClickContinue_Btn()
    {
        UIManager.instance.OptionBackGround_Image.gameObject.SetActive(false);
    }
}
