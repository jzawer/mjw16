using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class TextController : MonoBehaviour
{
    [SerializeField]
    private GameObject textContainer;

    private static TextController Instance;

    private Text Message;

    void Awake()
    {
        if (Instance != null)
            Destroy(gameObject);
        else
            Instance = this;

        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        Message = textContainer.GetComponent<Text>();
        SetText("Hola como estamos todos, probando probando");
    }


    public void SetText(string textInput)
    {
        Message.DOText(textInput, 10);
    }
}
