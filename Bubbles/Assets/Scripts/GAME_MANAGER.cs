using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GAME_MANAGER : MonoBehaviour
{
    public static GAME_MANAGER instance;

    private void Awake()
    {
        instance = this;
    }

    private int _score;
    [SerializeField] private TextMeshProUGUI _scoreAmount;

    [SerializeField] private GameObject _losePanel;

    [SerializeField] private float _gameTime;
    private float _countdowner;
    [SerializeField] private Slider _slider;

    private void Start()
    {
        SetStartScore();

        _countdowner = _gameTime;

        SetSlider(_gameTime, _gameTime);
    }

    private void Update()
    {
        _countdowner -= Time.deltaTime;
        SetSlider(_countdowner);

        if (_countdowner <= 0f)
            GameOver();
    }

    public void GameOver()
    {
        Time.timeScale = 0f;
        _losePanel.SetActive(true);
    }

    public int GetScore()
    {
        return _score;
    }

    public int GetBestScore()
    {
        return PlayerPrefs.GetInt("BestScore", 0);
    }

    public void SetBestScore(int amount)
    {
        PlayerPrefs.SetInt("BestScore", amount);
    }

    private void SetStartScore()
    {
        _score = 0;
        _scoreAmount.text = _score.ToString();
    }

    public void AddScore(int amount)
    {
        _score += amount;
        _scoreAmount.text = _score.ToString();
    }

    public void ChangeCountdowner(float amount)
    {
        _countdowner -= amount;
    }

    private void SetSlider(float value)
    {
        _slider.value = value;
    }

    private void SetSlider(float maxValue, float value)
    {
        _slider.maxValue = maxValue;
        _slider.value = value;
    }
}
