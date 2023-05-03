using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ChangeName : MonoBehaviour
{
    public TMP_InputField NameInput_InputField;
    public string PlayerName;
    public void OnClickOK_Btn()
    {
        PlayerName = NameInput_InputField.text.ToString();
        UIManager.instance.Story_Image.gameObject.SetActive(true);
        UIManager.instance.InputName_Image.gameObject.SetActive(false);
        UIManager.instance.StartPage_Image.gameObject.SetActive(false);
    }

    public void ChangeFileNames(string fileName)
    {
        
    }
}
