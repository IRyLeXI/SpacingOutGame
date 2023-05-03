using UnityEngine;

public class ArmorBuffScript : MonoBehaviour
{
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
