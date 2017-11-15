using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class StageDataClass{

    public int  StageNumber;
    public int  user_ID;
    public string StageName;
    public string StageData;
    public string Parameter;
    public string CreateDate;
    public string UpdateDate;
    public int playCount;
    public int clearCount;
    public int missCount;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public int[,] ConvnertStageData()
    {
        int[,] stagedata = new int[50, 10];
        int count = 0;
        for (int x = 0; x < stagedata.GetLength(0); x++)
        {
            for (int y = 0; y < stagedata.GetLongLength(1); y++)
            {
                if (Int32.Parse(StageData[count].ToString()) < 10)
                {
                    stagedata[x, y] = Int32.Parse(StageData[count].ToString());
                }
                else
                {
                    if (StageData[count].ToString() == "a") stagedata[x, y] = 10;
                    if (StageData[count].ToString() == "b") stagedata[x, y] = 11;
                    if (StageData[count].ToString() == "c") stagedata[x, y] = 12;
                    if (StageData[count].ToString() == "d") stagedata[x, y] = 13;
                    if (StageData[count].ToString() == "e") stagedata[x, y] = 14;
                    if (StageData[count].ToString() == "f") stagedata[x, y] = 15;
                    if (StageData[count].ToString() == "g") stagedata[x, y] = 16;
                    if (StageData[count].ToString() == "h") stagedata[x, y] = 17;
                    if (StageData[count].ToString() == "i") stagedata[x, y] = 18;
                    if (StageData[count].ToString() == "j") stagedata[x, y] = 19;
                    if (StageData[count].ToString() == "k") stagedata[x, y] = 20;
                    if (StageData[count].ToString() == "l") stagedata[x, y] = 21;
                    if (StageData[count].ToString() == "m") stagedata[x, y] = 22;
                    if (StageData[count].ToString() == "n") stagedata[x, y] = 23;
                    if (StageData[count].ToString() == "o") stagedata[x, y] = 24;
                    if (StageData[count].ToString() == "p") stagedata[x, y] = 25;
                    if (StageData[count].ToString() == "q") stagedata[x, y] = 26;
                    if (StageData[count].ToString() == "r") stagedata[x, y] = 27;
                    if (StageData[count].ToString() == "s") stagedata[x, y] = 28;
                    if (StageData[count].ToString() == "t") stagedata[x, y] = 29;
                    if (StageData[count].ToString() == "u") stagedata[x, y] = 30;
                    if (StageData[count].ToString() == "v") stagedata[x, y] = 31;
                    if (StageData[count].ToString() == "w") stagedata[x, y] = 32;
                    if (StageData[count].ToString() == "x") stagedata[x, y] = 33;
                    if (StageData[count].ToString() == "y") stagedata[x, y] = 34;
                    if (StageData[count].ToString() == "z") stagedata[x, y] = 35;
                }
                count++;
            }
        }
        return stagedata;

    }

    public string ConvertParameterData()
    {
        Debug.Log(Parameter);
        ParameterData param = new ParameterData();
        List<string> para = new List<string>();
        para.AddRange(Parameter.Split('\n'));
        para.RemoveAll(s => s == "");

        int count = 0;


        for (int i = 0; i < editor_editManager.value.GetLength(0); i++)
        {
            Debug.Log(Int32.Parse(para[count]));
            param.value[i] = Int32.Parse(para[count]);
            count++;
        }

        param.BGMID = Int32.Parse(para[count]);
        count++;

        for (int i = 0; i < editor_editManager.SE_ID.GetLength(0); i++)
        {
            param.SEID[i] = Int32.Parse(para[count]);
            count++;
        }

        param.effectID[0] = Int32.Parse(para[count]);
        count++;

        param.effectID[1] = Int32.Parse(para[count]);
        count++;

        param.effectID[2] = Int32.Parse(para[count]);
        return JsonUtility.ToJson(param);
    }
}

[Serializable]
public class ParameterData
{
    public int[] value = new int[10];
    public int BGMID;
    public int[] SEID = new int[6];
    public int[] effectID = new int[5];

    public ParameterData()
    {
        value = new int[10];
        BGMID = 0;
        SEID = new int[6];
        effectID = new int[5];
    }

    public ParameterData(ParameterData argparam)
    {
        value = argparam.value;
        BGMID = argparam.BGMID;
        SEID = argparam.SEID;
        effectID = argparam.effectID;
    }

    ParameterData(int[] argvalue,int argBGMID,int[] argSEID,int[] argeffectID)
    {
        value = argvalue;
        BGMID = argBGMID;
        SEID = argSEID;
        effectID = argeffectID;
    }

    public void PrintParam()
    {
        string message = string.Empty;
        message += "Speed:" + value[0].ToString() + ":";
        message += "Jump:" + value[1].ToString() + ":";
        message += "Life:" + value[2].ToString() + ":";
        message += "Gravity:" + value[3].ToString() + "\n";
        message += "BGM" + BGMID + ":";
        message += "JumpSE" + SEID[0] + ":";
        message += "StepSE" + SEID[1] + ":";
        message += "DamageSE" + SEID[2] + ":";
        message += "SpringSE" + SEID[3] + ":";
        Debug.LogError(message);



    }


}

[Serializable]
public class StageState
{
    public int playCount;
    public int clearCount;
    public int missCOunt;
} 