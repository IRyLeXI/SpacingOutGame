using UnityEngine;

public class MenuMusicPlayer : MonoBehaviour
{
    public SoundController soundController; 
    void Start()
    {
        soundController.MenuMusic();
    }


}
