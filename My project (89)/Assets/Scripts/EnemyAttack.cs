
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] private float _attackRange;
    [SerializeField] private int _damage;

    [SerializeField] private float _cooldown;

    private float _timer;
    public bool CanAttack { get; private set; }

    private Player _player;

    public float AttackRange => _attackRange;

    private void Start()
    {
        _player = GameObject.Find("Main Camera").GetComponent<Player>();

    }

    private void Update()
    {
        UpdateCooldown();
    }
    private void UpdateCooldown()
    {
        if (CanAttack)
        {
            return;
        }
        _timer += Time.deltaTime;

        if (_timer < _cooldown)
        {
            return;
        }

        CanAttack = true;
        _timer = 0;
    }

    public void TryAttackPlayer()
    {
        _player.TakeDamage(_damage);

        CanAttack = false;
    }

}
