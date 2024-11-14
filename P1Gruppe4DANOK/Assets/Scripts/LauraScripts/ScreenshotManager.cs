using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

public class ScreenshotManager : MonoBehaviour
{
    public string screenshotFileName = "screenshot.png";

    public void TakeScreenshot()
    {
        StartCoroutine(CaptureScreenshot());
    }

    private IEnumerator CaptureScreenshot()
    {
        // Wait for the end of the frame to ensure everything is rendered
        yield return new WaitForEndOfFrame();

        // Capture the screenshot
        string filePath = Path.Combine(Application.persistentDataPath, screenshotFileName);
        ScreenCapture.CaptureScreenshot(filePath);

        // Wait for the screenshot to be saved
        yield return new WaitForSeconds(0.5f);

        // Load the next scene
        SceneManager.LoadScene("DisplayScreenshotScene");
        
    }
}
