using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class IntroVideo : MonoBehaviour
{
    public VideoPlayer player;
    private bool finished = false;
    // Start is called before the first frame update
    void Awake()
    {
        player.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (Convert.ToInt32(player.frameCount) == Convert.ToInt32(player.frame) + 1 && !finished)
        {
            finished = true;
            FindObjectOfType<ScenesManager>().FadeToLevel("World");
        }
    }
}
