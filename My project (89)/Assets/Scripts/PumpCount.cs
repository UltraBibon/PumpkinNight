using UnityEngine;
using TMPro;

public class PumpCount : MonoBehaviour
{

    [SerializeField] public TextMeshProUGUI _text;
    public int _pump;
    public Transform target;
    private float smooth = 5.0f;
    private SceneManage _scenemanager;

    public void AddPoint()
    {
        _pump += 1;
        _text.text = _pump.ToString();
        if (_pump == 10)
        {
            _scenemanager = GameObject.Find("SCENELOAD").GetComponent<SceneManage>();
            _scenemanager.AfterTrain();
        }
    }

    private void FixedUpdate()
    {
        Vector3 offset = new Vector3(0, 1, 0);
        transform.position = Vector3.Lerp(transform.position, offset + target.position, Time.deltaTime * smooth);
    }

}
