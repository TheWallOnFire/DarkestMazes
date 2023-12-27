using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainManager : MonoBehaviour
{
    public static MainManager Instance;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public Difficulty difficulty;
    public enum Difficulty
    {
        NONE,
        EASY,
        MEDIUM,
        HARD,
    }
    public void SelectDiff(string diff)
    {
        switch (diff)
        {
            case ("EASY"):
                difficulty = Difficulty.EASY;
                break;
            case ("MEDIUM"):
                difficulty = Difficulty.MEDIUM;
                break;
            case ("HARD"):
                difficulty = Difficulty.HARD;
                break;
            default:
                difficulty = Difficulty.NONE;
                break;
        }
    }
    public void ChangeScene(string sceneName)
    {
        switch(sceneName)
        {
            case ("GAME"):
                SceneManager.LoadScene("GameScene");
                break;
            case ("HOME"):
                SceneManager.LoadScene("StartScene");
                break;
            default:
                break;
        }
    }
}
