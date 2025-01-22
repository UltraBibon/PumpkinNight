using UnityEngine;


public class Bullet : MonoBehaviour
{
    [SerializeField] public float _damage;
    [SerializeField] private CatAnimator _catanimator;

    private void Awake()
    {
        _catanimator = new CatAnimator();
        _catanimator = GameObject.Find("GamblerCat").GetComponent<CatAnimator>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Monster")) { 
        EnemyBurrow enemy = collision.gameObject.GetComponent<EnemyBurrow>();

            if (enemy != null)
            {
                enemy.TakeDamage(_damage);
                Destroy(gameObject, 0.7f);
            }
        }
        if (collision.gameObject.CompareTag("Cat"))
        {  
            _catanimator.PlayDead(); 
        }

        if(collision.gameObject.CompareTag("Ghost"))
        {
            EnemyGhost enemy = collision.gameObject.GetComponent<EnemyGhost>(); 
            if (enemy != null) 
            {
                enemy.TakeDamage(_damage);
            }
        }
        if (collision.gameObject.CompareTag("Bat")) { 
        EnemyBat enemy = collision.gameObject.GetComponent<EnemyBat>();

            if (enemy != null)
            {
                enemy.TakeDamage(_damage);
                Destroy(gameObject, 0.7f);
            }
        }
        Destroy(gameObject, 0.7f);
    }
    
}
