using UnityEngine;
using UnityEngine.Animations;
using TMPro;

public class UIScore : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _scoreUI;
    [SerializeField] private TextMeshProUGUI _highScoreUI;
    [SerializeField] private TweenCore _newScoreAnimation;

    private const string _highScore = "HighScore";
    private int _score;

    private void Awake()
    {
        if (Application.isEditor)
            PlayerPrefs.DeleteKey(_highScore);
    }
    public void Add(int value) { _score += value; _scoreUI.SetText(_score.ToString()); }
    public void Remove(int value) { _score -= value; _scoreUI.SetText(_score.ToString()); }

    public void SaveNewScore()
    {
        int highScore = PlayerPrefs.GetInt(_highScore);

        if (_score > highScore)
        {
            highScore = _score;
            _newScoreAnimation.Play(true);
        }

        _highScoreUI.SetText(highScore.ToString());
        PlayerPrefs.SetInt(_highScore, highScore);
    }
}