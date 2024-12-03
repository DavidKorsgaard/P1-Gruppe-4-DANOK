using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Login : MonoBehaviour
{
    //Input field and The warning message fields that reference objects
    public TMP_InputField UsernameField;
    public TMP_InputField LoginField;
    public TMP_Text WarningFeedback;

    //Setting a standard username and code for the demonstration
    private string Username = "DANOKROCKS";
    private string LoginCode = "Medialogi";

    public void ValidateLogin()
    {

        // validate input by comparing innput with standard
        if (UsernameField.text == Username && LoginField.text == LoginCode)
        {
            Debug.Log("Both the username and entered Login is correct");
        }
        else
        {
            WarningFeedback.text = "Incorrect username or loginCode.";
            WarningFeedback.color = Color.red;
        }
    }

}
