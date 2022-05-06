using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class upgrade : MonoBehaviour
{
    [SerializeField] List<GameObject> fire_sprite;
    [SerializeField] List<Sprite> ship;
    [SerializeField] earth ert;
    private void Start()
    {
        GameObject.Find("score").GetComponent<Text>().text = language_staticl.score + StaticValues.score;
        GameObject.Find("coins_text").GetComponent<Text>().text = language_staticl.colect_coin + StaticValues.coins;
        transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = ship[StaticValues.selected_ship];
        float fire_rate=0;
        int fire_count=0;
        int hp=0;
        switch (StaticValues.selected_ship)
        {
            case 0:
                fire_rate = 0.1f;
                fire_count= 1;
                hp = 3;
                break;
            case 1:
                fire_rate = 0.8f;
                fire_count = 5;
                hp = 10;
                break;
            case 2:
                fire_rate = 0.4f;
                fire_count = 5;
                hp = 15;
                break;
            case 3:
                fire_rate = 0.6f;
                fire_count = 7;
                hp = 20;
                break;
        }
        GetComponent<fire>().fire_speed = fire_rate;
        GetComponent<fire>().fire_count = fire_count;
        ert.hp = hp;
    }
}
