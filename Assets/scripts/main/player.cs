using System.Runtime.InteropServices;
using SimpleJSON;
using UnityEngine;

public class player : MonoBehaviour
{
    [DllImport("__Internal")]
    private static extern void GetDevice();
    [SerializeField] Joystick js;
    public float offset;
    public bool pc_platform = false;

    public GameObject[] controls;

    private void Start() {
        GetDevice();
    }

    public void pcB(string data){
        var pl = JSON.Parse(data)["type"];
        if(pl == "desktop")
        {
            pc_platform = true;
            foreach(var obj in controls){
                obj.SetActive(false);
            }
        }
        else{
            pc_platform = false;
            foreach(var obj in controls){
                obj.SetActive(true);
            }
        }
    }

    void Update()
    {
        if (pc_platform)
            pc();
        else
            mobile();
    }
    private void pc()
    {
        Vector3 dif = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float rotateZ = Mathf.Atan2(dif.y, dif.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rotateZ + offset);
    }
    private void mobile()
    {
        float x = js.Horizontal;
        float y = -js.Vertical;
        float rot = 360;

        if (x < 0 && y < 0)
            rot = 0 + (y * 90);

        if (x < 0 && y > 0)
            rot = 359 + (y * 90);


        if (x > 0 && y < 0)
            rot = 180 - (y * 90);

        if (x > 0 && y > 0)
                rot = 180 - (y * 90);

        if (x > 0.01f || y > 0.01f || x < -0.01f || y < -0.01f)
            transform.rotation = Quaternion.Euler(0, 0, rot+90);
    }
}
