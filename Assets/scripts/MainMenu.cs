using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    [SerializeField]
    private GameObject _credits;
    [SerializeField]
    private CanvasGroup canvas;

    public void OnStartClick()
    {
        canvas.alpha = 0;
        FindObjectOfType<ScenesManager>().FadeToLevel("IntroTrailer");
        FindObjectOfType<AudioManager>().Play("button");
    }

    public void OnCreditsClick()
    {
        _credits.SetActive(!_credits.activeSelf);
        FindObjectOfType<AudioManager>().Play("button");
    }
}
