using System.Collections;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneManage : MonoBehaviour
{
    private const float fade_speed = 1f;

    public void AfterTrain()
    {
        StartCoroutine(Fade3());
    }

    public void DeathToMenu()
    {
        StartCoroutine(Fade5());
    }

    public void DeathToGraveyard()
    {
        StartCoroutine(Fade6());
    }

    IEnumerator Fade3()
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
        SceneManager.UnloadSceneAsync("Rezhim1");
    }

    IEnumerator Fade5()
    {
        Image fade_img = GetComponent<Image>();
        Color color = fade_img.color;
        while (color.a < 1f)
        {
            color.a += fade_speed * Time.deltaTime;
            fade_img.color = color;
            yield return new WaitForSeconds(0.01f);
        }
        SceneManager.LoadScene("Menu");
        SceneManager.UnloadSceneAsync("DeathScene");
    }

    IEnumerator Fade6()
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
        SceneManager.UnloadSceneAsync("DeathScene");
    }
}
