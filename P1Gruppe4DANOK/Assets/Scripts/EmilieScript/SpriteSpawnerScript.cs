using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteSpawnerScript : MonoBehaviour
{
    [SerializeField] private GameObject spritePrefab; // Prefab of the sprite to spawn
    [SerializeField] private Transform spawnParent; // Parent object to hold spawned sprites
    [SerializeField] private Vector2 spawnArea; // Width and height of spawnable area for sprites
    [SerializeField] private Sprite[] desiredSprites; // Array of sprites to use for spawning (sprite 1, sprite 2, sprite 3, sprite 4)

    private int clickCount = 0; // Tracks the number of clicks
    private List<GameObject> spawnedSprites = new List<GameObject>(); // Keeps track of spawned sprites
    private int spriteIndex = 0; // Tracks the current sprite to use

    private void Start()
    {
        // Make sure that the prefab is assigned
        if (spritePrefab == null)
        {
            Debug.LogWarning("Sprite Prefab is not assigned!");
        }

        // Make sure the spawnParent is assigned
        if (spawnParent == null)
        {
            Debug.LogWarning("Spawn Parent is not assigned!");
        }
    }

    // Method to handle every button click
    public void OnButtonClick()
    {
        // Increment click count
        clickCount++;

        // Every second click, spawn a sprite
        if (clickCount % 2 == 0)
        {
            // Check if there are already 4 sprites on screen
            if (spawnedSprites.Count >= 4)
            {
                ClearSprites(); // Clear all sprites
            }
            else
            {
                SpawnSprite(); // Spawn a new sprite
            }
        }
    }

    // Method to spawn a sprite
    private void SpawnSprite()
    {
        // Origin point for spawning
        Vector3 originPoint = new Vector3(-60f, -200f, 0f);  

        // Randomize position within the specified spawn area, relative to the origin point
        Vector3 spawnPosition = new Vector3(
            originPoint.x + Random.Range(-spawnArea.x / 2, spawnArea.x / 2), // Randomize X
            originPoint.y + Random.Range(-spawnArea.y / 2, spawnArea.y / 2), // Randomize Y
            0 // Ensure Z position
        );

        // Instantiate the sprite prefab
        GameObject newSprite = Instantiate(spritePrefab, spawnPosition, Quaternion.identity, spawnParent);

        if (newSprite != null)
        {
            // Set the sprite for the SpriteRenderer
            SpriteRenderer spriteRenderer = newSprite.GetComponent<SpriteRenderer>();
            if (spriteRenderer != null && desiredSprites.Length > 0)
            {
                spriteRenderer.sprite = desiredSprites[spriteIndex];

                // Update the sprite index (loop back to the start if needed)
                spriteIndex = (spriteIndex + 1) % desiredSprites.Length;
            }
            else
            {
                Debug.LogWarning("SpriteRenderer component not found or desiredSprites array is empty.");
            }

            // Add the sprite to the list
            spawnedSprites.Add(newSprite);
        }
        else
        {
            Debug.LogWarning("Failed to instantiate sprite.");
        }
    }

    // Method to clear all spawned sprites
    private void ClearSprites()
    {
        foreach (GameObject sprite in spawnedSprites)
        {
            Destroy(sprite); // Destroy each sprite
        }

        spawnedSprites.Clear(); // Clear the list
        Debug.Log("All sprites cleared.");
    }
}