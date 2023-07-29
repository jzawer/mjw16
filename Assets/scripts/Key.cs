using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Key : MonoBehaviour
{
    public Sprite ActiveImage;
    public Sprite InactiveImage;
    public bool Active;

    public void SetActive(bool active)
    {
        var imageComponent = GetComponent<Image>();
        if (imageComponent is not null)
        {
            Active = active;
            imageComponent.sprite = Active ? ActiveImage : InactiveImage;
        }
    }
}
