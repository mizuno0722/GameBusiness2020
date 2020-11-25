using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanselButton : MonoBehaviour {
    public GameObject scrollView;
    public GameObject shopButton;

    // Start is called before the first frame update
    void Start(){
        
    }

    // Update is called once per frame
    void Update(){
        if(shopButton == null){
            shopButton = GameObject.Find("ShopButton");
        }
    }

    public void OnChick(){
        shopButton.SetActive(true);
        scrollView.SetActive(false);
    }
}
