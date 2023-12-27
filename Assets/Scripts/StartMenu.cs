using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartMenu : MonoBehaviour
{
    [SerializeField] private Transform thiscanvas;
    [SerializeField] private GameObject Intro;
    public GameState currentState;
    public enum GameState
    {
        NONE,
        MENU,
        DIFFICULTY,
        SETTING,
        CREDIT,
        GAMEPLAY,
        HELP,
    }
    public void InitState(string state)
    {
        switch (state)
        {
            case ("MENU"):
                currentState = GameState.MENU;
                break;
            case ("DIFFICULTY"):
                currentState = GameState.DIFFICULTY;
                break;
            case ("SETTING"):
                currentState = GameState.SETTING;
                break;
            case ("CREDIT"):
                currentState = GameState.CREDIT;
                break;
            case ("HELP"):
                currentState = GameState.HELP;
                break;
            default:
                currentState = GameState.NONE;
                break;
        }
        SetCurrentState(thiscanvas, state);
    }

    public void SetCurrentState(Transform transform, string state)
    {
        foreach (Transform child in transform)
        {
            if (child.gameObject.name == state)
            {
                child.gameObject.SetActive(true);
            }
            else
            {
                child.gameObject.SetActive(false);
            }
        }
    }
    public void ExitGame()
    {
        Application.Quit();
    }
    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start()
    {
        InitState("MENU");
        // SoundManager.Instance.PlayMusic(0);
        // SoundManager.Instance.PlayMusic(1);
    }

    // private void Update() 
    // {
    //     if (Input.anyKey)
    //     {
    //         InitState("start");
    //     }
    // }

    public void PlayMode(string mode)
    {
        // MainManager.Instance.SelectDiff(mode);
        MainManager.Instance.ChangeScene("GAME");
    }

    public void MusicVol(float volume)
    {
        SoundManager.Instance.SetMusicVol(volume);
    }
    public void SoundVol(float volume)
    {
        SoundManager.Instance.SetSoundVol(volume);
    }
}
