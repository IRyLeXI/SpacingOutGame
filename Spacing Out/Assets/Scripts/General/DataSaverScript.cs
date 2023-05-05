using UnityEngine;

public class DataSaverScript : MonoBehaviour
{
    public static int AbilityNumber = 1;

    public static float MusicVolume = 1f;

    public static float EffectsVolume = 1f;

    public void SetAbility(int num)
    {
        Debug.Log(num);
        AbilityNumber = num;
    }

    public void SetMusicVolume(float value)
    {
        MusicVolume = value;
    }

    public void SetEffectsVolume(float value)
    {
        EffectsVolume = value;
    }

}
