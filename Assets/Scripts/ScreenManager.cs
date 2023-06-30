using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScreenManager : MonoBehaviour
{
    private void Start()
    {
        Screen.SetResolution(1280, 720, true);
    }
    public void OnClickFullScreenTrue()
    {
        Screen.SetResolution(1280, 720, true);
    }
    public void OnClickFullScreenFalse()
    {
        Screen.SetResolution(1280, 720, false);
    }
}
