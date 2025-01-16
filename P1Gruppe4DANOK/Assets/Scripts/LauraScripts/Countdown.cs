using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro; // cus im using TextMeshPro

public class CountdownTimer : MonoBehaviour
{
    public float countdownTime = 5f; // Time in seconds. f is just c#
    public TextMeshProUGUI countdownText; // To drag my TextMeshPro UI element here
    public string nextSceneName; // Name of the next scene to load

    private float timeRemaining;

    void Start()
    {
        timeRemaining = countdownTime;
    }

    void Update()
    {
        // here the program checks if timeRemaining is greater than 0 and will keep counting down in accordance to time.deltaTime if so.
        // when equal to zero the next scene is loaded
        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime; 
            // -= allows the Mathf.Ceil function to return subtracted numbers
            countdownText.text = Mathf.Ceil(timeRemaining).ToString(); //to string so it converts to text 
            // Mathf.Ceil returns the smallest number(float) greater than or equal to f wich here is time remaining. 
        }
        else
        {
            LoadNextScene();
        }
    }

    //method to load next scene 
    void LoadNextScene()
    {
        SceneManager.LoadScene(nextSceneName);
    }
}
