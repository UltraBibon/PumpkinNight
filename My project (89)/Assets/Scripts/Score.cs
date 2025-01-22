using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;
using UnityEngine.UI;
using TMPro;
public class Score : MonoBehaviour
{

    /*
    [SerializeField] public float _duration;
    [SerializeField] public string _title;
    [SerializeField] public string _subtitle;
    [SerializeField] public Camera _camera;
    [SerializeField] public Canvas _canvas;
    [SerializeField] public float _maxAngleDistance;

    public bool allignWithPlayer = false;

    private void LateUpdate()
    {
        Move();
        RotateX();
        RotateY();
    }

    private void Move()
    {
        float targetYRotation = _camera.transform.eulerAngles.y;
        float currentYRotation = _canvas.transform.eulerAngles.y;
        float distance = Mathf.Abs(currentYRotation - targetYRotation);

        if (distance> _maxAngleDistance)
        {
            allignWithPlayer=true;
        }
    }
    */

    [SerializeField] public TextMeshProUGUI _text;
    public int _score;
    public Transform target;
    private float smooth = 5.0f;


    [SerializeField] public GameObject spawnerForBurrows1;
    [SerializeField] public GameObject spawnerForBurrows2;
    [SerializeField] public GameObject spawnerForBurrows3;
    private EnemySpawner burrowspawner;
    [SerializeField] public GameObject spawnerForGhosts2;
    [SerializeField] public GameObject spawnerForGhosts3;
    private EnemySpawner ghostspawner;
    [SerializeField] public GameObject spawnerForBats1;
    [SerializeField] public GameObject spawnerForBats2;
    [SerializeField] public GameObject spawnerForBats3;
    private EnemySpawner batspawner;
    [SerializeField] public TextMeshProUGUI _textforendgame;

    public void AddScore(int points)
    {
        _score += points;
        _text.text = _score.ToString();
    }

    public void Update()
    {
        if (_score > 100) 
        { 
            spawnerForBurrows1.SetActive(true);
        }
        if (_score > 300)
        {
            spawnerForBats1.SetActive(true);
        }
        if (_score >500)
        {
           spawnerForBurrows2.SetActive(true);
        }
        if (_score > 700) 
        { 
            spawnerForGhosts2.SetActive(true);
            spawnerForBats2.SetActive(true);
        }
        if(_score >1000)
        {
            spawnerForGhosts3.SetActive(true); 
            spawnerForBats3.SetActive(true); 
            spawnerForBurrows3.SetActive(true);
        }

        //burrowspawner = spawnerForBurrows1.GetComponent<EnemySpawner>();
        //burrowspawner._spawnInterval -= 2;

    }


    private void FixedUpdate() 
    { 
        Vector3 offset = new Vector3(0,1,0);
        transform.position = Vector3.Lerp(transform.position, offset+target.position, Time.deltaTime*smooth);
    }

    public void GetScore()
    { _textforendgame.text = _score.ToString(); }
}
