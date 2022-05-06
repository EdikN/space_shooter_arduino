using System.Collections;
using System.Collections.Generic;
using SimpleJSON;
using UnityEngine;
using UnityEngine.UI;

public static class StaticValues
{
    public static int coins = 0;
    public static int balance = 0;
    public static int selected_ship = 0;
    public static int score = 0;
    public static int high_score = 0;
    public static int player = 0;
    public static int hp = 3;

    public static bool[] buys = new[] {false, false, false, false };

    //dont save
    public static bool logined = false;
    public static JSONArray lidBoards;
    public static bool trnslited = false;
    public static bool web =true;
}
