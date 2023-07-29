using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    [SerializeField]
    private GameObject _credits;

    public void OnStartClick()
    {
        FindObjectOfType<ScenesManager>().FadeToLevel("World");
    }

    public void OnCreditsClick()
    {
        _credits.SetActive(!_credits.activeSelf);
    }
}
