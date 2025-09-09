using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FinishZone : MonoBehaviour
{
    [Header("Finish Settings")]
    public float triggerDistance = 1.5f;
    public GameObject winUI;   // Assign a UI Panel
    public Button restartButton; // Assign a Button inside the winUI

    private Transform player;
    private bool hasWon = false;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

        if (winUI != null)
            winUI.SetActive(false);

        if (restartButton != null)
            restartButton.onClick.AddListener(RestartLevel);
    }

    void Update()
    {
        if (hasWon || player == null) return;

        // Manual distance calculation
        float dx = player.position.x - transform.position.x;
        float dy = player.position.y - transform.position.y;
        float dist = Mathf.Sqrt(dx * dx + dy * dy);

        if (dist < triggerDistance)
        {
            ShowWinUI();
        }
    }

    void ShowWinUI()
    {
        hasWon = true;
        if (winUI != null)
            winUI.SetActive(true);

        Time.timeScale = 0f; // Freeze game
    }

    public void RestartLevel()
    {
        Time.timeScale = 1f; // Resume time before restart
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
