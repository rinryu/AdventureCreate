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
	public int Speed;
	public int Jump;
	public int Life;
	public int Gravity;
	public int BGMID;
	public int JumpSE;
	public int StepSE;
	public int SpringSE;
	public int DamageSE;
	public int GoalEffect;
	public int DamageEffect;
	public int AttackEffect;
    public string CreateDate;
    public string UpdateDate;
    public int playCount  = 0;
    public int clearCount = 0;
    public int missCount  = 0;
	[NonSerialized]
	public ParameterData parameterData = new ParameterData();
	[NonSerialized]
	public int ClearPercent;
	public enum Difficulty{
		VERY_EASY,
		EASY,
		NORMAL,
		HARD,
		VERY_HARD
	}
	[NonSerialized]
	public Difficulty difficulty;
	public void Initialize(){
		SetParcent ();
		SetDifficulty ();
		SetParam ();
	}

	public void SetParcent(){
		if (playCount != 0) {
			float percent = ((float)clearCount / (float)playCount);
			percent *= 100;
			ClearPercent = (int)percent;
		} else {
			ClearPercent = 0;
		}
	}

	public void SetDifficulty(){
		if (ClearPercent <= 20)
			difficulty = Difficulty.VERY_HARD;
		else if (ClearPercent > 20 && ClearPercent <= 40)
			difficulty = Difficulty.HARD;
		else if (ClearPercent > 40 && ClearPercent <= 60)
			difficulty = Difficulty.NORMAL;
		else if (ClearPercent > 60 && ClearPercent <= 80)
			difficulty = Difficulty.EASY;
		else if (ClearPercent > 80)
			difficulty = Difficulty.VERY_EASY;
	}

	public void SetParam(){
		parameterData.Speed = Speed;
		parameterData.Jump = Jump;
		parameterData.Life = Life;
		parameterData.Gravity = Gravity;
		parameterData.BGMID = BGMID;
		parameterData.JumpSE = JumpSE;
		parameterData.StepSE = StepSE;
		parameterData.SpringSE = SpringSE;
		parameterData.DamageSE = DamageSE;
		parameterData.GoalEffect = GoalEffect;
		parameterData.AttackEffect = AttackEffect;
		parameterData.DamageEffect = DamageEffect;
	}


	public void ConvertStageDatatoString(int[,] map){
		string data = string.Empty;
		for (int x = 0; x < map.GetLength (0); x++) {
			for (int y = 0; y < map.GetLength (1); y++) {				
				data += map [x, y].ToString();
			}
		}
		StageData = data;
	}

    public int[,] ConvertStageData()
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

}

[Serializable]
public class ParameterData
{
	public int Speed;
	public int Jump;
	public int Life;
	public int Gravity;
	public int BGMID;
	public int JumpSE;
	public int StepSE;
	public int SpringSE;
	public int DamageSE;
	public int GoalEffect;
	public int DamageEffect;
	public int AttackEffect;


	public ParameterData(int in_speed,int in_jump,int in_life,int in_gravity,int bgm,int jumpse,int stepse,int springse,int damagese,int goalef,int damageef,int attackef)
    {
		Speed = in_speed;
		Jump = in_jump;
		Life = in_life;
		Gravity = in_gravity;
		BGMID = bgm;
		JumpSE = jumpse;
		StepSE = stepse;
		SpringSE = springse;
		DamageSE = damagese;
		GoalEffect = goalef;
		DamageEffect = damageef;
		AttackEffect = attackef;
    }
	public ParameterData(){
		Speed = 0;
		Jump = 0;
		Life = 1;
		Gravity = 0;
		BGMID = -1;
		JumpSE = -1;
		StepSE = -1;
		SpringSE = -1;
		DamageSE = -1;
		GoalEffect = 0;
		DamageEffect = 0;
		AttackEffect = 0;
	}

	public void SetParam(int in_speed,int in_jump,int in_life,int in_gravity,int bgm,int jumpse,int stepse,int springse,int damagese,int goalef,int damageef,int attackef)
	{
		Speed = in_speed;
		Jump = in_jump;
		Life = in_life;
		Gravity = in_gravity;
		BGMID = bgm;
		JumpSE = jumpse;
		StepSE = stepse;
		SpringSE = springse;
		DamageSE = damagese;
		GoalEffect = goalef;
		DamageEffect = damageef;
		AttackEffect = attackef;
	}

}

[Serializable]
public class StageState
{
	public string stageName;
    public int playCount;
    public int clearCount;
    public int missCount;

	public StageState(string in_name,int in_playCount,int in_clearCount,int in_missCount){
		stageName = in_name;
		playCount = in_playCount;
		clearCount = in_clearCount;
		missCount = in_missCount;
	}
}

[SerializeField]
public class DeathPoint{
	public int num;
	public int stageNumber;
	public float posX;
	public float posY;


}