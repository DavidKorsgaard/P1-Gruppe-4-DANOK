using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterC : MonoBehaviour
{
    public GameObject[] hats; // Array to hold hats
    public GameObject[] bottoms; // Array to hold bottoms
    private int currentHatIndex = 0;
    private int currentBottomIndex = 0;

    void Start()
    {
        if (hats.Length > 0)
        {
            for (int i = 0; i < hats.Length; i++)
            {
                hats[i].SetActive(i == currentHatIndex); // Shows the active hat from index
            }
        }
        if (bottoms.Length > 0)
        {
            for (int i = 0; i < bottoms.Length; i++)
            {
                bottoms[i].SetActive(i == currentBottomIndex); // Shows the active bottom from index
            }
        }
    }

    public void OnChangeHatButtonClick()
    {
        ChangeHat();
    }

    public void OnChangeBottomButtonClick()
    {
        ChangeBottom();
    }

    public void ChangeHat()
    {
        if (hats.Length == 0) return; // Prevent accessing an empty array
        hats[currentHatIndex].SetActive(false); // Deactivate the currently shown hat
        currentHatIndex = (currentHatIndex + 1) % hats.Length; // Move on to the next hat in the array
        hats[currentHatIndex].SetActive(true); // Activate the new hat
    }

    public void ChangeBottom()
    {
        if (bottoms.Length == 0) return; // Prevent accessing an empty array
        bottoms[currentBottomIndex].SetActive(false); // Deactivate the currently shown bottom
        currentBottomIndex = (currentBottomIndex + 1) % bottoms.Length; // Move on to the next bottom in the array
        bottoms[currentBottomIndex].SetActive(true); // Activate the new bottom
    }

    public void ConfirmSelection()
    {
        // Save the indices of the selected hat and bottom
        CharacterSelection.SelectedHatIndex = currentHatIndex;
        CharacterSelection.SelectedBottomIndex = currentBottomIndex;

        Debug.Log("Confirmed selections: Hat Index - " + currentHatIndex + ", Bottom Index - " + currentBottomIndex);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
