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
    private ScoreOverlayController scoreOverlay;

    [SerializeField]
    private LivesOverlayController livesOverlay;

    [SerializeField]
    private bool isScoreVisible = true, isLivesVisible = true;

    [SerializeField]
    private int shuttleLives = 3;

    private float deathTime;

    private bool isDead = false;

    public int playerScore = 0;

    

    // Start is called before the first frame update
    void Start()
    {
        RespawnPlayer();
        scoreOverlay = GetComponent<ScoreOverlayController>();
        livesOverlay = GetComponent<LivesOverlayController>();
        if(!isScoreVisible)
            scoreOverlay.DisableScore();
        if(!isLivesVisible) 
            livesOverlay.DisableLives();
        else
            livesOverlay.SetLives(shuttleLives);
    }

    // Update is called once per frame
    void Update()
    {
        if(isDead && IsReadyForRespawn())
        {
            RespawnPlayer();
        }
    }

    private void RespawnPlayer()
    {
        if(shuttleLives > 0 || !isLivesVisible)
        {
            PlayerController player = Instantiate(playerTemplate);
            player.gameController = this;
            player.transform.position = playerSpawnPoint.position;
            isDead = false;
            EnemyScript.SetPlayer();
            GoliathAimWeaponController.SetPlayer();
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
        shuttleLives--;
        if(livesOverlay != null && isLivesVisible)
            livesOverlay.ReduceLives(shuttleLives);
    }

    public void HandleScore(int Value)
    {
        playerScore+=Value;
        if(scoreOverlay!=null && isScoreVisible)
            scoreOverlay.UpdateScore(playerScore);
    }
}
