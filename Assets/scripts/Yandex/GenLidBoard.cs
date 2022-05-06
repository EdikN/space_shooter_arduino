using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class GenLidBoard : MonoBehaviour
{
    public LidBoard lid;
    public GameObject lidObject;

    // Start is called before the first frame update
    void Start()
    {
        lid.jsonToSV += Gen;
    }

    public void Gen(){
        for(int i = 0; i<StaticValues.lidBoards.Count; i++){
            Debug.Log(StaticValues.lidBoards[i].ToString());
            var obj = Instantiate(lidObject, Vector3.zero, Quaternion.identity, transform).GetComponent<LidBoardObj>();
            obj.nick.text = StaticValues.lidBoards[i]["player"]["publicName"].ToString();
            obj.score.text = StaticValues.lidBoards[i]["score"].ToString();
            obj.top.text = StaticValues.lidBoards[i]["rank"].ToString();
        }
    }
}
