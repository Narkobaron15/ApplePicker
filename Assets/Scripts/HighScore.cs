using TMPro;
using UnityEngine;

public class HighScore : MonoBehaviour
{
    private static int _score = 1000;

    public static int Score
    {
        get => _score;
        set
        {
            _score = value;
            if (Score > PlayerPrefs.GetInt("HighScore")) WriteHighScore();
        }
    }

    private TextMeshProUGUI _gt;

    private void Start()
    {
        _gt = GetComponent<TextMeshProUGUI>();
        Debug.Log(_gt is null);
    }

    private void Awake()
    {
        if (PlayerPrefs.HasKey("HighScore"))
            Score = PlayerPrefs.GetInt("HighScore");
        WriteHighScore();
    }

    private void Update()
    {
        _gt.text = "High Score: " + Score;
    }
    
    private static void WriteHighScore()
    {
        PlayerPrefs.SetInt("HighScore", Score);
    }
}