using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameState : MonoBehaviour
{
    [SerializeField] private Transform thiscanvas;
    public GameObject enemy;
    public UIstate currentState;
    public Camera firstPersonCamera;
    public Camera overheadCamera;
    public bool overhead = false, cooldown = false; 
    public float powerchance, timelimit, duration;
    public Image sign;
    public TextMeshProUGUI counter;

    // Call this function to disable FPS camera,
    // and enable overhead camera.
    IEnumerator ShowOverheadView() {
        firstPersonCamera.enabled = false;
        // overheadCamera.enabled = true;
        counter.text = powerchance.ToString();
        cooldown = true;
        yield return new WaitForSecondsRealtime(timelimit);
        cooldown = false;
        overhead = false;
        sign.fillAmount = 1;
        sign.color = Color.white;
        ShowFirstPersonView();
    }
    
    // Call this function to enable FPS camera,
    // and disable overhead camera.
    public void ShowFirstPersonView() {
        firstPersonCamera.enabled = true;
        // overheadCamera.enabled = false;
    }
    private void Update() {
        if (Input.GetKey(KeyCode.Space) && !overhead && powerchance > 0)
        {
            overhead = true;
            powerchance--;
            sign.color = Color.green;
            StartCoroutine(ShowOverheadView());
        }
        if (cooldown)
        {
            //Reduce fill amount over 30 seconds
            sign.fillAmount -= 1.0f / timelimit * Time.deltaTime;
        }
    }
    public enum UIstate
    {
        NONE,
        GAMEPLAY,
        PAUSE,
        GAMEOVER,
        GAMEWIN,
    }

    public void InitState(string state)
    {
        switch (state)
        {
            case ("GAMEPLAY"):
                currentState = UIstate.GAMEPLAY;
                break;
            case ("PAUSE"):
                currentState = UIstate.PAUSE;
                break;
            case ("GAMEOVER"):
                currentState = UIstate.GAMEOVER;
                break;
            case ("GAMEWIN"):
                currentState = UIstate.GAMEWIN;
                break;
            default:
                currentState = UIstate.NONE;
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
    public void PauseGame()
    {
        InitState("PAUSE");
    }

    public void ChangeScene(string sceneName)
    {
        MainManager.Instance.ChangeScene(sceneName);
    }
    private void Awake() {
        InitState("GAMEPLAY");
        StartCoroutine(RandomSound(Random.Range(3.0F, 5.0F)));
        ShowFirstPersonView();
        StartCoroutine(SpawnOject(duration));
    }
    IEnumerator RandomSound(float time)
    {
        yield return new WaitForSecondsRealtime(time);
        SoundManager.Instance.PlaySFX(Random.Range(0,5));
        StartCoroutine(RandomSound(Random.Range(10.0F, 15.0F)));
    }
    IEnumerator SpawnOject(float duration)
    {
        GameObject newObject = Instantiate(enemy);
        yield return new WaitForSecondsRealtime(duration);
        StartCoroutine(SpawnOject(duration));
    }
}