using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fire : MonoBehaviour
{
    [SerializeField] List<GameObject> fire1;
    [SerializeField] List<GameObject> fire1_pos;
    [SerializeField] public float fire_speed = 0.01f;
    [SerializeField] public float fire_count = 1;

    bool fire_bool = true;
    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            if (fire_bool)
                create();
        }
    }
    public void create()
    {
        StartCoroutine(wait());
        foreach (GameObject a in fire1_pos)
        {
            var obj = Instantiate(fire1[StaticValues.selected_ship], a.transform.position, transform.rotation);
            obj.GetComponent<bullet>().impulse(transform);
            float kol = fire_count;
            kol--;
            if (kol <= 0)
                break;
        }

    }
    IEnumerator wait() {
        fire_bool = false;
        yield return new WaitForSeconds(fire_speed);
        fire_bool = true;
    }
}
