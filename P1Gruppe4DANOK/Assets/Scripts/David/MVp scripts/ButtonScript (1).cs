using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using TMPro.EditorUtilities;

public class ButtonScript : MonoBehaviour
{
    

    public GameObject Logic;
    public WordGenerator wordGenerator;
    string Letter;
    public TMP_Text KeyTxt;
    public TMP_Text WordTxt;
    AudioSource SFXPlayer;
    

    void Start()
    {
        Logic = GameObject.Find("Logic");
        wordGenerator = Logic.GetComponent<WordGenerator>();
        SFXPlayer = GetComponent<AudioSource>();
        Letter = wordGenerator.LetterString;

        //Finds button and adds listener to click
        Button Key = GetComponent<Button>();
        Key.onClick.AddListener(TaskOnClick);
    }
    private void Update()
    {
        Letter = wordGenerator.LetterString;

    }
    void TaskOnClick()
    {


        if (Letter == KeyTxt.text)
        {
            Debug.Log("Correct answer!");
            wordGenerator.DanokWordTxt.text = wordGenerator.ChosenWord;
            SFXPlayer.Play();
            Invoke("NextWord", 5f);
            
        }
        else
        {
            Debug.Log("Wrong! Try again.");
        }
    }
    void NextWord()
    {
        wordGenerator.WordChooser();
    }
}
