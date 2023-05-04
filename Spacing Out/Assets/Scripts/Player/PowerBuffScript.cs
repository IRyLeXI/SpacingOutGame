using UnityEngine;

public class PowerBuffScript : PlayerBuffController
{

    [SerializeField]
    private float damage = 3f;

    [SerializeField]
    private float buffDuration = 10f;

    protected override void Start()
    {
        base.Start();
    }

    protected override void Update()
    {
        base.Update();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            PlayerController player = other.GetComponent<PlayerController>();
            player.weaponsController.BuffBullets(damage, buffDuration);
            Destroy(this.gameObject);
       }
    }
}
