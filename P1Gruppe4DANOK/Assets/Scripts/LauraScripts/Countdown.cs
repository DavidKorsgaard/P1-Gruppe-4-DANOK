using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro; // If you're using TextMeshPro

public class CountdownTimer : MonoBehaviour
{
    public float countdownTime = 5f; // Time in seconds
    public TextMeshProUGUI countdownText; // Drag your TextMeshPro UI element here
    public string nextSceneName; // Name of the next scene to load

    private float timeRemaining;

    void Start()
    {
        timeRemaining = countdownTime;
    }

    void Update()
    {
        // Update the countdown timer
        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
            countdownText.text = Mathf.Ceil(timeRemaining).ToString(); // Display whole numbers
        }
        else
        {
            LoadNextScene();
        }
    }

    void LoadNextScene()
    {
        SceneManager.LoadScene(nextSceneName);
    }
}
