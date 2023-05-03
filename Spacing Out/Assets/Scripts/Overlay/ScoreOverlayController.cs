using UnityEngine;
using TMPro;

public class ScoreOverlayController : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI Score;
    

    public void UpdateScore(int score)
    {
        Score.text = score.ToString().PadLeft(8, '0');
    }

    public void DisableScore()
    {
        Score.gameObject.SetActive(false);
    }

}
