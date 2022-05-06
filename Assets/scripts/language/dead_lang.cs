using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class dead_lang : MonoBehaviour
{
    [SerializeField] Text earth;
    [SerializeField] Text score;
    [SerializeField] Text contunie;
    [SerializeField] Text x2;
    [SerializeField] Text home;
    private void Start()
    {
        earth.text = language_staticl.earth;
        score.text = language_staticl.score+ StaticValues.score +"\n"
            +language_staticl.colect_coin+StaticValues.coins;
        contunie.text = language_staticl.contunie;
        x2.text = language_staticl.x2coins;
        home.text = language_staticl.home;
    }
}
