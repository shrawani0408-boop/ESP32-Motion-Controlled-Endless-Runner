using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    private Vector3 originalScale;

    public float runSpeed = 3f;
    public float jumpForce = 15f;
    public float jumpCooldown = 0.3f;

    private float lastJumpTime = 0f;
    private bool isSliding = false;

    public GameObject gameOverText;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        originalScale = transform.localScale;

        if (gameOverText != null)
        {
            gameOverText.SetActive(false);
        }

        Time.timeScale = 1f;
    }

    void Update()
    {
        // Keyboard Jump
        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            Jump();
        }

        // Keyboard Slide
        if (Keyboard.current.sKey.wasPressedThisFrame)
        {
            Slide();
        }

        // Restart
        if (Keyboard.current.rKey.wasPressedThisFrame)
        {
            SceneManager.LoadScene(
                SceneManager.GetActiveScene().buildIndex
            );
        }
    }

    public void Jump()
    {
        if (Time.time - lastJumpTime < jumpCooldown)
            return;

        lastJumpTime = Time.time;

        rb.linearVelocity = new Vector3(
            rb.linearVelocity.x,
            0f,
            rb.linearVelocity.z
        );

        rb.AddForce(
            Vector3.up * jumpForce,
            ForceMode.Impulse
        );
    }

    public void Slide()
    {
        if (!isSliding)
        {
            StartCoroutine(SlideRoutine());
        }
    }

    private System.Collections.IEnumerator SlideRoutine()
    {
        isSliding = true;

        transform.localScale = new Vector3(
            originalScale.x,
            originalScale.y * 0.25f,
            originalScale.z
        );

        Debug.Log("SLIDING");

        yield return new WaitForSeconds(2f);

        transform.localScale = originalScale;

        isSliding = false;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.Contains("Obstacle"))
        {
            Debug.Log("GAME OVER");

            if (gameOverText != null)
            {
                gameOverText.SetActive(true);
            }

            Time.timeScale = 0f;
        }
    }
}