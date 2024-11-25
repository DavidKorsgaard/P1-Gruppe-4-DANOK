using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplySelection : MonoBehaviour
{
    public GameObject[] hats; // Array to hold hats
    public GameObject[] bottoms; // Array to hold bottoms

    void Start()
    {
        int selectedHatIndex = CharacterSelection.SelectedHatIndex;
        int selectedBottomIndex = CharacterSelection.SelectedBottomIndex;
        Debug.Log("Loaded selections: Hat Index - " + selectedHatIndex + ", Bottom Index - " + selectedBottomIndex);

        ApplySelectionToCharacter(selectedHatIndex, selectedBottomIndex);
    }

    void ApplySelectionToCharacter(int hatIndex, int bottomIndex)
    {
        // Activate the selected hat and deactivate others
        for (int i = 0; i < hats.Length; i++)
        {
            hats[i].SetActive(i == hatIndex);
        }
        // Activate the selected bottom and deactivate others
        for (int i = 0; i < bottoms.Length; i++)
        {
            bottoms[i].SetActive(i == bottomIndex);
        }
    }
}
