using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameUIState : MonoBehaviour
{
    [SerializeField]
    private GameObject keysContainer;
    [SerializeField]
    private Key[] Keys;

    private PlayerInventory _playerInventory;

    public void Start()
    {
        _playerInventory = PlayerInventory.GetInstances();
        InitKeysUI();
    }

    private void InitKeysUI()
    {
        foreach (var key in Keys)
        {
            var keyInstance = Instantiate(key, Vector3.zero, Quaternion.identity, keysContainer.transform);
            _playerInventory.Inventory.Add(keyInstance);
        }
    }
}
