using UnityEngine;

public class GameController : MonoBehaviour
{

    [SerializeField]
    private PlayerController playerTemplate;

    [SerializeField]
    private Transform playerSpawnPoint;

    [SerializeField]
    private float respawnTime = 1;
    
    [SerializeField]
    private int shuttleLives = 3;
    
    [SerializeField]
    private bool isScoreVisible = true, isLivesVisible = true, isWavesHandle = true;

    [SerializeField]
    private WaveController gameMode;

    [SerializeField]
    private GameObject gameOverScreenController;

    private int shuttleLivesBackup;

    private ScoreOverlayController scoreOverlay;

    private LivesOverlayController livesOverlay;

    private SoundController sc;

    private float deathTime;

    private bool isDead = false;

    private int playerScore = 0; 

    void Start()
    {
        StartGame();
        sc = FindObjectOfType<SoundController>();
        sc.PlayGameMusic();
    }

    void Update()
    {
        if(isDead && IsReadyForRespawn())
        {
            RespawnPlayer();
        }
    }

    private void RespawnPlayer()
    {
        if(shuttleLivesBackup > 0 || !isLivesVisible)
        {
            PlayerController player = Instantiate(playerTemplate);
            player.gameController = this;
            player.transform.position = playerSpawnPoint.position;
            isDead = false;
            EnemyScript.SetPlayer(player);
            GoliathAimWeaponController.SetPlayer(player);
        }
    }

    private bool IsReadyForRespawn()
    {
        return Time.time >= (deathTime + respawnTime);
    }

    public void DestroyShuttle(PlayerController Player)
    {
        Destroy(Player.gameObject);
        deathTime = Time.time;
        isDead=true;
        shuttleLivesBackup--;
        if(livesOverlay != null && isLivesVisible)
        {
            livesOverlay.ReduceLives(shuttleLivesBackup);
        }
        if(shuttleLivesBackup <= 0 && isLivesVisible)
        {
            gameOverScreenController.SetActive(true);
            DestroyAll();
        }
    }

    private void DestroyAll()
    {
        var objects = FindObjectsOfType<GameObject>();
        foreach(GameObject obj in objects)
        {
            if(obj.CompareTag("GameController") || obj.CompareTag("SmallMeteorite") || obj.CompareTag("BigMeteorite") || obj.CompareTag("MainCamera"))
            {
                continue;
            }
            Destroy(obj.gameObject);
        }
    }

    public void HandleScore(int Value)
    {
        playerScore+=Value;
        if(scoreOverlay!=null && isScoreVisible)
            scoreOverlay.UpdateScore(playerScore);
    }

    private void StartGame()
    {
        scoreOverlay = GetComponent<ScoreOverlayController>();
        livesOverlay = GetComponent<LivesOverlayController>();

        shuttleLivesBackup = shuttleLives;
        RespawnPlayer();

        if(isScoreVisible)
        {
            playerScore = 0;
            scoreOverlay.EnableScore();
            scoreOverlay.UpdateScore(playerScore);

        }

        if(isLivesVisible) 
        {
            livesOverlay.EnableLives();       
            livesOverlay.SetLives(shuttleLivesBackup);
        }

        if(isWavesHandle)
        {
            Instantiate<WaveController>(gameMode);
        }

    }

    public void TryAgain()
    {
        gameOverScreenController.SetActive(false);
        StartGame();
    }

}
