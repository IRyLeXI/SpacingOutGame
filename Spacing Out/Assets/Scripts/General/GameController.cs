using UnityEngine;

public class GameController : MonoBehaviour
{

    [SerializeField]
    private PlayerController playerTemplate;

    [SerializeField]
    private Transform playerSpawnPoint;

    [SerializeField]
    private float respawnTime = 1;

    private float deathTime;

    private bool isDead = false;

    // Start is called before the first frame update
    void Start()
    {
        RespawnPlayer();
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

}
