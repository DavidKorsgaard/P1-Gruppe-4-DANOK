using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

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
    private Button button;
    private bool isOnCooldown = false; 
    private bool isOnCooldownSkip = false;
    public float cooldownTime = 7f;
    public float cooldownTimeSkip = 4f;
    private void Start()
    {
        // Find the PhonemeGame script in the scene (or assign it manually in the Inspector)
        // phonemeGame = FindObjectOfType<PhonemeGame>();
        VoicePlayer = GameObject.Find("Audiomanager");
        SpeechScript = VoicePlayer.GetComponent<VoiceChooser>();
        // Clear the display panel at the start
        displayPanelText.text = "";
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
            wordGenerator.DanokWordTxt.text = wordGenerator.ChosenWord;
            if (!isOnCooldown)
            {
                Debug.Log("Button pressed, invoking function!");
                Invoke("NextWord", 5f);

                StartCooldown();
            }
            else
            {
                Debug.Log("Button is on cooldown! Please wait.");
            }
        }
        else
        {
            Debug.Log("Wrong! Try again.");
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
    public void Skip()
    {
        
        if (!isOnCooldownSkip)
        {
            Debug.Log("Skip");
            NextWord();
            StartCooldownSkip();
            
        }
        else
        {
            Debug.Log("Button is on cooldown! Please wait.");
        }

    }
    private void StartCooldownSkip()
    {
        isOnCooldownSkip = true;
        Invoke("ResetCooldownSkip", cooldownTime);
    }

    private void ResetCooldownSkip()
    {
        isOnCooldownSkip = false;
        Debug.Log("Cooldown Skip reset. Button can be pressed again.");
    }

}

