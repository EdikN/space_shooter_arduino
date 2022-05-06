using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using SimpleJSON;
using UnityEngine;
using UnityEngine.SceneManagement;

public class set_lang : MonoBehaviour
{
    [DllImport("__Internal")] private static extern void ProjectStarted();

    // Start is called before the first frame update
    void Start()
    {
        if(!StaticValues.trnslited){
            ProjectStarted();
            StaticValues.trnslited = true;
        }
    }

    private void GettingLang(string _lang)
    {
        var json = JSON.Parse(_lang);
        string lang = json["i18n"]["lang"];
        print(lang);
        if (lang == "en")
        {
            setEng();
        }
        SceneManager.LoadScene("menu");
    }

    private void setEng(){
        language_staticl.price = "PRICE: ";
        language_staticl.balance = "MONEY: ";
        language_staticl.bought = "BOUGHT";
        language_staticl.score = "SCORE: ";
        language_staticl.colect_coin = "COINS: ";
        language_staticl.high_score = "HIGH SCORE: ";
        language_staticl.play = "PLAY";
        language_staticl.shop = "SHOP";
        language_staticl.leaderboard = "LEADER BOARD";
        language_staticl.earth = "THE EARTH IS DESTROYED";
        language_staticl.contunie = "CONTUNIE";
        language_staticl.x2coins = "x2 COINS";
        language_staticl.home = "HOME";
        language_staticl.buy = "BUY";
        language_staticl.Close = "CLOSE";
        language_staticl.fire_rate = "FIRE RATE";
        language_staticl.fire_count = "FIRE COINS";
        language_staticl.health = "HEALTH";
        language_staticl.watch = "WATCH AD AND GET 100 COINS";
    }
}
