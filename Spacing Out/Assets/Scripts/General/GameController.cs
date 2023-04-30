using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{

    [SerializeField]
    private PlayerController PlayerTemplate;

    [SerializeField]
    private Transform PlayerSpawnPoint;

    [SerializeField]
    private float RespawnTime = 1;

    private float DeathTime;

    private bool IsDead = false;

    // Start is called before the first frame update
    void Start()
    {
        RespawnPlayer();
    }

    // Update is called once per frame
    void Update()
    {
        if(IsDead && IsReadyForRespawn())
        {
            RespawnPlayer();
        }
    }

    private void RespawnPlayer()
    {
        Debug.Log("Respawning!");
        PlayerController player = Instantiate(PlayerTemplate);
        player.GameController = this;
        player.transform.position = PlayerSpawnPoint.position;
        IsDead = false;
        EnemyScript.SetPlayer();
        GoliathAimWeaponController.SetPlayer();
    }

    private bool IsReadyForRespawn()
    {
        return Time.time >= (DeathTime + RespawnTime);
    }

    public void DestroyShuttle(PlayerController Player)
    {
        Destroy(Player.gameObject);
        DeathTime = Time.time;
        IsDead=true;
    }

}
