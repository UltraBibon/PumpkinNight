using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.CompilerServices;
using UnityEngine;

public class EnemyGhost : MonoBehaviour
{
    private float HP_GHOST = 1;
    private int points = 10;
    private Score scor;
    private ScorePerenos score1;
    private float _speed;
    private GameObject g;
    private Renderer gr;
    private float transparency;
    private Quaternion offset;

    [SerializeField] ParticleSystem deathEffect;

    private void Awake()
    {
        scor = GameObject.Find("Canvas").GetComponent<Score>();
        //g=gameObject.GetComponent<GameObject>();
        //gr = gameObject.GetComponent<Renderer>();
    }

    public void TakeDamage(float _damage)
    {
        HP_GHOST -= _damage;
        if (HP_GHOST < 0 ) 
        {
            offset = Quaternion.Euler(gameObject.transform.rotation.x - 90, gameObject.transform.rotation.y, gameObject.transform.rotation.z);
            ParticleSystem death = Instantiate(deathEffect, gameObject.transform.position, offset);
            Destroy(death, 4f);
            Destroy(death.gameObject, 4f);
            score1 = GameObject.Find("scoreperenos").GetComponent<ScorePerenos>();
            score1.AddScore(points);
            HP_GHOST = 1;
            scor.AddScore(points);
            Destroy(gameObject);
        }
    }

    /*

    IEnumerator DeathForGhost()
    {
        

        while (gr.material.color.a < 1f)
        {
            gr.material.color.a = 1f; 
            transparency += _speed * Time.deltaTime;
            gr.material.color.a += transparency;
            yield return new WaitForSeconds(0.01f);
        }

        yield return new WaitForSeconds(1.5f);
    }
    */


}
