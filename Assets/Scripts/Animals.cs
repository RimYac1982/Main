using UnityEngine;

public class Animals : MonoBehaviour
{
    public float speed = 5f;

    private float leftEdge;
   

    private void Start()
    {
        leftEdge = Camera.main.ViewportToWorldPoint(new Vector3(0f, 0f, 0f)).x - 10f;
        
    }

    public void Update()
    {
        transform.position += Vector3.left * speed * Time.deltaTime;

        if (transform.position.x < leftEdge)
        {
            Destroy(gameObject);
        }
    }
}
