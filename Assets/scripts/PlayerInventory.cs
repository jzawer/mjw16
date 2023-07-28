using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory
{
    public List<GameObject> inventory { get; set; }

    public PlayerInventory()
    {
        inventory = new List<GameObject>();
    }

    private static PlayerInventory _playerInventory;
    public static PlayerInventory GetInstances()
    {
        if (_playerInventory is null)
            _playerInventory = new PlayerInventory();

        return _playerInventory;
    }
}
