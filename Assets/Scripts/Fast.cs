using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Fast : MonoBehaviour
{
    public float spd = 1f; // Initial speed
    private AudioSource source; // Audio source for sound effects
    private Animator animator; // Reference to the Animator component
    public scorescript score; // Reference to the external score manager
    public float speedIncreaseRate = 0.1f; // Rate at which speed increases
    public float maxSpeed = 5f; // Maximum speed limit

    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
        animator = GetComponent<Animator>(); // Initialize the Animator component
        spd = 2f;
    }

    // Update is called once per frame
    void Update()
    {
        // Increase speed over time
        spd = Mathf.Min(spd + speedIncreaseRate * Time.deltaTime, maxSpeed);

        // Move the object upwards and oscillate horizontally
        float horizontalMovement = Mathf.Sin(Time.time * spd) * 0.5f; // Oscillation logic
        transform.Translate(horizontalMovement * Time.deltaTime, spd * Time.deltaTime, 0);

        // Check if the object goes out of bounds
        if (transform.position.y > 20f)
        {
            Respawn();
        }
    }

    private void OnMouseDown()
    {
        // Double the speed of all objects with the same script
        GO2[] objects = FindObjectsOfType<GO2>();
        foreach (GO2 obj in objects)
        {
            obj.spd *= 2f; // Double the speed
        }
    }

    private void Respawn()
    {
        float randomx = Random.Range(-1.6f, 1.6f);
        transform.position = new Vector2(randomx, -7f);
    }
}
