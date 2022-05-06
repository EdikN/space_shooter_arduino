using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ads_shop : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        RewControl.Getted += Give;
        GetComponent<Button>().onClick.AddListener(()=>YandexSDK.instance.ShowRewarded("give"));
    }

    private void Give(string id){
        if(id == "give"){
            StaticValues.balance += 100;
        }
    }
}