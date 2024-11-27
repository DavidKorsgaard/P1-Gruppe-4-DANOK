using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteSpawnerScript : MonoBehaviour
{
    [SerializeField] private GameObject[] spriteImages; // Array of UI images to spawn
    [SerializeField] private RectTransform spawnPanel; // The panel where the images will be spawned

    private int clickCount = 0; // Tracks the number of clicks
    private List<GameObject> spawnedImages = new List<GameObject>(); // Keeps track of spawned images
    private int spriteIndex = 0; // Tracks the current sprite to use

    private void Start()
    {
        // Ensure all sprite images are assigned
        if (spriteImages == null || spriteImages.Length == 0)
        {
            Debug.LogWarning("No sprite images assigned!");
        }

        // Make sure spawnPanel is assigned
        if (spawnPanel == null)
        {
            Debug.LogWarning("Spawn Panel is not assigned!");
        }
    }

    
    public void OnButtonClick()
    {
        //click count
        clickCount++;

        // Every second click, spawn an image
        if (clickCount % 2 == 0)
        {
            // Check if all images are spawned
            if (spawnedImages.Count >= spriteImages.Length)
            {
                // Clear the spawned images and reset
                ClearImages();
            }
            else
            {
                // Spawn the next image in the sequence
                SpawnImage();
            }
        }
    }


    private void SpawnImage()
    {
        if (spriteImages.Length == 0) return;

        // Calculate the world-space corners of the spawn panel
        Vector3[] corners = new Vector3[4];
        spawnPanel.GetWorldCorners(corners);

        // Generate a random position within the bounds of the panel
        Vector3 spawnPosition = new Vector3(
            Random.Range(corners[0].x, corners[2].x), // Random X between left and right corners
            Random.Range(corners[0].y, corners[2].y), // Random Y between bottom and top corners
            corners[0].z // Keep the same Z position
        );

        // Instantiate the sprite image
        GameObject newImage = Instantiate(spriteImages[spriteIndex], spawnPosition, Quaternion.identity, spawnPanel);

        if (newImage != null)
        {
            // Ensure the image stays in its local hierarchy
            RectTransform rectTransform = newImage.GetComponent<RectTransform>();
            if (rectTransform != null)
            {
                // Convert world position to local position relative to the spawnPanel
                rectTransform.anchoredPosition = spawnPanel.InverseTransformPoint(spawnPosition);
            }

            // Add the image to the list of spawned images
            spawnedImages.Add(newImage);

            // Update the image index (loop back to the start if needed)
            spriteIndex = (spriteIndex + 1) % spriteImages.Length;
        }
        else
        {
            Debug.LogWarning("Failed to instantiate image.");
        }
    }


    private void ClearImages()
    {
        foreach (GameObject image in spawnedImages)
        {
            Destroy(image); // Destroy each image
        }

        spawnedImages.Clear(); // Clear the list
        Debug.Log("All images cleared.");
    }
}