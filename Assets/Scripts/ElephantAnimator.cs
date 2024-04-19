using UnityEngine;

public class ElephantAnimator : MonoBehaviour
{
    private Rigidbody2D carRigidbody;
    private SpriteRenderer spriteRenderer;
    public Sprite[] sprites; // Array of sprites for animation
    private int spriteIndex = 0; // Index to track current sprite

    void Start()
    {
        // Get the SpriteRenderer component attached to this GameObject
        spriteRenderer = GetComponent<SpriteRenderer>();

        // Check if there are sprites assigned for animation
        if (sprites == null || sprites.Length == 0)
        {
            Debug.LogError("No sprites assigned for animation!");
        }
    }

    void FixedUpdate()
    {
        UpdateSpriteAnimation();
    }

    void UpdateSpriteAnimation()
    {
        // Check if there are sprites assigned for animation
        if (sprites != null && sprites.Length > 0)
        {
            // Flip the sprite if needed
            if (transform.localScale.x < 0) // Check if the scale along the X-axis is negative
            {
                spriteRenderer.flipX = true; // Flip the sprite horizontally
            }
            else
            {
                spriteRenderer.flipX = false; // Ensure the sprite is not flipped
            }
            // Increment sprite index
            spriteIndex++;
            // Loop sprite index if it exceeds the number of sprites
            if (spriteIndex >= sprites.Length)
                spriteIndex = 0;
            // Set the sprite to the current index
            spriteRenderer.sprite = sprites[spriteIndex];
        }
    }
}
