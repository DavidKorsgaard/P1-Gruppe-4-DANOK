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

    // Method to handle every button click
    public void OnButtonClick()
    {
        // Increment click count
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

    // Method to spawn an image in the panel
    private void SpawnImage()
    {
        if (spriteImages.Length == 0) return;

        Vector2 spawnSize = spawnPanel.sizeDelta;
        Vector2 spawnPosition = new Vector2(
            Random.Range(-spawnSize.x / 2, spawnSize.x / 2),
            Random.Range(-spawnSize.y / 2, spawnSize.y / 2)
        );

        // Convert local spawn position to world space
        Vector3 worldPosition = spawnPanel.TransformPoint(spawnPosition);

        // Instantiate the image at the calculated world position
        GameObject newImage = Instantiate(spriteImages[spriteIndex], worldPosition, Quaternion.identity, spawnPanel);

        if (newImage != null)
        {
            // Set the local position of the image inside the spawn panel
            RectTransform rectTransform = newImage.GetComponent<RectTransform>();
            if (rectTransform != null)
            {
                rectTransform.anchoredPosition = spawnPosition; // Set the anchored position in the panel
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

    // Method to clear all spawned images
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