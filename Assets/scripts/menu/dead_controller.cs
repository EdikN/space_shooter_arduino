using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class dead_controller : MonoBehaviour
{
    [DllImport("__Internal")]
    private static extern void SetLidBoard(int num);
    [SerializeField] Text score_coins;

    private void Start() {
        RewControl.Getted += Give;
    }
    public void contunie() 
    {
        SceneManager.LoadScene("main");
    }
    public void x2coins()
    {
        StaticValues.coins *= 2;
        home();
    }

    public void ShowAd(string id){
        YandexSDK.instance.ShowRewarded(id);
    }

    public void home()
    {
        if (StaticValues.score > StaticValues.high_score) {
            StaticValues.high_score = StaticValues.score;
            StaticValues.score = 0;
        }

        if(StaticValues.logined)
            SetLidBoard(StaticValues.high_score);
            
        StaticValues.balance += StaticValues.coins;
        StaticValues.coins = 0;
        SaveS.Save();
        SceneManager.LoadScene("menu");
    }

    private void Give(string id){
        if(id == "x2"){
            x2coins();
        }
        else if(id == "cont"){
            contunie();
        }
    }
}
