using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserData {
	private static UserData _Instanse;

	private UserData(){

	}
	public static UserData Instanse{
		get{
			if(_Instanse == null){
				_Instanse = new UserData();
			}
			return _Instanse;

		}
	}

	public string username;
    public int ID;
    public string createTime;
    public int playTime;
    public string tag;

    public void SetInstanse(UserData in_data)
    {
        _Instanse = in_data;
    }


}
