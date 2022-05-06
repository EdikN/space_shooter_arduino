using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
public class earth : MonoBehaviour
{
    [SerializeField] List<Sprite> obj;
    public int hp;
    public double percent;

    private void Start()
    {
        hp = StaticValues.hp;
    }
    public IEnumerator damage()
    {
        hp--;
        percent = (Convert.ToDouble(hp) / Convert.ToDouble(StaticValues.hp))*100;
        transform.GetChild(0).gameObject.SetActive(true);
        if (percent <= 80)
            GetComponent<SpriteRenderer>().sprite = obj[1];
        if (percent <= 60)
            GetComponent<SpriteRenderer>().sprite = obj[2];
        if (percent <= 40)
            GetComponent<SpriteRenderer>().sprite = obj[3];
        if (percent <= 20)
            GetComponent<SpriteRenderer>().sprite = obj[4];
        yield return new WaitForSeconds(0.5f);
        transform.GetChild(0).gameObject.SetActive(false);
        if (hp <= 0)
            gameObject.GetComponent<scene_manager>().dead();
    }
}
