using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorManager : MonoBehaviour
{
    // Singleton instance
    public static ColorManager Instance;

    // Reference to the player GameObject
    public GameObject player;

    // Private variables to store the player's color components
    private float[] colors = { 0, 0, 0 };

    void Awake()
    {
        // Check if instance already exists
        if (Instance == null)
        {
            // If not, set the instance to this
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            // If instance already exists and it's not this, destroy this
            if (Instance != this)
            {
                Destroy(gameObject);
            }
        }
    }

    void Start()
    {
        // Get the PlayerController component from the player GameObject
        PlayerController playerScript = player.GetComponent<PlayerController>();

        // Get the initial color of the player and store its components
        Color startColor = playerScript.GetColor();
        colors[0] = startColor.r;
        colors[1] = startColor.g;
        colors[2] = startColor.b;
    }

    public void ChangePlayerColor(int rgbIndex, float colorFloat)
    {
        // Update the corresponding color component
        colors[rgbIndex] = colorFloat;

        // Create a new color using the updated components
        Color newColor = new Color(colors[0], colors[1], colors[2]);

        // Set the new color for the player
        PlayerController playerScript = player.GetComponent<PlayerController>();
        playerScript.SetColor(newColor);

    }
}
