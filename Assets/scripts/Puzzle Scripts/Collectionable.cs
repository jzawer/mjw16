using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectionable : MonoBehaviour
{
    public int value;

    private PlayerInventory _inventory;

    // Start is called before the first frame update
    void Awake()
    {
        _inventory = PlayerInventory.GetInstances();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            _inventory.ActiveKey(value, true);
            gameObject.SetActive(false);
            FindObjectOfType<ScenesManager>().FadeToLevel("World");
            FindObjectOfType<AudioManager>().Play("finish");
        }
    }
}
