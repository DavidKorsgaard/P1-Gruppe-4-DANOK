using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    [SerializeField] private GameObject[] spriteImages; // Array of sprites to spawn (Sprite 1, Sprite 2, etc.)
    [SerializeField] private RectTransform respawnPanel; // The panel where the sprites will be spawned

    private void Start()
    {
      
        if (spriteImages == null || spriteImages.Length == 0)
        {
            Debug.LogWarning("No sprite images assigned!");
            return;
        }

        
        if (respawnPanel == null)
        {
            Debug.LogWarning("ReSpawn Panel is not assigned!");
            return;
        }

        
        SpawnAllSprites();
    }

    private void SpawnAllSprites()
    {
        // Calculates the world-space corners of the respawn panel
        Vector3[] corners = new Vector3[4];
        respawnPanel.GetWorldCorners(corners);

        // Loops through all sprite images and spawns them
        foreach (var spriteImage in spriteImages)
        {
            Vector3 spawnPosition = new Vector3(
                Random.Range(corners[0].x, corners[2].x), 
                Random.Range(corners[0].y, corners[2].y), 
                corners[0].z 
            );

            // Instantiates the sprite image
            GameObject newImage = Instantiate(spriteImage, spawnPosition, Quaternion.identity, respawnPanel);

            if (newImage != null)
            {
                
                RectTransform rectTransform = newImage.GetComponent<RectTransform>();
                if (rectTransform != null)
                {
                    // Converts world position to local position relative to the respawnPanel
                    rectTransform.anchoredPosition = respawnPanel.InverseTransformPoint(spawnPosition);
                }
            }
            else
            {
                Debug.LogWarning("Failed to instantiate sprite.");
            }
        }
    }
}