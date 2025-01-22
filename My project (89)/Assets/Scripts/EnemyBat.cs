using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBat : MonoBehaviour
{
    private int points = 5;
    public static float HP_BAT = 20;
    private ScorePerenos score1;
    private Score scor;
    [SerializeField] ParticleSystem deathEffect;


    public void TakeDamage(float damage)
    {
        HP_BAT -= damage;
        if (HP_BAT < 0)
        {
            ParticleSystem death = Instantiate(deathEffect, gameObject.transform.position, gameObject.transform.rotation);
            Destroy(death, 4f);
            Destroy(death.gameObject, 4f);
            Destroy(gameObject);
            scor = GameObject.Find("Canvas").GetComponent<Score>();
            score1 = GameObject.Find("scoreperenos").GetComponent<ScorePerenos>();
            score1.AddScore(points);
            HP_BAT = 20;
            Debug.Log(scor);
            scor.AddScore(points);
        }

    }
}