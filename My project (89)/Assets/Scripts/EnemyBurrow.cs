using UnityEngine;

public class EnemyBurrow : MonoBehaviour
{
    private int points = 20;
    public static float HP_BURROW = 100;
    [SerializeField] public ParticleSystem _deathEffect;

    private Score scor;
    private Player _player;
private ScorePerenos score1;

    public void TakeDamage(float damage) 
    { 
        HP_BURROW -= damage;
        if (HP_BURROW < 0 ) 
        {
            ParticleSystem death = Instantiate( _deathEffect, gameObject.transform.position, gameObject.transform.rotation);
            Destroy(death, 3f);
            Destroy(death.gameObject, 3f);
            Destroy(gameObject);
            scor = GameObject.Find("Canvas").GetComponent<Score>();
            score1 = GameObject.Find("scoreperenos").GetComponent<ScorePerenos>();
            score1.AddScore(points);
            HP_BURROW = 100;
            Debug.Log(scor);
            scor.AddScore(points);
        }

    }

    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            BigBoom();
            _player = GameObject.Find("Main Camera").GetComponent<Player>();
            _player.Death();
        }
    }

    private void BigBoom()
    {
        ParticleSystem kamikadze = Instantiate(_deathEffect, gameObject.transform.position, gameObject.transform.rotation);
        Destroy(kamikadze, 3f);
        Destroy(kamikadze.gameObject, 3f);
        Destroy(gameObject);
    }


}
