using UnityEngine;
using UnityEngine.UI;
using System.Collections;
 
public class ThunderEffect : MonoBehaviour {
     
    public Image img;
    void OnEnable()
    {
        StartCoroutine(FadeImage(true));
    }
 
    IEnumerator FadeImage(bool fadeAway)
    {
        yield return new WaitForSecondsRealtime(5);
        SoundManager.Instance.PlaySFX(1);
        // fade from opaque to transparent
        if (fadeAway)
        {
            // loop over 1 second backwards
            for (float i = 1; i >= 0; i -= Time.deltaTime)
            {
                // set color with i as alpha
                img.color = new Color(1, 1, 1, i);
                yield return null;
            }
        }
        // fade from transparent to opaque
        else
        {
            // loop over 1 second
            for (float i = 0; i <= 1; i += Time.deltaTime)
            {
                // set color with i as alpha
                img.color = new Color(1, 1, 1, i);
                yield return null;
            }
        }
        StartCoroutine(FadeImage(fadeAway));
    }
}
 