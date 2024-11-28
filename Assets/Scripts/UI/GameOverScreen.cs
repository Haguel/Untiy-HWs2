using TMPro;
using UnityEngine;

public class GameOverScreen : MonoBehaviour
{
    [SerializeField] private Spawner _spawner;
    [SerializeField] private CanvasGroup _canvasGroup;
    [SerializeField] private TMP_Text _gameOverText;
    [SerializeField] private TMP_Text _waveInfoText;

    private void OnEnable()
    {
        _spawner.OnAllWavesFinished += OnAllWavesFinished;
    }

    private void OnDisable()
    {
        _spawner.OnAllWavesFinished -= OnAllWavesFinished;
    }

    private void OnAllWavesFinished()
    {
        _canvasGroup.alpha = 1f;
        _canvasGroup.interactable = true;
        _gameOverText.text = "You WIN!";
        _waveInfoText.gameObject.SetActive(false);
    }
}