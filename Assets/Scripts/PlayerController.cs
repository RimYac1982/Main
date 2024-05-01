using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class PlayerController : MonoBehaviour
{
    private Rigidbody2D carRigidbody;
    public float moveSpeed = 5.0f; // Adjust the speed as needed
    public float minYPos = -2.44f;
    public float maxYPos = -0.271f;
    private SpriteRenderer spriteRenderer;
    public Sprite[] sprites; // Array of sprites for animation
    private int spriteIndex = 0; // Index to track current sprite
    private bool canMoveLeft = true; // Flag to track if the player can move left
    private bool canMoveRight = true; // Flag to track if the player can move right
    private bool scoringTriggered = false; // Flag to track if scoring trigger has been activated
    
    void Awake()
    {
        carRigidbody = GetComponent<Rigidbody2D>(); // Assign the Rigidbody2D component
        spriteRenderer = GetComponent<SpriteRenderer>(); // Assign the SpriteRenderer component
        if (carRigidbody == null)
        {
            Debug.LogError("Rigidbody2D component not found on the car GameObject!");
        }
        if (spriteRenderer == null)
        {
            Debug.LogError("SpriteRenderer component not found on the car GameObject!");
        }
    }
    

    void FixedUpdate()
    {
        ApplySteering();
    }
    
    void ApplySteering()
    {
        // Handle arrow key controls for movement
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector2 movement = new Vector2(moveHorizontal, moveVertical).normalized * moveSpeed;

        if (canMoveLeft || moveHorizontal > 0) // Only move left if the flag is true or the player is moving right
        {
            carRigidbody.velocity = movement;
        }
        else
        {
            carRigidbody.velocity = Vector2.up * moveVertical * moveSpeed; // Only allow vertical movement
        }

        // Limit the car's position along the Y-axis within a specified range
        Vector2 clampedPosition = transform.position;
        clampedPosition.y = Mathf.Clamp(clampedPosition.y, minYPos, maxYPos);
        transform.position = clampedPosition;
    }




    void UpdateSpriteAnimation()
    {
        // Check if there are sprites assigned for animation
        if (sprites != null && sprites.Length > 0)
        {
            // Increment sprite index
            spriteIndex++;
            // Loop sprite index if it exceeds the number of sprites
            if (spriteIndex >= sprites.Length)
                spriteIndex = 0;
            // Set the sprite to the current index
            spriteRenderer.sprite = sprites[spriteIndex];
        }
    }

  

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Obstacle"))
        {
            GameManager gameManager = FindObjectOfType<GameManager>();
            if (gameManager != null)
            {
                gameManager.GameOver();
            }
            else
            {
                Debug.LogError("GameManager not found in the scene!");
            }
        }
        else if (other.gameObject.CompareTag("LeftWall"))
        {
            canMoveLeft = false; // Set the flag to false when player collides with the wall
        }
        else if (other.gameObject.CompareTag("RightWall"))
        {
            canMoveRight = false; // Set the flag to false when player collides with the wall
        }
        else if (other.gameObject.CompareTag("Scoring") && !scoringTriggered)
        {
            scoringTriggered = true; // Set the flag to true to indicate scoring trigger has been activated

            GameManager gameManager = FindObjectOfType<GameManager>();
            if (gameManager != null)
            {
                gameManager.IncreaseScore(1);
            }
            else
            {
                Debug.LogError("GameManager not found in the scene!");
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("LeftWall"))
        {
            canMoveLeft = true; // Reset the flag when player exits the wall
        }
        else if (other.gameObject.CompareTag("RightWall"))
        {
            canMoveRight = true; // Reset the flag when player exits the wall
        }
        else if (other.gameObject.CompareTag("Scoring"))
        {
            scoringTriggered = false; // Reset the scoring trigger flag when the player moves away from the scoring trigger
        }
    }



     void Start()
    {
        // Get the player's renderer component
        spriteRenderer = GetComponent<SpriteRenderer>();

        // Initialize with default color or retrieve from PlayerPrefs
        if (PlayerPrefs.HasKey("PlayerColorR") && PlayerPrefs.HasKey("PlayerColorG") && PlayerPrefs.HasKey("PlayerColorB"))
        {
            float r = PlayerPrefs.GetFloat("PlayerColorR");
            float g = PlayerPrefs.GetFloat("PlayerColorG");
            float b = PlayerPrefs.GetFloat("PlayerColorB");
            Color savedColor = new Color(r, g, b);
            SetColor(savedColor);
        }
        else
        {
            // If no saved color found, initialize with default color
            Color defaultColor = spriteRenderer.material.color;
            SetColor(defaultColor);
        }
    }


    // Example method to get the player's color
    public Color GetColor()
    {
        // Return the current color of the player
        return GetComponent<Renderer>().material.color;
    }

    // Example method to set the player's color
    public void SetColor(Color newColor)
    {
        // Set the new color for the player
        GetComponent<Renderer>().material.color = newColor;
    }
}

