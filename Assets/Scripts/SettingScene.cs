using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SettingScene : MonoBehaviour
{
    public AudioSource audiosource;
    public AudioClip enter;
    public AudioClip cansel;
    public AudioMixer audiomixer;
    // Start is called before the first frame update
    void Start()
    {
        FadeManager.FadeIn();
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void OnClickBack()
    {
        audiosource.PlayOneShot(cansel);
        FadeManager.FadeOut(0);
    }

    //BGM
    public void OnClick25BolBGM()
    {
        audiomixer.SetFloat("BGM",-15f);
    }
    public void OnClick50BolBGM()
    {
        audiomixer.SetFloat("BGM", -10f);
    }
    public void OnClick75BolBGM()
    {
        audiomixer.SetFloat("BGM", -5f);
    }
    public void OnClick100BolBGM()
    {
        audiomixer.SetFloat("BGM", -0f);
    }


    //SE

    public void OnClick25BolSE()
    {
        audiomixer.SetFloat("SE", -15f);
        audiosource.PlayOneShot(enter);
    }
    public void OnClick50BolSE()
    {
        audiomixer.SetFloat("SE", -10f);
        audiosource.PlayOneShot(enter);
    }
    public void OnClick75BolSE()
    {
        audiomixer.SetFloat("SE", -5f);
        audiosource.PlayOneShot(enter);
    }
    public void OnClick100BolSE()
    {
        audiomixer.SetFloat("SE",0f);
        audiosource.PlayOneShot(enter);
    }

}
