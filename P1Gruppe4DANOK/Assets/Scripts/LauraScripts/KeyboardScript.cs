using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class KeyboardScript : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI displayPanelText; // TextMeshPro text in the panel above the keyboard
    //private PhonemeGame phonemeGame; // References the PhonemeGame script

    private void Start()
    {
        // Find the PhonemeGame script in the scene (or assign it manually in the Inspector)
       // phonemeGame = FindObjectOfType<PhonemeGame>();

        // Clear the display panel at the start
        displayPanelText.text = "";
    }

    // This function will be called by each keyboard button
    public void OnLetterButtonClick(string letter)
    {
        displayPanelText.text = letter; // Update display with selected consonant
        //phonemeGame.OnConsonantSelected(letter); // Pass selected consonant to PhonemeGame for checking
    }
}

