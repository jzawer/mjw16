using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private PlayerInventory _inventory;
    // Start is called before the first frame update
    void Start()
    {
        _inventory = PlayerInventory.GetInstances();
    }

    // Update is called once per frame
    void Update()
    {
        if (_inventory.isGameCompleted)
        {
            FindObjectOfType<ScenesManager>().FadeToLevel("EndGame");
        }
    }
}
