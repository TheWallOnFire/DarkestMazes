using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Blinking : MonoBehaviour
{
    [SerializeField] private SpriteRenderer sprite;
    public float blinktime;
    public Color color1, color2;
    // public Color RandomColor()
    // {
    //     switch(Random.Range(0, 6)) {
    //         case 0:
    //             return Color.red;
    //         case 1:
    //             return Color.blue;
    //         case 2:
    //             return Color.green;
    //         case 3:
    //             return Color(1.0,0.5,0.0);//orange
    //         case 4:
    //             return Color.yellow;
    //         case 5:
    //             return Color(0.8,0.0,0.8);//purple
    //         default:
    //                 // Throw an exception maybe...
    //     }
    // }
    private void Awake() {
        BlinkAnim(blinktime);
    }
    void BlinkAnim(float duration)
    {
        StartCoroutine(Blink(duration));
        // BlinkAnim(duration);
    } 
    IEnumerator Blink(float duration)
    {
        sprite.color = color1;
        yield return new WaitForSeconds(duration);
        sprite.color = color2;
        yield return new WaitForSeconds(duration);
        StartCoroutine(Blink(duration));
    }
}
