using UnityEngine;
using UnityEngine.Animations;

public class PauseController : MonoBehaviour
{
    [SerializeField] private TweenCanvasGroup _pauseScreen;

    public void Pause()
    {
        Time.timeScale = 0f;
        _pauseScreen.FadeIn();
    }
    public void UnPause()
    {
        Time.timeScale = 1f;
        _pauseScreen.FadeOut();
    }
}