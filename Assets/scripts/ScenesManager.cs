using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class ScenesManager : MonoBehaviour
{
    public static ScenesManager Instance;

    public CanvasGroup canvasGroup;
    public float FadeDuration = 2f;

    void Awake()
    {
        if (Instance != null)
            Destroy(gameObject);
        else
            Instance = this;

        DontDestroyOnLoad(gameObject);
    }

    public void FadeToLevel(string levelName)
    {
        canvasGroup.DOFade(1f, FadeDuration / 2).OnComplete(() =>
        {
            canvasGroup.DOFade(0f, FadeDuration / 2);
            SceneManager.LoadScene(levelName);
        });
    }
}
