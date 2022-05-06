using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class asteroid : MonoBehaviour
{
    [SerializeField] public GameObject earth;
    [SerializeField] float speed = 0.001f;
    [SerializeField] int rot_speed = 1;
    [SerializeField] GameObject child;
    [SerializeField] public Text score;
    [SerializeField] GameObject coin;
    bool collis = false;
    private void FixedUpdate()
    {
        transform.Rotate(0, 0, rot_speed);
        transform.position = Vector2.MoveTowards(transform.position, earth.transform.position, speed);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "earth")
        {
            StartCoroutine(collision.gameObject.GetComponent<earth>().damage());
            StartCoroutine(earth_destroy());
        }
        if (!collis)
            if (collision.gameObject.tag == "bullet")
            {
                collis = true;
                Destroy(gameObject.GetComponent<Collider2D>());
                Destroy(collision.gameObject);
                StartCoroutine(bullet_col());
            }
    }
    IEnumerator earth_destroy()
    {
        Destroy(GetComponent<Collider2D>());
        transform.GetChild(0).gameObject.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject);

    }
    IEnumerator bullet_col()
    {
        transform.GetChild(0).gameObject.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        StaticValues.score += 25;
        score.text = language_staticl.score + StaticValues.score;
        if (child != null)
        {
            Vector3 pos = new Vector3(transform.position.x - 0.08f, transform.position.y - 0.08f, transform.position.z);
            var a = Instantiate(child, pos, transform.rotation);
            a.GetComponent<asteroid>().earth = earth;
            a.GetComponent<asteroid>().score = score;
            pos = new Vector3(transform.position.x - 0.1f, transform.position.y - 0.1f, transform.position.z);
            a = Instantiate(child, pos, transform.rotation);
            a.GetComponent<asteroid>().earth = earth;
            a.GetComponent<asteroid>().score = score;
        }
        else
        {
            int rnd = Random.Range(0, 100);
            switch (rnd)
            {
                case 1:
                case 2:
                case 3:
                case 4:
                case 5:
                    Vector3 pos = new Vector3(transform.position.x - 0.08f, transform.position.y - 0.08f, transform.position.z);
                    Instantiate(coin, pos, transform.rotation);
                    break;
            }
        }
        Destroy(gameObject);
    }
}