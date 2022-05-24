using System;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [Header("References")]
    [SerializeField] FollowObject[] _followers;

    Queue<InventoryItem> _itemQueue;

    [Header("Settings")]
    [SerializeField] [Range(0.1f, 2)] float _cooldownTime;

    float _elapsedCooldown;
    bool _readyToUseItem;

    private void Awake()
    {
        _itemQueue = new();
    }

    [ContextMenu("Use Item")]
    public void UseItem()
    {
        if (_readyToUseItem)
        {
            var firstItem = _itemQueue.Dequeue();

            firstItem.UseItem();

            _itemQueue.Enqueue(firstItem);

            AssignFollowersToItems();

            _readyToUseItem = false;
            _elapsedCooldown = 0;
        }
    }


    public void AddItem(InventoryItem newItem)
    {
        if (_itemQueue.Count >= _followers.Length)
        {
            var oldItem = _itemQueue.Dequeue();
            oldItem.gameObject.SetActive(false);

            Destroy(oldItem);
        }

        _itemQueue.Enqueue(newItem);
        AssignFollowersToItems();
    }

    void AssignFollowersToItems()
    {
        var queueArray = _itemQueue.ToArray();
        for (int i = 0; i < queueArray.Length - 1; i++)
        {
            queueArray[i].SetFollower(_followers[i], false);
        }
        queueArray[queueArray.Length - 1].SetFollower(_followers[queueArray.Length - 1], true);

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
