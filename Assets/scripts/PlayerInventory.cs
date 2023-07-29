using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public List<Key> Inventory { get; set; }

    public PlayerInventory()
    {
        Inventory = new List<Key>();
    }

    private static PlayerInventory _playerInventory;

    public static PlayerInventory GetInstances()
    {
        if (_playerInventory is null)
            _playerInventory = new PlayerInventory();

        return _playerInventory;
    }

    public void ActiveKey(int index, bool active)
    {
        try
        {
            Inventory[index].SetActive(active);
        }
        catch (Exception ex)
        {
            Debug.Log(ex.Message);
        }
    }
}
