using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class KeyboardScript : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI displayPanelText; // TextMeshPro text in the panel above the keyboard
    //private PhonemeGame phonemeGame; // References the PhonemeGame script
    public GameObject Logic;
    public WordGenerator wordGenerator;
    public string Letter;
    private TextMeshProUGUI buttonText;
    public TMP_Text WordTxt;
    AudioSource SFXPlayer;
    public VoiceChooser SpeechScript;
    public GameObject VoicePlayer;
    private bool isOnCooldown = false;
    private bool isOnCooldownBM = false;
    float cooldownTime = 4f;
    float cooldownTimeBM = 4f;
    public SpriteSpawnerScript SpriteSpawnerScript;
    public GameObject SpriteSpawner;
    private void Start()
    {

        VoicePlayer = GameObject.Find("Audiomanager");
        SpeechScript = VoicePlayer.GetComponent<VoiceChooser>();
        SpriteSpawner = GameObject.Find("SpriteSpawner");
        SpriteSpawnerScript = SpriteSpawner.GetComponent<SpriteSpawnerScript>();
        Logic = GameObject.Find("Logic");
        wordGenerator = Logic.GetComponent<WordGenerator>();


    }

    // This function will be called by each keyboard button
    public void OnLetterButtonClick(string letter)
    {
        displayPanelText.text = letter; // Update display with selected consonant
        //phonemeGame.OnConsonantSelected(letter); // Pass selected consonant to PhonemeGame for checking
    }
    public void TaskOnClick(GameObject button)
    {
        Letter = wordGenerator.LetterString;
        buttonText = button.GetComponentInChildren<TextMeshProUGUI>();

        if (Letter == buttonText.text)
        {
            Debug.Log("Correct answer!");
            ShowThumbsUp();
            wordGenerator.DanokWordTxt.text = wordGenerator.ChosenWord;
            if (!isOnCooldown)
            {
                if (SpriteSpawnerScript.clickCount == 8)
                {
                    SceneManager.LoadScene("TakeSelfieScene");
                }
                Invoke("NextWord", 3f);
                SpriteSpawnerScript.OnButtonClick();
                StartCooldown();
            }
            else
            {
                Debug.Log("Button is on cooldown! Please wait.");
            }
        }
        else
        {
            ShowThumbsDown();
            Debug.Log("Wrong! Try again.");
        }

    }
    

    void NextWord()
    {
        wordGenerator.WordChooser();
    }

    public void Gentag()
    {
        if (SpeechScript != null)
        {
            SpeechScript.PlaySameAudio();
        }
        else
        {
            Debug.LogError("VoiceChooser is null. Cannot play audio!");
        }
    }
    public void BogstavMangler()
    {

        if (!isOnCooldownBM)
        {
            if (SpriteSpawnerScript.clickCount == 8)
            {
                SceneManager.LoadScene("TakeSelfieScene");
            }
            Debug.Log("BogstavMangler");
            NextWord();
            StartCooldownBM();
            SpriteSpawnerScript.OnButtonClick();
            
        }
        else
        {
            Debug.Log("Button is on cooldown! Please wait.");
        }

    }
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
    private void StartCooldownBM()
    {
        isOnCooldownBM = true;
        Invoke("ResetCooldownBM", cooldownTimeBM);
    }

    private void ResetCooldownBM()
    {
        isOnCooldownBM = false;
        Debug.Log("Cooldown MB reset. Button can be pressed again.");
    }
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

