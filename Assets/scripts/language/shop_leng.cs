using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class shop_leng : MonoBehaviour
{
    [SerializeField] Text fire_rate; 
    [SerializeField] Text fire_count; 
    [SerializeField] Text health;
    [SerializeField] Text close;
    [SerializeField] Text buy;
    [SerializeField] Text watch;
    private void Start()
    {
        fire_rate.text = language_staticl.fire_rate;
        fire_count.text = language_staticl.fire_count;
        health.text = language_staticl.health;
        close.text = language_staticl.Close;
        buy.text = language_staticl.buy;
        watch.text = language_staticl.watch;
    }
}