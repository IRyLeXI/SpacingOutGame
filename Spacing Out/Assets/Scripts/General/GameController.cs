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
    private OverlayController overlay;

    [SerializeField]
    private bool isScoreVisible = true;

    private float deathTime;

    private bool isDead = false;

    public int playerScore = 0;

    

    // Start is called before the first frame update
    void Start()
    {
        RespawnPlayer();
        overlay = GetComponent<OverlayController>();
        if(!isScoreVisible)
            overlay.DisableScore();
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
        PlayerController player = Instantiate(playerTemplate);
        player.gameController = this;
        player.transform.position = playerSpawnPoint.position;
        isDead = false;
        EnemyScript.SetPlayer();
        GoliathAimWeaponController.SetPlayer();
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
    }

    public void HandleScore(int Value)
    {
        playerScore+=Value;
        if(overlay!=null && isScoreVisible)
            overlay.UpdateScore(playerScore);
    }
}
