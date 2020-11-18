using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    Animator soundonanim;
    private bool optionflg; 

    // Start is called before the first frame update
    void Start()
    {
        optionflg = false;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(AudioListener.volume);
    }
    public void OnClick()
    {

    }
    public void OnclickOptionButton()
    {
        if (optionflg == false)
        {
            GameObject.Find("SoundOnButton").GetComponent<Animator>().SetBool("optionflg",true);
            optionflg = true;
        }
        else
        {
            GameObject.Find("SoundOnButton").GetComponent<Animator>().SetBool("optionflg", false);
            Debug.Log("オプションボタンもう一度押した");
            optionflg = false;
        }
    }
    public void OnclickSoundOnButton()
    {
        AudioListener.volume = 0;
        Debug.Log("サウンドオンボタン押した");
    }
    public void OnclickSoundOffButton()
    {
        AudioListener.volume = 1;
        Debug.Log("サウンドオフボタン押した");
    }
}
