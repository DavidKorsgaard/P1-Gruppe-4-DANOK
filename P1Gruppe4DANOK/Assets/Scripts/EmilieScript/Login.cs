using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class Login : MonoBehaviour
{
    //Input field and The warning message fields that reference objects
    public TMP_InputField UsernameField;
    public TMP_InputField LoginField;
    public TMP_Text WarningFeedback;

    //We're making a standard username and code for the demonstration
    private string Username = "DANOKROCKS";
    private string LoginCode = "Medialogi";

    public void ValidateLogin()
    {

        // validates input by comparing input with standard
        if (UsernameField.text == Username && LoginField.text == LoginCode)
        {
            Debug.Log("Both the username and entered Login is correct");
            SceneManager.LoadScene("MenuScene");
        }
        else
        {
            WarningFeedback.text = "Incorrect username or loginCode.";
            WarningFeedback.color = Color.red;
        }
    }

}
