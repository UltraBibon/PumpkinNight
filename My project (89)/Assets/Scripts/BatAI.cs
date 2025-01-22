using UnityEngine;
using Pathfinding;
using Random = UnityEngine.Random;


public class BatAI : MonoBehaviour
{
    [SerializeField] private float _minWalkableDistance;
    [SerializeField] private float _maxWalkableDistance;
    [SerializeField] private float _reachedPointDistance;
    [SerializeField] private GameObject _roamTarget;
    [SerializeField] private float _targetFollowRange;
    [SerializeField] private float _stopTargetFollowingRange;
    [SerializeField] private AIDestinationSetter _aiDestinationSetter;
    private Player _player;
    private EnemyStates1 _currentState;
    private Vector3 _roamPosition;
    public Vector3 offset;
    public Transform playerpos;

    private void Awake()
    {
        offset = new Vector3(0,0, 15);
    }

    private void Start()
    {
        _player = FindObjectOfType<Player>();
        _currentState = EnemyStates1.Roaming;
        _roamPosition = GenerateRoamPosition();
    }

    // Update is called once per frame
    private void Update()
    {
        _player.transform.position += offset;
        _roamTarget.transform.position += offset;
        switch (_currentState)
        {
            case EnemyStates1.Roaming:
                if (Vector3.Distance(gameObject.transform.position, _roamPosition) <= _reachedPointDistance)
                {
                    _roamPosition = GenerateRoamPosition();
                }
                _aiDestinationSetter.target = _roamTarget.transform;
                TryFindPlayer();
                break;

            case EnemyStates1.Following:
                _aiDestinationSetter.target = _player.transform;

                if (Vector3.Distance(gameObject.transform.position, _player.transform.position) >= _stopTargetFollowingRange)
                {
                    _currentState = EnemyStates1.Roaming;
                }
                break;
        }

    }

    private void TryFindPlayer()
    {
        if (Vector3.Distance(gameObject.transform.position, _player.transform.position) <= _targetFollowRange)
        {
            _currentState = EnemyStates1.Following;
        }
    }
    private Vector3 GenerateRoamPosition()
    {
        var roamPosition = gameObject.transform.position + GenerateRandomDirection() * GenerateRandomWalkableDistance();
        return roamPosition;
    }
    private Vector3 GenerateRandomDirection()
    {
        var newDirection = new Vector3(Random.Range(-1f, 1f), 0f, Random.Range(-1f, 1f));
        return newDirection.normalized;

    }
    private float GenerateRandomWalkableDistance()
    {
        var randomDistance = Random.Range(_minWalkableDistance, _maxWalkableDistance);
        return randomDistance;
    }
}

public enum EnemyStates1
{
    Roaming,
    Following
}

