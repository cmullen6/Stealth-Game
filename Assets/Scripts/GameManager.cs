using UnityEngine;
using UnityEngine.SceneManagement;
//ADD THIS ONCE TO EACH SCENE!!!

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("Timer")]
    [SerializeField] private float maxTime = 120f;
    private float timer;

    [Header("Pickups")]
    [SerializeField] private int requiredPickups = 3;
    private int currentPickups = 0;

    [Header("Game State")]
    private bool gameOver;

    // ===== PUBLIC READ =====
    public float Timer => timer;
    public int CurrentPickups => currentPickups;
    public int RequiredPickups => requiredPickups;
    public bool HasMetRequirement => currentPickups >= requiredPickups;
    public bool IsGameOver => gameOver;

    void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    void Start()
    {
        ResetLevel();
    }

    void Update()
    {
        if (gameOver) return;

        timer -= Time.deltaTime;

        if (timer <= 0f)
        {
            TriggerGameOver();
        }
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        ResetLevel();
        Time.timeScale = 1f;
    }

    void ResetLevel()
    {
        timer = maxTime;
        currentPickups = 0;
        gameOver = false;
    }

    public void AddPickup(int amount)
    {
        currentPickups += amount;
    }

    public void TriggerGameOver()
    {
        gameOver = true;
        Time.timeScale = 0f;
    }

    public void RestartLevel()
    {
        Time.timeScale = 1f;
        Scene current = SceneManager.GetActiveScene();
        SceneManager.LoadScene(current.name);
    }

    public void LoadScene(string sceneName)
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(sceneName);
    }
}