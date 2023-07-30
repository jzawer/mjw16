using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public List<Key> Inventory { get; set; }
    public bool isGameCompleted { get; set; }

    public PlayerInventory()
    {
        Inventory = new List<Key>();
        for (var i = 0; i <3; i++)
        {
            Inventory.Add(new Key());
        }
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
            Inventory[index].Active = active;
            UpdateCompletedState();
        }
        catch (Exception ex)
        {
            Debug.Log(ex.Message);
        }
    }

    private void UpdateCompletedState()
    {
        var completed = true;

        foreach (var key in Inventory)
        {
            if (!key.Active)
                completed = false;
        }

        isGameCompleted = completed;
    }
}
