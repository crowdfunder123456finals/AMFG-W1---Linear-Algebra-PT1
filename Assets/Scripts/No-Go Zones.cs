using UnityEngine;
using UnityEngine.SceneManagement;

public class NoGoZone : MonoBehaviour
{
    [Header("Zone Settings")]
    public float warningDistance = 3f;   // Starts shaking & turning red
    public float dangerDistance = 1.5f;  // Restarts scene
    public Color warningColor = Color.red;

    [Header("Shake Settings")]
    public float shakeIntensity = 0.1f;
    public float shakeSpeed = 20f;

    private Transform player;
    private SpriteRenderer sr;
    private Vector3 originalPos;
    private Color originalColor;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        sr = GetComponent<SpriteRenderer>();
        originalPos = transform.position;
        originalColor = sr.color;
    }

    void Update()
    {
        if (player == null) return;

        // Manual distance calculation
        float dx = player.position.x - transform.position.x;
        float dy = player.position.y - transform.position.y;
        float dist = Mathf.Sqrt(dx * dx + dy * dy);

        if (dist < warningDistance)
        {
            // Turn red
            sr.color = Color.Lerp(sr.color, warningColor, Time.deltaTime * 5f);

            // Shake
            float offsetX = Mathf.Sin(Time.time * shakeSpeed) * shakeIntensity;
            float offsetY = Mathf.Cos(Time.time * shakeSpeed) * shakeIntensity;
            transform.position = new Vector3(originalPos.x + offsetX, originalPos.y + offsetY, originalPos.z);

            // Restart scene if too close
            if (dist < dangerDistance)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
        else
        {
            // Reset
            transform.position = originalPos;
            sr.color = Color.Lerp(sr.color, originalColor, Time.deltaTime * 5f);
        }
    }
}
