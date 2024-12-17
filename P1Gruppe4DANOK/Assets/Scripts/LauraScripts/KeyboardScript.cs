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
    
    //Alt til cooldowns p� buttons
    private bool isOnCooldown = false;
    private bool isOnCooldownBM = false;
    float cooldownTime = 4f;
    float cooldownTimeBM = 4f;

    //Referencer til SpriteSpawner
    public SpriteSpawnerScript SpriteSpawnerScript;
    public GameObject SpriteSpawner;
    private void Start()
    {
        //Her referere vi til forskellige gameobjects og scripts, og s�tter dem lig med
        //de variabler som vi tidligere lavede
        VoicePlayer = GameObject.Find("Audiomanager");
        SpeechScript = VoicePlayer.GetComponent<VoiceChooser>();
        SpriteSpawner = GameObject.Find("SpriteSpawner");
        SpriteSpawnerScript = SpriteSpawner.GetComponent<SpriteSpawnerScript>();
        Logic = GameObject.Find("Logic");
        wordGenerator = Logic.GetComponent<WordGenerator>();


    }
    //script der bruges til st�rstedelen af alle knapper
    public void TaskOnClick(GameObject button)
    {
        //Her finder vi det ord vi skal g�tte fra word generator
        Letter = wordGenerator.LetterString;
        //her s�tter vi buttonText lig med det bogstav der st�r p� knappen
        buttonText = button.GetComponentInChildren<TextMeshProUGUI>();
        //hvis bogstav p� knappen, er det samme som bogstavet fra WordGenerator
        if (Letter == buttonText.text)
        {
            Debug.Log("Correct answer!");
            //viser den gr�nne thumbs up
            ShowThumbsUp();
            //viser ordet i text feltet
            wordGenerator.DanokWordTxt.text = wordGenerator.ChosenWord;
            //checker i forhold om der er en cooldown p� knappen
            if (!isOnCooldown)
            {   
                //checker om der er spawnet alle 8 sprites, og at man skal g� videre
                if (SpriteSpawnerScript.clickCount == 8)
                {
                    SceneManager.LoadScene("TakeSelfieScene");
                }
                //k�rer det n�ste ord efter 3 sekunder
                Invoke("NextWord", 3f);
                //k�rer funktionen der spawner spritesne
                SpriteSpawnerScript.OnButtonClick();
                //starter cooldownen p� rigtigt svar knappen
                StartCooldown();
            }
            //Hvis knappen er p� cooldown
            else
            {
                Debug.Log("Button is on cooldown! Please wait.");
            }
        }
        //hvis det ikke er det samme p� knappen og fra WordGenerator
        else
        {
            ShowThumbsDown();
            Debug.Log("Wrong! Try again.");
        }

    }
    
    //Finde rdet n�ste ord og lydfil
    void NextWord()
    {
        wordGenerator.WordChooser();
    }
    //logiken til gentag lyd knappen.
    public void Gentag()
    {
         SpeechScript.PlaySameAudio(); 
    }
    //logikken til bogstav mangler, som virker p� samme m�de som de andre bogstag knapper
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
   
    //logikken p� thumbsup/thumbsdown knapperne
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

