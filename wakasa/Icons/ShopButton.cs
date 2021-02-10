using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopButton : MonoBehaviour {
    public GameObject ScrollView;
 
    // Start is called before the first frame update
    void Start(){
        ScrollView.SetActive(false);
    }

    // Update is called once per frame
    void Update(){
        
    }

    public void OnChick(){
        ScrollView.SetActive(true);
        gameObject.SetActive(false);
    }
}
