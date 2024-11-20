using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameSettings : MonoBehaviour
{
    //variables for speakers settings
    public Slider volumeSlider;
    public Toggle woman1Toggle;
    public Toggle woman2Toggle;
    public Toggle man1Toggle;
    public Toggle man2Toggle;

    //variables for noise levels and type settings
    public Slider noiseLevelSlider;
    public Toggle intermittentNoiseToggle; //afburdt baggrundsstøj
    public Toggle continiousNoiseToggle; //kontinuerlig baggrundstøj

    //toggles for chosing if user guessses first or seccond consonant
    public Toggle firstConsonantToggle;
    public Toggle secondConsonantToggle;

    //toggles for letter/word selection
    public Toggle[] firstConsonants;
    public Toggle[] vowels;
    public Toggle[] secondConsonants;

    //variable for displaying amount of words relative to selected letters
    public TextMeshProUGUI wordCountText;

    //buttons for actions
    public Button calibrateButton;
    public Button startTestButton; 


    // Start is called before the first frame update
    private void Start()
    {
        //button click "listeners" 
        //calibrateButton.onClick.AddListener(Calibrate);
        //startTestButton.onClick.AddListener.(StartTest);

        //default values for sliders 
        volumeSlider.value = 50;

        //display update wordcount
        UpdateWordCount();
    }

    private void Calibrate()
    {
        Debug.Log("Starter Kalibrering");
        //add logic to start ..
    }

    private void StartTest()
    {
        Debug.Log("Starter Test");
        //add logic to start actual tes...!

        //program cheks what consonant is selected
        if (IsFirstConsonantSelected())
        {
            Debug.Log("Brugeren skal identificere første konsonant.");
        }
        else
        {
            Debug.Log("Brugeren skal identificere anden konsonant.");
        }
           
    }


    public void UpdateWordCount()
    {
        int wordCount = 0; //start counting from zero

        foreach (Toggle toggle in firstConsonants)
        {
            if (toggle.isOn) //checks is toggle is selected
            {
                wordCount++; //adss 1 to count
            }
        }

        foreach (Toggle toggle in vowels)
        {
            if (toggle.isOn)
            {
                wordCount++;
            }
        }

        foreach (Toggle toggle in secondConsonants)
        {
            if (toggle.isOn)
            {
                wordCount++;
            }
        }

        //updates wordcount display
        wordCountText.text = "Antal ord: " + wordCount;

    }

    private bool IsFirstConsonantSelected()
    {
        return firstConsonantToggle.isOn;
    }

}
