using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class Item : MonoBehaviour
{
    public enum ItemType
    {
        Attack = 0,
        Speed = 1,
        Ultimate = 2,
        BoosterFuel = 3
    }

    public ItemType _itemType;

    [SerializeField] private GameObject[] itemObjects;

    private PlayerController _playerController;

    private void Start()
    {
        _playerController = GameManager.Instance.player.GetComponent<PlayerController>();
    }

    private void OnEnable()
    {
        int randomValue = Random.Range(0, 100);

        switch (randomValue)
        {
            case < 30 :
                _itemType = ItemType.Attack;
                break;
            
            case < 60 :
                _itemType = ItemType.Speed;
                break;
            
            case < 70 :
                _itemType = ItemType.Ultimate;
                break;
            
            default :
                _itemType = ItemType.BoosterFuel;
                break;
        }

        Debug.Log(_itemType);
        itemObjects[(int)_itemType].SetActive(true);
    }

    private void OnDisable()
    {
        foreach (var item in itemObjects)
        {
            item.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            _playerController.GetItem(_itemType);
        }
        
        ObjectPoolManager.Instance.ReturnItem(gameObject);
    }
}
