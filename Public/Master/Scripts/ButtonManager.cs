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
        
    }
    public void OnClick()
    {

    }
    public void OnclickOptionButton()
    {
        if (optionflg == false)
        {
            GameObject.Find("SoundOnButton").GetComponent<Animator>().SetBool("Optionflg",true);
            Debug.Log("オプションボタン押した");
        }
        else
        {
            GameObject.Find("SoundOnButton").GetComponent<Animator>().SetBool("Optionflg", false);
            Debug.Log("オプションボタンもう一度押した");
        }
    }
    public void OnclickSoundOnButton()
    {
        Debug.Log("サウンドオンボタン押した");
    }
    public void OnclickSoundOffButton()
    {
        Debug.Log("サウンドオフボタン押した");
    }
}
