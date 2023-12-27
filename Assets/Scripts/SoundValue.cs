using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SoundValue : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI musictext;
    [SerializeField] private Slider slidermusic;
    [SerializeField] private TextMeshProUGUI soundtext;
    [SerializeField] private Slider slidersound;
    // Start is called before the first frame update
    void OnEnable()
    {
        slidermusic.value = SoundManager.Instance.MusicAudioSources[0].volume*100;
        slidersound.value = SoundManager.Instance.SoundAudioSources[0].volume*100;
        // if (this.name == "MUSIC")
        // {
        //     this.Slider.value = SoundManager.Instance.MusicAudioSources[0].volume;
        // }
        // else if (this.name == "SOUND")
        // {
        //     this.Slider.value = SoundManager.Instance.SoundAudioSources[0].volume;
        // }
    }
    public void ShowMusic (float value)
    {
        musictext.text = (value).ToString() + "%";
        SoundManager.Instance.SetMusicVol(value);
    }
    public void ShowSound (float value)
    {
        soundtext.text = (value).ToString() + "%";
        SoundManager.Instance.SetSoundVol(value);
    }
}
