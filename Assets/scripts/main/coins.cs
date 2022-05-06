using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class coins : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "bullet")
        {
            StaticValues.coins++;
            GameObject.Find("coins_text").GetComponent<Text>().text = language_staticl.colect_coin + StaticValues.coins;
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}
