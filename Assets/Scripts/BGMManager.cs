using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BGMManager : MonoBehaviour
{
    [SerializeField] AudioClip BGM;
    [SerializeField] AudioSource audioSource;
    [SerializeField] Slider BGMSlider;

    private void Awake()
    {
        BGMPlay();
    }
    private void Update()
    {
        audioSource.volume = BGMSlider.value;
    }
    public void BGMPlay()
    {
        audioSource.clip = BGM;
        audioSource.Play();
    }
}
