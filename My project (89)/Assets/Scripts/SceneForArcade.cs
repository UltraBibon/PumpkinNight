using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.UI;

public class SceneForArcade : MonoBehaviour
{
    private float fade_speed = 1f;

    private void Start()
    {
        StartCoroutine(Fade2());
    }

    IEnumerator Fade2()
    {
        Image fade_img = GetComponent<Image>();
        Color color = fade_img.color;
        while (color.a < 1f)
        {
            color.a += fade_speed * Time.deltaTime;
            fade_img.color = color;
            yield return new WaitForSeconds(0.01f);
        }
        SceneManager.LoadScene("05 Graveyard");
        SceneManager.UnloadSceneAsync("Menu");
    }
}
