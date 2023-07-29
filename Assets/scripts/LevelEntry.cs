using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelEntry : MonoBehaviour
{
    [SerializeField]
    public string levelName;

    private void OnCollisionEnter(Collision collision)
    {
        FindObjectOfType<ScenesManager>().FadeToLevel(levelName);
    }
}
