using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class KeyboardScript : MonoBehaviour
{
    //logik til genkendelse af ord
    public GameObject Logic;
    public WordGenerator wordGenerator;

    //Referencer og variabler til visning af kode
    public string Letter;
    private TextMeshProUGUI buttonText;
    public TMP_Text WordTxt;

    //Referencer til VoiceChooser scriptet
    public VoiceChooser SpeechScript;
    public GameObject VoicePlayer;
    
    //Alt til cooldowns på buttons
    private bool isOnCooldown = false;
    private bool isOnCooldownBM = false;
    float cooldownTime = 4f;
    float cooldownTimeBM = 4f;

    //Referencer til SpriteSpawner
    public SpriteSpawnerScript SpriteSpawnerScript;
    public GameObject SpriteSpawner;
    private void Start()
    {
        //Her referere vi til forskellige gameobjects og scripts, og sætter dem lig med
        //de variabler som vi tidligere lavede
        VoicePlayer = GameObject.Find("Audiomanager");
        SpeechScript = VoicePlayer.GetComponent<VoiceChooser>();
        SpriteSpawner = GameObject.Find("SpriteSpawner");
        SpriteSpawnerScript = SpriteSpawner.GetComponent<SpriteSpawnerScript>();
        Logic = GameObject.Find("Logic");
        wordGenerator = Logic.GetComponent<WordGenerator>();


    }
    //script der bruges til størstedelen af alle knapper
    public void TaskOnClick(GameObject button)
    {
        //Her finder vi det ord vi skal gætte fra word generator
        Letter = wordGenerator.LetterString;
        //her sætter vi buttonText lig med det bogstav der står på knappen
        buttonText = button.GetComponentInChildren<TextMeshProUGUI>();
        //hvis bogstav på knappen, er det samme som bogstavet fra WordGenerator
        if (Letter == buttonText.text)
        {
            Debug.Log("Correct answer!");
            //viser den grønne thumbs up
            ShowThumbsUp();
            //viser ordet i text feltet
            wordGenerator.DanokWordTxt.text = wordGenerator.ChosenWord;
            //checker i forhold om der er en cooldown på knappen
            if (!isOnCooldown)
            {   
                //checker om der er spawnet alle 8 sprites, og at man skal gå videre
                if (SpriteSpawnerScript.clickCount == 8)
                {
                    SceneManager.LoadScene("TakeSelfieScene");
                }
                //kører det næste ord efter 3 sekunder
                Invoke("NextWord", 3f);
                //kører funktionen der spawner spritesne
                SpriteSpawnerScript.OnButtonClick();
                //starter cooldownen på rigtigt svar knappen
                StartCooldown();
            }
            //Hvis knappen er på cooldown
            else
            {
                Debug.Log("Button is on cooldown! Please wait.");
            }
        }
        //hvis det ikke er det samme på knappen og fra WordGenerator
        else
        {
            ShowThumbsDown();
            Debug.Log("Wrong! Try again.");
        }

    }
    
    //Finde rdet næste ord og lydfil
    void NextWord()
    {
        wordGenerator.WordChooser();
    }
    //logiken til gentag lyd knappen.
    public void Gentag()
    {
         SpeechScript.PlaySameAudio(); 
    }
    //logikken til bogstav mangler, som virker på samme måde som de andre bogstag knapper
    public void BogstavMangler()
    {

        if (!isOnCooldown)
        {
            if (SpriteSpawnerScript.clickCount == 8)
            {
                SceneManager.LoadScene("TakeSelfieScene");
            }
            Debug.Log("BogstavMangler");
            NextWord();
            StartCooldown();
            SpriteSpawnerScript.OnButtonClick();
            
        }
        else
        {
            Debug.Log("Button is on cooldown! Please wait.");
        }

    }
    //logiken til alle cooldown mekanikkerne
    private void StartCooldown()
    {
        isOnCooldown = true;
        Invoke("ResetCooldown", cooldownTime);
    }

    private void ResetCooldown()
    {
        isOnCooldown = false;
        Debug.Log("Cooldown reset. Button can be pressed again.");
    }
   
    //logikken på thumbsup/thumbsdown knapperne
    private void ShowThumbsUp()
    {
        SpeechScript.ThumbsUp.SetActive(true);
        Invoke("HideThumbsUp", 1f);
    }
    private void HideThumbsUp()
    {
        SpeechScript.ThumbsUp.SetActive(false);
    }
    private void ShowThumbsDown()
    {
        SpeechScript.ThumbsDown.SetActive(true);
        Invoke("HideThumbsDown", 1f);
    }
    private void HideThumbsDown()
    {
        SpeechScript.ThumbsDown.SetActive(false);
    }
}

