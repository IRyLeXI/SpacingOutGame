using UnityEngine;

public class PlayerTeleportAbility : WeaponScript
{
    private bool isSpawned = false;

    private BulletScript tpBullet;

    private SoundController sc;

    void Start()
    {
        lastShot = Time.time - fireRate;
        sc = FindObjectOfType<SoundController>();

    }

    void Update()
    {
        if(IsReadyForFire() && !isSpawned)
        {
            HandleFire();
        }
        else if(isSpawned)
        {
            sc.TeleportSound();
            HandleTeleport();
        }
    }

    protected override void HandleFire()
    {
        if(Input.GetButtonDown("Special"))
        {
            GameObject bullet = Instantiate(Bullet.gameObject);
            tpBullet = bullet.GetComponent<BulletScript>();
            tpBullet.pushForce = bulletPushForce;
            tpBullet.pushDirection = bulletDirection;
            bullet.transform.position = gameObject.transform.position;
            isSpawned = true;
        }
    }

    private void HandleTeleport()
    {
        if(Input.GetButtonDown("Special"))
        {
            GameObject player1 = GameObject.FindGameObjectWithTag("Player");
            player1.transform.position = tpBullet.gameObject.transform.position;
            isSpawned = false;
            Destroy(tpBullet.gameObject);
            lastShot = Time.time;
        }
    }

    private void OnDestroy() {
        if(isSpawned)
            Destroy(tpBullet.gameObject);
    }
}
