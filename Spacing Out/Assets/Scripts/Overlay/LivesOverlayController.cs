using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LivesOverlayController : MonoBehaviour
{

    [SerializeField]
    private Image livesImage;

    [SerializeField]
    private RectTransform Container;

    private List<Image> lives = new List<Image>();


    public void SetLives(int amount)
    {
        for(int i=0; i<amount; i++)
        {
            Image image = Instantiate<Image>(livesImage, Container);
            lives.Add(image);
            if(i>4) 
                image.gameObject.SetActive(false);
        }
    }

    public void ReduceLives(int num)
    {
        lives[num].gameObject.SetActive(false);
    }


    public void EnableLives()
    {
        Container.gameObject.SetActive(true);
    }
}
