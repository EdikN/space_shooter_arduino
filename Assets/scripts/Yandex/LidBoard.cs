using SimpleJSON;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UI;
using System;

public class LidBoard : MonoBehaviour
{
    [DllImport("__Internal")]
    private static extern void SetLidBoard(int num);
    [DllImport("__Internal")]
    private static extern void GetLidBoard();
    [DllImport("__Internal")]
    private static extern void Login();

    public static LidBoard instance;

    public event Action jsonToSV;

    // Start is called before the first frame update
    void Start()
    {
        if (StaticValues.logined)
        {
            SetLidBoard(StaticValues.high_score);
        }
        else
        {
            Login();
        }
    }

    public void Load(string get)
    {
        try
        {
            StaticValues.score = int.Parse(get);
        }
        catch { SaveS.Save(); SaveS.Load(); }
    }

    public void Logined()
    {
        StaticValues.logined = true;
        SetLidBoard(StaticValues.score);
    }

    public void ShowLidBoard()
    {
        GetLidBoard();
    }

    public void SetLidBoardtoSV(string json){
        StaticValues.lidBoards = (JSONArray)JSON.Parse(json);
        jsonToSV.Invoke();
    }
}
