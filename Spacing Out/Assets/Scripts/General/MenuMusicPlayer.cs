using UnityEngine;

public class MenuMusicPlayer : MonoBehaviour
{
    public MusicController soundController; 
    void Start()
    {
        soundController.MenuMusic();
    }


}
