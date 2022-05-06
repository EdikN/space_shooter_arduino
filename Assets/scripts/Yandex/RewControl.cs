using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RewControl : MonoBehaviour
{
    public static event Action<string> Getted;

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        YandexSDK.instance.onRewardedAdClosed += Closed;
        YandexSDK.instance.onRewardedAdOpened += Open;
        YandexSDK.instance.onRewardedAdError += Error;
        YandexSDK.instance.onRewardedAdReward += Rewarded;
    }

    private void Rewarded(string obj)
    {
        Getted.Invoke(obj);
    }

    private void Error(string obj)
    {

    }

    private void Closed(int i){

    }

    private void Open(int i){

    }
}
