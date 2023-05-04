using UnityEngine;

public class ArmorBuffScript : PlayerBuffController
{

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
            player.shield.IncreaseDurability();
            Destroy(this.gameObject);
        }
    }
}
