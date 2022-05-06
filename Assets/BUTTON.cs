 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Uduino;

public class BUTTON : MonoBehaviour
{
    public Text textZoneB;
    public Text textZoneX;
    public Text textZoneY;

    // Start is called before the first frame update
    void Start()
    {
        UduinoManager.Instance.pinMode(2, PinMode.Input);
        UduinoManager.Instance.pinMode(AnalogPin.A0, PinMode.Input);
        UduinoManager.Instance.pinMode(AnalogPin.A1, PinMode.Input);
    }

    // Update is called once per frame
    void Update()
    {
        int buttonValue = UduinoManager.Instance.digitalRead(2);
        int  XValue = UduinoManager.Instance.analogRead(AnalogPin.A0);
        int  YValue = UduinoManager.Instance.analogRead(AnalogPin.A1);

        if(XValue <= 400){
            XValue = 1;
        }
        else if(XValue >= 600){
            XValue = -1;
        }
        else{
            XValue = 0;
        }

        if(YValue <= 400){
            YValue = 1;
        }
        else if(YValue >= 600){
            YValue = -1;
        }
        else{
            YValue = 0;
        }


        textZoneX.text = "X:" + XValue.ToString();
        textZoneY.text = "Y:" + YValue.ToString();
        textZoneB.text = "B:" + buttonValue.ToString();
    }
}
