using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject prefab;
    public float spawnRate = 1f;
    public float minHeight = -1f;
    public float maxHeight = 1f;

    // Reference to the PlayerController script
    private PlayerController playerController;

    private void OnEnable()
    {
        InvokeRepeating(nameof(Spawn), spawnRate, spawnRate);

        // Find and store the PlayerController component
        playerController = FindObjectOfType<PlayerController>();
    }

    private void OnDisable()
    {
        CancelInvoke(nameof(Spawn));
    }

    private void Spawn()
    {
        GameObject rocks = Instantiate(prefab, transform.position, Quaternion.identity);
        rocks.transform.position += Vector3.up * Random.Range(minHeight, maxHeight);
    }

}
