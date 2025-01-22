using TMPro;
using UnityEngine;

public class ScoreHelper : MonoBehaviour
{
    private ScorePerenos _scorePerenos;
    private int scr;
    private TextMeshProUGUI _text;

    private void Start()
    {
        _scorePerenos = GameObject.Find("scoreperenos").GetComponent<ScorePerenos>();
        scr = _scorePerenos.GetScore();
        _text = gameObject.GetComponent<TextMeshProUGUI>();
        _text.text = scr.ToString();
    }

}
