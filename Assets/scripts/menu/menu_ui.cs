using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UI;

public class menu_ui : MonoBehaviour
{
    [SerializeField] Text play;
    [SerializeField] Text shop;
    [SerializeField] Text leaderboard;
    [SerializeField] Text highscore;

    [DllImport("__Internal")]
    private static extern void ShowFullscreenAd();

    private void Start()
    {
        play.text = language_staticl.play;
        shop.text = language_staticl.shop;
        leaderboard.text = language_staticl.leaderboard;
        highscore.text = language_staticl.high_score + StaticValues.high_score;
        StaticValues.score = 0;
        StaticValues.coins = 0;

        ShowFullscreenAd();

        SaveS.Load();
    }
}
