using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class Player : MonoBehaviour
{

    private GameObject _player;
private ScorePerenos perenos;

    [SerializeField] private int _health;

    public void TakeDamage(int damage)
    {
        if (_health - damage <= 0)
        {
            Death();
        }
        _health -= damage;
        Debug.Log(_health);
    }

    public void Death()
    {
        SceneManager.LoadScene("DeathScene");
        SceneManager.UnloadSceneAsync("05 Graveyard");
        //StartCoroutine(Fade4());
    }
    /* IEnumerator Fade4()
     {
         Image fade_img = GetComponent<Image>();
         Color color = fade_img.color;
         color.a = 1f;
         yield return new WaitForSeconds(1.5f);
         SceneManager.LoadScene("DeathScene");
         SceneManager.UnloadSceneAsync("05 Graveyard");
     }
     */

}
