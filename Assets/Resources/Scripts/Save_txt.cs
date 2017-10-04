using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Collections;
using System.IO;
using System; //Exception
using System.Text; //Encoding

public class Save_txt : MonoBehaviour
{
    string Readdata;
    bool Load = false;


    // Use this for initialization
    void Start()
    {

        Load = false;
        
                
    }

     void Update()
    {
        if (!Load)
          {

            AutoLoad();
            Load = true;
            Debug.Log("Load");
        }
    }

    // 引数でStringを渡してやる
    public void textSave(string txt , int stage)
    {
        StreamWriter sw = new StreamWriter(Application.streamingAssetsPath+"/StageData"+ (stage + 1).ToString()+".txt", false); //true=追記 false=上書き
        sw.WriteLine(txt);
        sw.Flush();
        sw.Close();
        Debug.Log("Save");
    }

    public void textLoad(int stage)
    {

        StreamReader sr = new StreamReader(Application.streamingAssetsPath + "/StageData" + (stage + 1).ToString() + ".txt", Encoding.GetEncoding("utf-8"));
        Readdata = sr.ReadToEnd();
        // 閉じる
        sr.Close();
    }

    public void ParameterSave()
    {
        for (int p = 0; p < 5; p++)
        {
            StreamWriter sw = new StreamWriter(Application.streamingAssetsPath + "/ParameterData" + (p + 1).ToString() +".txt", false); //true=追記 false=上書き


                for (int i = 0; i < editor_editManager.value.GetLength(0); i++)
                {
                    sw.WriteLine(editor_editManager.value[i, p].ToString() + "\n");
                }

                //for (int i = 0; i < editor_editManager.BGM_ID.GetLength(1); i++)
                //{
                sw.WriteLine(editor_editManager.BGM_ID[0, p].ToString() + "\n");
                //}

                for (int i = 0; i < editor_editManager.SE_ID.GetLength(0); i++)
                {
                    sw.WriteLine(editor_editManager.SE_ID[i, p].ToString() + "\n");
                }

                sw.WriteLine(editor_editManager.effectID[0, p].ToString() + "\n");//goaleffect

                sw.WriteLine(editor_editManager.effectID[1, p].ToString() + "\n");//damageeffect

                sw.WriteLine(editor_editManager.effectID[2, p].ToString() + "\n");//damageeffect

            sw.Flush();
            sw.Close();
        }
    }
    public void ParameterLoad()
    {
        for (int p = 0; p < 5; p++)
        {
            StreamReader sr = new StreamReader(Application.streamingAssetsPath + "/ParameterData" + (p + 1).ToString() + ".txt", Encoding.GetEncoding("utf-8")); //true=追記 false=上書き

                for (int i = 0; i < editor_editManager.value.GetLength(0); i++)
                {
                    string para = sr.ReadLine();
                    editor_editManager.value[i, p] = Int32.Parse(para);
                    sr.ReadLine();//改行文字避け
                }

                //for (int i = 0; i < editor_editManager.BGM_ID.Length; i++)
                //{
                string bgm = sr.ReadLine();
                editor_editManager.BGM_ID[0, p] = Int32.Parse(bgm);
                sr.ReadLine();//改行文字避け
                              //}

                for (int i = 0; i < editor_editManager.SE_ID.GetLength(0); i++)
                {
                    string se = sr.ReadLine();
                    editor_editManager.SE_ID[i, p] = Int32.Parse(se);
                    sr.ReadLine();//改行文字避け
                }
                
                string goaleffect = sr.ReadLine();
                editor_editManager.effectID[0, p] = Int32.Parse(goaleffect);
                sr.ReadLine();//改行文字避け
            
                string damageeffect = sr.ReadLine();
                editor_editManager.effectID[1, p] = Int32.Parse(damageeffect);
                sr.ReadLine();//改行文字避け    
            
            
                string _damageeffect = sr.ReadLine();
                editor_editManager.effectID[2, p] = Int32.Parse(_damageeffect);
                sr.ReadLine();//改行文字避け
            
            // 閉じる
            sr.Close();
        }
    }

    public void Save()
    {
        //オートセーブ
        for (int i = 0; i < 5; i++)
        {
            Write(i);
        }

        ParameterSave();

    }

    void Write(int stage)
    {
       string Writedata = "";

        for (int x = 0; x < 50; x++)
        {
            for (int y = 0; y < 10; y++)
            {
                if ((Int32)editor_editManager.editMapData[x, y, stage] < 10)//
                {//
                    Writedata += (Int32)editor_editManager.editMapData[x, y, stage];
                }//
                else//
                {//
                    if ((Int32)editor_editManager.editMapData[x, y, stage] == 10) Writedata += "a";
                    if ((Int32)editor_editManager.editMapData[x, y, stage] == 11) Writedata += "b";
                    if ((Int32)editor_editManager.editMapData[x, y, stage] == 12) Writedata += "c";
                    if ((Int32)editor_editManager.editMapData[x, y, stage] == 13) Writedata += "d";
                    if ((Int32)editor_editManager.editMapData[x, y, stage] == 14) Writedata += "e";
                    if ((Int32)editor_editManager.editMapData[x, y, stage] == 15) Writedata += "f";
                    if ((Int32)editor_editManager.editMapData[x, y, stage] == 16) Writedata += "g";
                    if ((Int32)editor_editManager.editMapData[x, y, stage] == 17) Writedata += "h";
                    if ((Int32)editor_editManager.editMapData[x, y, stage] == 18) Writedata += "i";
                    if ((Int32)editor_editManager.editMapData[x, y, stage] == 19) Writedata += "j";
                    if ((Int32)editor_editManager.editMapData[x, y, stage] == 20) Writedata += "k";
                    if ((Int32)editor_editManager.editMapData[x, y, stage] == 21) Writedata += "l";
                    if ((Int32)editor_editManager.editMapData[x, y, stage] == 22) Writedata += "m";
                    if ((Int32)editor_editManager.editMapData[x, y, stage] == 23) Writedata += "n";
                    if ((Int32)editor_editManager.editMapData[x, y, stage] == 24) Writedata += "o";
                    if ((Int32)editor_editManager.editMapData[x, y, stage] == 25) Writedata += "p";
                    if ((Int32)editor_editManager.editMapData[x, y, stage] == 26) Writedata += "q";
                    if ((Int32)editor_editManager.editMapData[x, y, stage] == 27) Writedata += "r";
                    if ((Int32)editor_editManager.editMapData[x, y, stage] == 28) Writedata += "s";
                    if ((Int32)editor_editManager.editMapData[x, y, stage] == 29) Writedata += "t";
                    if ((Int32)editor_editManager.editMapData[x, y, stage] == 30) Writedata += "u";
                    if ((Int32)editor_editManager.editMapData[x, y, stage] == 31) Writedata += "v";
                    if ((Int32)editor_editManager.editMapData[x, y, stage] == 32) Writedata += "w";
                    if ((Int32)editor_editManager.editMapData[x, y, stage] == 33) Writedata += "x";
                    if ((Int32)editor_editManager.editMapData[x, y, stage] == 34) Writedata += "y";
                    if ((Int32)editor_editManager.editMapData[x, y, stage] == 35) Writedata += "z";
                }//
            }
        }

        textSave(Writedata,stage);
        Debug.Log("Write:" + Writedata.Length);
    }

    void Read(int stage)
    {
        int Count = 0;
        Readdata = "";
        textLoad(stage);
        for (int x = 0; x < editor_editManager.editMapData.GetLongLength(0); x++)
        {
            for (int y = 0; y < editor_editManager.editMapData.GetLongLength(1); y++)
            {
                if (Int32.Parse(Readdata[Count].ToString()) < 10)
                {
                    editor_editManager.editMapData[x, y, stage] = Int32.Parse(Readdata[Count].ToString());
                }
                else
                {
                    if (Readdata[Count].ToString() == "a") editor_editManager.editMapData[x, y, stage] = 10;
                    if (Readdata[Count].ToString() == "b") editor_editManager.editMapData[x, y, stage] = 11;
                    if (Readdata[Count].ToString() == "c") editor_editManager.editMapData[x, y, stage] = 12;
                    if (Readdata[Count].ToString() == "d") editor_editManager.editMapData[x, y, stage] = 13;
                    if (Readdata[Count].ToString() == "e") editor_editManager.editMapData[x, y, stage] = 14;
                    if (Readdata[Count].ToString() == "f") editor_editManager.editMapData[x, y, stage] = 15;
                    if (Readdata[Count].ToString() == "g") editor_editManager.editMapData[x, y, stage] = 16;
                    if (Readdata[Count].ToString() == "h") editor_editManager.editMapData[x, y, stage] = 17;
                    if (Readdata[Count].ToString() == "i") editor_editManager.editMapData[x, y, stage] = 18;
                    if (Readdata[Count].ToString() == "j") editor_editManager.editMapData[x, y, stage] = 19;
                    if (Readdata[Count].ToString() == "k") editor_editManager.editMapData[x, y, stage] = 20;
                    if (Readdata[Count].ToString() == "l") editor_editManager.editMapData[x, y, stage] = 21;
                    if (Readdata[Count].ToString() == "m") editor_editManager.editMapData[x, y, stage] = 22;
                    if (Readdata[Count].ToString() == "n") editor_editManager.editMapData[x, y, stage] = 23;
                    if (Readdata[Count].ToString() == "o") editor_editManager.editMapData[x, y, stage] = 24;
                    if (Readdata[Count].ToString() == "p") editor_editManager.editMapData[x, y, stage] = 25;
                    if (Readdata[Count].ToString() == "q") editor_editManager.editMapData[x, y, stage] = 26;
                    if (Readdata[Count].ToString() == "r") editor_editManager.editMapData[x, y, stage] = 27;
                    if (Readdata[Count].ToString() == "s") editor_editManager.editMapData[x, y, stage] = 28;
                    if (Readdata[Count].ToString() == "t") editor_editManager.editMapData[x, y, stage] = 29;
                    if (Readdata[Count].ToString() == "u") editor_editManager.editMapData[x, y, stage] = 30;
                    if (Readdata[Count].ToString() == "v") editor_editManager.editMapData[x, y, stage] = 31;
                    if (Readdata[Count].ToString() == "w") editor_editManager.editMapData[x, y, stage] = 32;
                    if (Readdata[Count].ToString() == "x") editor_editManager.editMapData[x, y, stage] = 33;
                    if (Readdata[Count].ToString() == "y") editor_editManager.editMapData[x, y, stage] = 34;
                    if (Readdata[Count].ToString() == "z") editor_editManager.editMapData[x, y, stage] = 35;
                }
                Count++;
            }
        }
    }

    public void AutoLoad()
    {
        //オートロード
        for (int i = 0; i < 5; i++)
        {
            Read(i);
        }
        ParameterLoad();
    }
}