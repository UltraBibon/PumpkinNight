using System.Collections;

using UnityEngine;

public class CatDialogue : MonoBehaviour
{
    public GameObject[] images;
    public float displayTime = 3f;

    private void Start()
    {
        HideAllImages();
    }

    public void Interact()
    {
        StartCoroutine(DisplayRandomImage());
    }

    private IEnumerator DisplayRandomImage()
    {
        HideAllImages();

        int randomIndex = Random.Range(0, images.Length);
        images[randomIndex].SetActive(true);

        yield return new WaitForSeconds(displayTime);

        images[randomIndex].SetActive(false);
    }

    private void HideAllImages()
    {
        foreach (GameObject image in images)
        {
            image.SetActive(false);
        }
    }
}
