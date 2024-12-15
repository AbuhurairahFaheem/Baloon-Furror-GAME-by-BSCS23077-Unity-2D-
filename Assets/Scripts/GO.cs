using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GO : MonoBehaviour
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
        spd = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        // Increase speed over time
        spd = Mathf.Min(spd + speedIncreaseRate * Time.deltaTime, maxSpeed);

        // Move the object upwards
        transform.Translate(0, spd * Time.deltaTime, 0);

        // Check if the object goes out of bounds
        if (transform.position.y > 7f)
        {
            SceneManager.LoadScene("GameOver1");
        }
    }

    private void OnMouseDown()
    {
        // Increment the score via the score manager
        if (score != null)
        {
            score.AddScore(1); // Add 1 to the score
        }

        source.Play(); // Play sound
        animator.SetTrigger("Pop"); // Trigger the animation
        StartCoroutine(ResetPositionWithDelay()); // Start coroutine for delay
    }

    private IEnumerator ResetPositionWithDelay()
    {
        yield return new WaitForSeconds(0.5f); // Wait for 0.5 seconds
        ResetPosition();
    }

    private void ResetPosition()
    {
        float randomx = Random.Range(-1.6f, 1.6f);
        transform.position = new Vector2(randomx, -7f);
    }
}
