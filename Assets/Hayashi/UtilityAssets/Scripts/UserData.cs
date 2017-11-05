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


	// Use this for initialization
	void Start () {
	}

	// Update is called once per frame
	void Update () {

	}
}
