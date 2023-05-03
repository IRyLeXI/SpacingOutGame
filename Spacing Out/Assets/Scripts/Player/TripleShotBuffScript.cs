using UnityEngine;

public class TripleShotBuffScript : MonoBehaviour
{

    [SerializeField]
    private float tripleShotDuration = 10f;

    [SerializeField]
    private float newShotSpeed = 0.2f;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            PlayerController player = other.GetComponent<PlayerController>();
            player.weaponsController.ActivateSideWeapons(newShotSpeed, tripleShotDuration);
            Destroy(this.gameObject);
       }
    }
}
