using System.Collections;
using UnityEngine;

public class bullet : MonoBehaviour
{
    [SerializeField] GameObject fx;
    public void impulse(Transform pos)
    {
        StartCoroutine(des());
    }
    private void FixedUpdate()
    {
        transform.Translate(0, 0.03f, 0);
    }
    IEnumerator des() {
        yield return new WaitForSeconds(1);
        Destroy(gameObject);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
    }
}
