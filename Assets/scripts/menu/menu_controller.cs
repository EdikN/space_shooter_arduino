using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class menu_controller : MonoBehaviour
{
    [Header("button's")]
    [SerializeField] Button close;
    [SerializeField] Button buy;
    [SerializeField] Button left;
    [SerializeField] Button right;
    [Header("ship")]
    [SerializeField] Image ship;
    [Header("slider")]
    [SerializeField] Slider fire_rate;
    [SerializeField] Slider fire_count;
    [SerializeField] Slider hp;
    [Header("text")]
    [SerializeField] Text balance;
    [SerializeField] Text price;
    [Header("res")]
    [SerializeField] List<Sprite> ship_res;

    private int skin;
    private void Start()
    {
        SaveS.Load();
        skin = StaticValues.player;
        ship.sprite = ship_res[StaticValues.player];
        characters(skin);
        left.onClick.AddListener(delegate { nextship(false); });
        right.onClick.AddListener(delegate { nextship(true); });
        buy.onClick.AddListener(delegate { buy_func(); });
    }
    private void FixedUpdate()
    {
        balance.text = language_staticl.balance + StaticValues.balance.ToString();
    }
    void buy_func()
    {
        switch (skin)
        {
            case 0:
                StaticValues.selected_ship = 0;
                break;
            case 1:
                buy_f(100, 1);
                break;
            case 2:
                buy_f(200, 2);
                break;
            case 3:
                buy_f(300, 3);
                break;
        }
    }
    void buy_f(int price, int id)
    {
        if (StaticValues.buys[id])
        {
            StaticValues.selected_ship = id;
            SaveS.Save();
        }
        else if (StaticValues.balance >= price)
        {
            StaticValues.balance -= price;
            StaticValues.selected_ship = id;
            StaticValues.buys[id] = true;
            SaveS.Save();
        }
    }
    void nextship(bool naprav)
    {
        if (naprav)
        {
            if (skin < ship_res.Count - 1)
            {
                ship.sprite = ship_res[skin + 1];
                skin++;
                characters(skin);
            }
            else
            {
                ship.sprite = ship_res[0];
                skin = 0;
                characters(skin);
            }
        }
        else
        {
            if (skin > 0)
            {
                ship.sprite = ship_res[skin - 1];
                skin--;
                characters(skin);
            }
            else
            {
                ship.sprite = ship_res[ship_res.Count - 1];
                skin = ship_res.Count - 1;
                characters(skin);
            }
        }
    }
    void characters(int i)
    {
        switch (i)
        {
            case 0:
                fire_rate.value = 10;
                fire_count.value = 1;
                hp.value = 3;
                price.text = language_staticl.bought;
                break;
            case 1:
                fire_rate.value = 2;
                fire_count.value = 4;
                hp.value = 5;
                if (StaticValues.buys[1])
                    price.text = language_staticl.bought;
                else
                    price.text = language_staticl.price + 100;
                break;
            case 2:
                fire_rate.value = 4;
                fire_count.value = 4;
                hp.value = 7;
                if (StaticValues.buys[2])
                    price.text = language_staticl.bought;
                else
                    price.text = language_staticl.price + 200;
                break;
            case 3:
                fire_rate.value = 6;
                fire_count.value = 6;
                hp.value = 10;
                if (StaticValues.buys[3])
                    price.text = language_staticl.bought;
                else
                    price.text = language_staticl.price + 300;
                break;
        }
    }
}