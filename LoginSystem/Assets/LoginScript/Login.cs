using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Login : MonoBehaviour {
#region variables
	//Static Vatiable
	public static string Email = "";
	public static string Passwordp = "";
	//public variable
	public string CurrentMenu = "Login";


	//Private Variable
	private string CreateAcountUrl = "";
	private string LoginUrl = "";

	//GuI Test section
	public float X;
	public float Y;
	public float Width;
	public float Height;


#endregion 

	// Use this for initialization
	void Start () {
		
	} // End start method

	//Main GUI Function
	void onGUI(){
		if (CurrentMenu == "CreateAccount") {
			LoginGUI ();
		} else if (CurrentMenu == "CreateAccount") {
			CreateAccountGUI ();
		}

	} //End onGUI

#region custon methods
	//This method will login the accounts
	void LoginGUI(){
		GUI.Box(new Rect(320, 120, (Screen.width/4)+400, (Screen.height/4)+350), "");
		
	}//End Login GUI


	// This method will be the GUI for creating the account
	void CreateAccountGUI(){
	
	}//End create account GUI
#endregion
	

}//End class
