using UnityEngine;
using SimpleJSON;
using System.IO;
using System.Runtime.InteropServices;

public class SaveS
{
    static string path = Application.persistentDataPath + "/Save.json";


    public static void Save()
    {
        JSONObject obj = new JSONObject();

        obj.Add("balance", StaticValues.balance);
        obj.Add("max_score", StaticValues.score);
        obj.Add("selected", StaticValues.selected_ship);

        JSONArray arr = new JSONArray();
        foreach (var buy in StaticValues.buys)
        {
            arr.Add(buy);
        }
        obj.Add("buys", arr);

        if(StaticValues.web && StaticValues.logined){
            YandexSDK.instance.SettingData(obj.ToString());
        }
        else{
            File.WriteAllText(path, obj.ToString());
            //Debug.Log(path);
        }
    }

    public static void Load()
    {
        if(StaticValues.web && StaticValues.logined){
            YandexSDK.instance.Load();
        }
        else{
        try
        {
            string jsonstr = File.ReadAllText(path);
            JSONObject obj = (JSONObject)JSON.Parse(jsonstr);

            StaticValues.balance = obj["balance"];
            StaticValues.score = obj["max_score"];
            StaticValues.selected_ship = obj["selected"];

            for (int i = 0; i < obj["buys"].Count; i++)
            {
                StaticValues.buys[i] = obj["buys"][i];
            }


            //Debug.Log(path);
        }
        catch { Save(); Load(); }
        }
    }
}
