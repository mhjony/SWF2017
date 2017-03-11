using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Login : MonoBehaviour {
#region variables
	//Static Vatiable
	public static string Email = "";
	public static string Password = "";
	
    //public variable
	public string CurrentMenu = "Login";


	//Private Variable
	private string CreateAcountUrl = "";
	private string LoginUrl = "";
    private string ConfirmPass = "";
    private string ConfirmEmail = "";
    private string CEmail = "";
    private string CPassword = "";
    

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
	void OnGUI(){
		if (CurrentMenu == "Login") {
			LoginGUI ();
		} else if (CurrentMenu == "CreateAccount") {
			CreateAccountGUI ();
		}

	} //End onGUI

#region custon methods
	//This method will login the accounts
	void LoginGUI(){
        //create box to simulate window
		GUI.Box(new Rect(180, 50, 300, 220), "Log In");
        //create account button and login button.
        //Open create account window 
        if (GUI.Button(new Rect(230, 210, 100, 25), "Create Account"))
        {
            CurrentMenu = "CreateAccount";
        }
        
        if (GUI.Button(new Rect(350,210,100,25), "Log In"))
        {
            
        } //End button
        //Email
        GUI.Label(new Rect(230, 110, 50, 20), "Email:");
        Email = GUI.TextField(new Rect(270, 110, 170, 20), Email);
        //Password
        GUI.Label(new Rect(205, 150, 75, 20), "Password:");
        Password = GUI.TextField(new Rect(270, 150, 170, 20), Password);


    }//End Login GUI


	// This method will be the GUI for creating the account
	void CreateAccountGUI(){
        //create box to simulate window
        GUI.Box(new Rect(180, 50, 300, 220), "Create Account");
        
        //Email and password , plus confirmation
        GUI.Label(new Rect(260, 90, 50, 20), "Email:");
        CEmail = GUI.TextField(new Rect(300, 90, 160, 20), CEmail);

        GUI.Label(new Rect(235, 120, 75, 20), "Password:");
        CPassword = GUI.TextField(new Rect(300, 120, 160, 20), CPassword);

        GUI.Label(new Rect(210, 150, 100, 20), "Confirm Email:");
        ConfirmEmail = GUI.TextField(new Rect(300, 150, 160, 20), ConfirmEmail);

        GUI.Label(new Rect(185, 180, 130, 20), "Confirm Password:");
        ConfirmPass = GUI.TextField(new Rect(300, 180, 160, 20), ConfirmPass);
        //create random int field for bot protection

        //create account button and login button.
        //Open create account window 
        if (GUI.Button(new Rect(230, 230, 100, 25), "Create Account"))
        {
            if(ConfirmPass == CPassword && ConfirmEmail == CEmail)
            {
                StartCoroutine("CreateAccount");
            }
            else
            {
                //StartCoroutine();
            }
            
        } //End create account
        //Log user In 
        if (GUI.Button(new Rect(350, 230, 100, 25), "Exit"))
        {
            CurrentMenu = "Login";
        } //End button
    }//End create account GUI
    #endregion

    #region coruoutine
    //Actually create account
    IEnumerator CreateAccount() {
        WWWForm Form = new WWWForm();
        Form.AddField("Email",CEmail);
        Form.AddField("Password",CPassword);
        WWW CreateAccount = new WWW(CreateAcountUrl, Form);
        //wait for php to send something back to unity
        yield return CreateAccountWWW;
        if (CreateAccountWWW.error != null) {
            Debug.LogError("Cannot connect to Account Creation");
        }
        else
        {
            string CreateAccountReturn = CreateAccountWWW.text;
            if (CreateAccountReturn == "Success")
            {
                Debug.Log("Success: Account created");
                CurrentMenu = "Login";
            }
        }// End else


    } //End create account


#endregion


}//End class
