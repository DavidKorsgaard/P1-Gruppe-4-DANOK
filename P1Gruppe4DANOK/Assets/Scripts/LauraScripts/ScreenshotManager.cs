using UnityEngine;
using System;
using System.IO;

public class ScreenshotManager : MonoBehaviour
{
    private static string screenshotPath;

    public void CaptureScreenshot()
    {
        // Get the Pictures folder path
        string picturesPath = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);

        // Create a unique filename
        string timestamp = DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss");
        screenshotPath = Path.Combine(picturesPath, "screenshot_" + timestamp + ".png");

        // Save the screenshot
        ScreenCapture.CaptureScreenshot(screenshotPath);
        Debug.Log("Screenshot saved at: " + screenshotPath);
    }

    public static string GetScreenshotPath()
    {
        return screenshotPath;
    }
}

