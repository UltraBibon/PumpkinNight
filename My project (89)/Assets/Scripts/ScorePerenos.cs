using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class ScorePerenos : MonoBehaviour
{
    
    public int score =0;
    
   [SerializeField] private TextMeshProUGUI obj;
    

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    public void AddScore(int scr)
    {
        score+=scr;
    }

    public int GetScore()
    {
        return score;
    }

    public void ResetScore() 
    {
        score = 0;
    }

}
