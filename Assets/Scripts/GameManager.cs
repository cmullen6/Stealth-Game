using UnityEngine;
using UnityEngine.SceneManagement;
//ADD THIS ONCE TO EACH SCENE!!!

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("Timer")]
    [SerializeField] private float maxTime = 120f;
    private float timer;

    [Header("Score")]
    [SerializeField] private int score;

    [Header("Player Reference")]
    [SerializeField] private Transform player;

    [Header("Checkpoint")]
    private Transform currentCheckpoint;

    [Header("Game State")]
    private bool gameOver;

    // ===== PUBLIC READ-ONLY ACCESS =====
    public float Timer => timer;
    public float MaxTime => maxTime;
    public int Score => score;
    public bool IsGameOver => gameOver;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        timer = maxTime;
    }

    private void Update()
    {
        if (gameOver) return;

        timer -= Time.deltaTime;

        if (timer <= 0f)
        {
            TriggerGameOver();
        }
    }

    // ===== WIN GAME =====
    public void WinGame()
    {
        gameOver = true;
        Time.timeScale = 0f;

        // Optional: load a win scene
        // SceneManager.LoadScene("WinScene");

        Debug.Log("You Win!");
    }

    // ===== SCORE =====
    public void AddScore(int amount)
    {
        score += amount;
    }

    // ===== TIMER =====
    public void AddTime(float amount)
    {
        timer = Mathf.Clamp(timer + amount, 0, maxTime);
    }

    // ===== CHECKPOINT =====
    public void SetCheckpoint(Transform checkpoint)
    {
        currentCheckpoint = checkpoint;
    }

    public void RespawnPlayer()
    {
        if (player == null || currentCheckpoint == null) return;

        player.position = currentCheckpoint.position;
        timer = maxTime;
        gameOver = false;
    }

    // ===== GAME FLOW =====
    public void TriggerGameOver()
    {
        gameOver = true;
        Time.timeScale = 0f;
    }

    public void ReloadFromCheckpoint()
    {
        Time.timeScale = 1f;
        RespawnPlayer();
    }

    // ===== UI BUTTON METHODS =====
    public void StartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("GameScene");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void ReturnToMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }
}

