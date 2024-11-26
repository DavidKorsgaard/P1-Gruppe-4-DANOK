using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class KeyboardScript : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI displayPanelText; // TextMeshPro text in the panel above the keyboard


    private void Start()
    {

        displayPanelText.text = ""; // Clear the display panel at the start
    }

    public void OnLetterButtonClick(string letter)
    {
        displayPanelText.text = letter; // Update display with selected letter


    }
}
       