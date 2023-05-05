using UnityEngine;
using TMPro;

[RequireComponent(typeof(TextMeshProUGUI))]
public class WaveTextController : MonoBehaviour
{
    public void ShowWaveNum(int wave)
    {
        gameObject.SetActive(true);
        GetComponent<TextMeshProUGUI>().text = $"Wave {wave}";     
        Invoke(nameof(HideOverlay), 3);
    }

    public void HideOverlay() => gameObject.SetActive(false);
}
