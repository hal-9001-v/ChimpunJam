using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [Header("References")]
    [SerializeField] FollowObject[] _followers;
    [SerializeField] InventoryItem[] _items;

    Queue<InventoryItem> _itemQueue;

    [Header("Settings")]
    [SerializeField] [Range(0.1f, 2)] float _cooldownTime;

    float _elapsedCooldown;
    bool _readyToUseItem;

    private void Awake()
    {
        _itemQueue = new Queue<InventoryItem>();

        for (int i = 0; i < _items.Length; i++)
        {
            _itemQueue.Enqueue(_items[i]);
        }

        for (int i = 0; i < _items.Length; i++)
        {
            _items[i].SetFollower(_followers[i], false);
        }
    }


    [ContextMenu("Use Item")]
    public void UseItem()
    {
        if (_readyToUseItem)
        {
            var firstItem = _itemQueue.Dequeue();

            //firstItem.use();

            _itemQueue.Enqueue(firstItem);

            var queueArray = _itemQueue.ToArray();
            for (int i = 0; i < _followers.Length - 1; i++)
            {
                queueArray[i].SetFollower(_followers[i], false);
            }
            queueArray[_followers.Length - 1].SetFollower(_followers[_followers.Length - 1], true);
            _readyToUseItem = false;
            _elapsedCooldown = 0;
        }
    }


    private void Update()
    {
        UpdateUseTime();
    }

    void UpdateUseTime()
    {
        if (_readyToUseItem == false)
        {
            _elapsedCooldown += Time.deltaTime;

            if (_elapsedCooldown > _cooldownTime)
            {
                _readyToUseItem = true;
            }

        }
    }

}
