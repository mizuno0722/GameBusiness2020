using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    private bool optionflg;
    public GameObject skinui;
    Player2 player2;
    Testgm testgm;
    Camera camera;
    void Start()
    {
        optionflg = false;
    }
    public void OnclickOptionButton()//オプションボタン押したら
    {
        if (optionflg == false)
        {
            GameObject.Find("ResetButton").GetComponent<Animator>().SetBool("optionflg", true);
            GameObject.Find("SoundOnButton").GetComponent<Animator>().SetBool("optionflg", true);
            GameObject.Find("SoundOffButton").GetComponent<Animator>().SetBool("optionflg", true);
            optionflg = true;
        }
        else
        {
            GameObject.Find("ResetButton").GetComponent<Animator>().SetBool("optionflg", false);
            GameObject.Find("SoundOnButton").GetComponent<Animator>().SetBool("optionflg", false);
            GameObject.Find("SoundOffButton").GetComponent<Animator>().SetBool("optionflg", false);
            optionflg = false;
        }
    }
    public void OnclickSoundOnButton()//サウンドオンボタン押したら
    {

        GameObject.Find("SoundOffButton").GetComponent<Canvas>().sortingOrder = 1;//表示順変更 1が上
        GameObject.Find("SoundOnButton").GetComponent<Canvas>().sortingOrder = 0;//表示順変更 0が下
        AudioListener.volume = 0;
    }
    public void OnclickSoundOffButton()//サウンドオフボタン押したら
    {
        GameObject.Find("SoundOffButton").GetComponent<Canvas>().sortingOrder = 0;//表示順変更 0が下
        GameObject.Find("SoundOnButton").GetComponent<Canvas>().sortingOrder = 1;//表示順変更 1が上
        AudioListener.volume = 1;
    }

    public void OnclickShopButton()//ショップボタン押したら
    {
        if (player2 == null) player2 = GameObject.Find("Player").GetComponent<Player2>();
        player2.moveflg = false;
        skinui.SetActive(true);
    }
    public void OnclickShopCancelButton()//ショップキャンセルボタン押したら
    {
        if (player2 == null) player2 = GameObject.Find("Player").GetComponent<Player2>();
        player2.moveflg = true;
        skinui.SetActive(false);
    }
    public void OnclickResetButton()//
    {
        if (testgm == null) testgm = GameObject.Find("GameManager").GetComponent<Testgm>();
        testgm.Reset();

    }
    public void OnclickCameraButton()//
    {
        if (camera == null) camera = GameObject.Find("Main Camera").GetComponent<Camera>();
        camera.ZoomToggle();

    }
}
