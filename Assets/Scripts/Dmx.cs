using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dmx : MonoBehaviour
{ 
    // DMXデバイスのIPアドレス
    string address = "192.168.77.221";
    // DMXデバイスのポート番号
    int port = 6454;
    int universe = 0;
    DmxHandler handler;
    public GameObject c1;
    public GameObject c2;
    public GameObject c3;

    [Range(0.0f, 255.0f)]
    public byte ch0 = 0;

    [Range(0.0f, 255.0f)]
    public byte ch1 = 0;

    [Range(0.0f, 255.0f)]
    public byte ch2 = 0;

    [Range(0.0f, 255.0f)]
    public byte ch3 = 0;

    [Range(0.0f, 255.0f)]
    public byte ch4 = 0;

    [Range(0.0f, 255.0f)]
    public byte ch5 = 0;

    [Range(0.0f, 255.0f)]
    public byte ch6 = 0;

    [Range(0.0f, 255.0f)]
    public byte ch7 = 0;
    
    [Range(0.0f, 255.0f)]
    public byte ch8 = 0;

    [Range(0.0f, 255.0f)]
    public byte ch9 = 0;

    [Range(0.0f, 255.0f)]
    public byte ch10 = 0;

    [Range(0.0f, 255.0f)]
    public byte ch11 = 0;
    


    void Start()
    {
        // 初期設定
        handler = new DmxHandler( address, port, universe );
        handler.Update();
    }

    // Update is called once per frame
    void Update()
    {
        // 1台目
        handler.data[0] = ch0;
        handler.data[1] = ch1;
        handler.data[2] = ch2;
        handler.data[3] = ch3;

        // 2台目
        handler.data[4] = ch4;
        handler.data[5] = ch5;
        handler.data[6] = ch6;
        handler.data[7] = ch7;

        // 3台目
        handler.data[8] = ch8;
        handler.data[9] = ch9;
        handler.data[10] = ch10;
        handler.data[11] = ch11;
        
        // 1台目の色設定
        SetColor(c1, ch0, ch1, ch2, ch3);
        // 2台目の色設定
        SetColor(c2, ch4, ch5, ch6, ch7);
        // 3台目の色設定
        SetColor(c3, ch8, ch9, ch10, ch11);

        handler.Update();
    }
    
    void SetColor(GameObject c, byte r, byte g, byte b, byte a) {
        Material mat = c.GetComponent<Renderer>().material;
        mat.color = new Color32(r, g, b, a);
    }
}
