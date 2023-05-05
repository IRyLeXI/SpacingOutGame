using UnityEngine;

public class ShieldMeterController : MonoBehaviour
{
    public void ControlPlate(int plate)
    {
        if(plate<=0) return;
        if(transform.GetChild(plate - 1).gameObject.activeSelf)
            transform.GetChild(plate - 1).gameObject.SetActive(false);
        else    
            transform.GetChild(plate - 1).gameObject.SetActive(true);
    }
}
