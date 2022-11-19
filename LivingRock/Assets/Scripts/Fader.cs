using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Fader : MonoBehaviour
{
    [SerializeField] private Image image;
    
    public IEnumerator FadeInCo(float time)
    {
        image.color = Color.clear;
        while (image.color.a < 1)
        {
            Color imageColor = image.color;
            imageColor.a += Time.deltaTime / time;
            image.color = imageColor;
            yield return null;
        }
    }

    public IEnumerator FadeOutCo(float time)
    {
        Debug.Log("AAAA");
        while (image.color.a > 0)
        {
            Debug.Log(image.color.a);
            Debug.Log(Time.unscaledDeltaTime / time);
            Color imageColor = image.color;
            imageColor.a -= Time.unscaledDeltaTime / time;
            Debug.Log(imageColor.a);
            image.color = imageColor;
            Debug.Log(image.color.a);
            yield return null;
        }
    }
}