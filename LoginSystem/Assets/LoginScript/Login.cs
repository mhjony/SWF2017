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
    private string CreateAcountUrl = "http://127.0.0.1/CreateAccountT.php";
	private string LoginUrl = "http://127.0.0.1/LoginAccountT.php";
    private string ConfirmPass = "";
    private string ConfirmEmail = "";
    private string CEmail = "";
    private string CPassword = "";
   // private Rect windowRect = new Rect(0,0, Screen.width,Screen.height);

    

    //GuI Test section
    public float X;
	public float Y;
	public float Width;
	public float Height;


#endregion 

	// Use this for initialization
	void Start () {
        
        Screen.orientation = ScreenOrientation.LandscapeLeft;
        

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
        

        GUIStyle textFont = new GUIStyle();
        textFont.fontSize = 35;

        
        textFont.normal.textColor = Color.white;


        GUI.skin.button.fontSize = 30;

        GUI.skin.textField.fontSize = 30;
        GUI.skin.box.fontSize = 35;
        //create box to simulate window
        //float windowaspect = (float)Screen.width / (float)Screen.height;
        GUI.Box(new Rect(180, 100, (Screen.width / 4) + 600, (Screen.height / 4) + 320), "Log In");
        //create account button and login button.
        //Open create account window 
        if (GUI.Button(new Rect(420, 440, 250, 80), "Create Account"))
        {
            CurrentMenu = "CreateAccount";
        }
        
        if (GUI.Button(new Rect(740,440, 250,80), "Log In"))
        {
            StartCoroutine(LoginAccount());
            
        } //End button
        //Email
        GUI.Label(new Rect(220, 220, 250, 60), "Email:", textFont);
        Email = GUI.TextField(new Rect(420, 190, 570, 80), Email);
        //Password
        GUI.Label(new Rect(220, 340, 250, 60), "Password:", textFont);
        Password = GUI.PasswordField(new Rect(420, 320, 570, 80), Password, "*"[0],25);


    }//End Login GUI


	// This method will be the GUI for creating the account
	void CreateAccountGUI(){

        GUIStyle textFont = new GUIStyle();
        textFont.fontSize = 25;
        
        textFont.normal.textColor = Color.white;
        
        GUI.skin.button.fontSize = 25;

        GUI.skin.textField.fontSize = 30;
        GUI.skin.box.fontSize = 25;

        //create box to simulate window
        GUI.Box(new Rect(180, 105, (Screen.width / 4) + 600, (Screen.height / 4) + 320), "Create your account");
        //GUI.Box(new Rect(180, 50, 300, 220), "Create Account");

        //Email and password , plus confirmation
        GUI.Label(new Rect(200, 180, 100, 50), "Email or Name:", textFont);
        CEmail = GUI.TextField(new Rect(530, 160, 480, 65), CEmail);

        GUI.Label(new Rect(200, 260, 100, 50), "Confirm Name or Email:", textFont);
        ConfirmEmail = GUI.TextField(new Rect(530, 240, 480, 65), ConfirmEmail);
        
        GUI.Label(new Rect(200, 350, 100, 50), "Password: ", textFont);
        CPassword = GUI.PasswordField(new Rect(530, 330, 480, 65), CPassword, "*"[0], 25);

        GUI.Label(new Rect(200, 440, 100, 50), "Confirm Password:", textFont);
        ConfirmPass = GUI.PasswordField(new Rect(530, 420, 480, 65), ConfirmPass, "*"[0], 25);
        //create random int field for bot protection

        //create account button and login button.
        //Open create account window 
        if (GUI.Button(new Rect(525, 515, 250, 50), "Create Account"))
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
        if (GUI.Button(new Rect(815, 515, 190, 50), "Exit"))
        {
            CurrentMenu = "Login";
        } //End button
    }//End create account GUI
    #endregion

    #region coruoutine
    //Actually create account
    IEnumerator CreateAccount()
    {
        WWWForm Form = new WWWForm();
        Form.AddField("Email", CEmail);
        Form.AddField("Password", CPassword);
        WWW CreateAccount = new WWW(CreateAcountUrl, Form);
        //wait for php to send something back to unity
        yield return CreateAccount;
        if (CreateAccount.error != null)
        {
            Debug.LogError("Cannot connect to Account Creation");
        }
        else
        {
            string CreateAccountReturn = CreateAccount.text;
            if (CreateAccountReturn == "Success")
            {
                Debug.Log("Success: Account created");
                CurrentMenu = "Login";
            }
        }// End else


    } //End create account



   // Actual log in
    IEnumerator LoginAccount()
    {
        //Add out values that will go into the php script
        
        WWWForm Form = new WWWForm();
        //Make sure the email and password are spell the very same in the php script
        Form.AddField("Email", Email);
        Form.AddField("Password", Password);
        //Connect to the url
        WWW LoginAccountWWW = new WWW(LoginUrl, Form);
        yield return LoginAccountWWW;
        if(LoginAccountWWW.error != null)
        {
            Debug.LogError("Can't connect to the log in");
        }
        else
        {
            string LogText = LoginAccountWWW.text;
            Debug.Log(LogText);
            string[] LogTextSplit = LogText.Split(':');
            if(LogTextSplit[0] == "0")
            {
                if(LogTextSplit[1] == "Success")
                {
                    Application.LoadLevel("CharacterCreation");
                }

            }
            else
            {
                if (LogTextSplit[1] == "Success")
                {
                    Application.LoadLevel("CharacterSelection");
                }
            }

        }


    } // End login

    #endregion

}//End class
