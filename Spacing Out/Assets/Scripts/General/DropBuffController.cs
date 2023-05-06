using System.Collections.Generic;
using UnityEngine;

public class DropBuffController : MonoBehaviour
{
    [SerializeField]
    private int dropChance = 15;

    [SerializeField]
    private List<PlayerBuffController> buffs;

    private PlayerBuffController buff;


    private bool isBuffDrop => Random.Range(1,101) <= dropChance;

    public void DropBuff() {
        if(isBuffDrop)
        {
            //Debug.Log("I am droping");
            buff = Instantiate(buffs[Random.Range(0, buffs.Count)]);
            buff.transform.position = this.gameObject.transform.position;
        }
    }
}
