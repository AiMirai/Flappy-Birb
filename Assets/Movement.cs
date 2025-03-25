
using UnityEngine;

public class ParallaxBackground : MonoBehaviour
{
    public float speed = 2f;  // Speed of scrolling
    private float width;      // Width of the sprite

    void Start()
    {
        width = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    void Update()
    {
        // Move the background left
        transform.position -= new Vector3(speed * Time.deltaTime, 0, 0);

        // Smooth transition fix: Reset position *slightly* earlier to prevent gaps
        if (transform.position.x <= -width + 0.1f)  // 0.1f ensures no delay
        {
            transform.position += new Vector3(width * 2f, 0, 0);
        }
    }
}
