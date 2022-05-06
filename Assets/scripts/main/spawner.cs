using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class spawner : MonoBehaviour
{
    [SerializeField] List<GameObject> points;
    [SerializeField] GameObject high;
    [SerializeField] GameObject mid;
    [SerializeField] GameObject low;
    [SerializeField] List<GameObject> asterid;
    [SerializeField] GameObject earth;
    [SerializeField] Text score;
    public int wafe = 0;

    private void Start()
    {
        StartCoroutine(spawn());
    }
    IEnumerator spawn()
    {
        wafe++;
        int rnd = Random.Range(1, points.Count);
        var obj = Instantiate(asterid[Random.Range(0, 3)], points[rnd].transform.position, points[rnd].transform.rotation);
        obj.GetComponent<asteroid>().earth = earth;
        obj.GetComponent<asteroid>().score = score;
        if (wafe > 0 && wafe <= 10)
            yield return new WaitForSeconds(Random.Range(1f, 3f));
        if (wafe > 10 && wafe <= 25)
            yield return new WaitForSeconds(Random.Range(1f, 3f));
        if (wafe > 25 && wafe <= 40)
            yield return new WaitForSeconds(Random.Range(0.6f, 3f));
        if (wafe > 40 && wafe <= 65)
            yield return new WaitForSeconds(Random.Range(0.3f, 3f));
        if (wafe > 65 && wafe <= 90)
            yield return new WaitForSeconds(Random.Range(0.1f, 3f));
        if (wafe > 90 && wafe <= 125)
            yield return new WaitForSeconds(Random.Range(1.0f, 2f));
        if (wafe > 125 && wafe <= 170)
            yield return new WaitForSeconds(Random.Range(0.6f, 2f));
        if (wafe > 170 && wafe <= 225)
            yield return new WaitForSeconds(Random.Range(0.3f, 2f));
        if (wafe > 225 && wafe <= 250)
            yield return new WaitForSeconds(Random.Range(0.1f, 2f));
        StartCoroutine(spawn());
    }
}