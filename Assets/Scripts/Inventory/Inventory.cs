using System;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [Header("References")]
    [SerializeField] FollowObject[] _followers;


    public Queue<InventoryItem> itemQueue;

    [Header("Settings")]
    [SerializeField] [Range(0.1f, 2)] float _cooldownTime;
    float _elapsedCooldown;
    bool _readyToUseItem;

    private void Awake()
    {
        itemQueue = new();
    }

    [ContextMenu("Use Item")]
    public void UseItem()
    {
        if (_readyToUseItem && itemQueue.Count != 0)
        {
            var firstItem = itemQueue.Dequeue();

            firstItem.UseItem();

            itemQueue.Enqueue(firstItem);

            AssignFollowersToItems();

            _readyToUseItem = false;
            _elapsedCooldown = 0;
        }
    }

    public ItemEffect[] FlushEffects()
    {
        ItemEffect[] effects = new ItemEffect[itemQueue.Count];

        var queueArray = itemQueue.ToArray();
        for (int i = 0; i < effects.Length; i++)
        {
            effects[i] = queueArray[i].effect;
        }
        itemQueue.Clear();

        return effects;
    }

    public void AddItem(InventoryItem newItem)
    {
        if (itemQueue.Count >= _followers.Length)
        {
            var oldItem = itemQueue.Dequeue();
            oldItem.gameObject.SetActive(false);

            Destroy(oldItem);
        }

        itemQueue.Enqueue(newItem);
        AssignFollowersToItems();
    }

    public InventoryItem RemoveItem(int position)
    {
        if (position < 0 || position >= itemQueue.Count)
        {
            return null;
        }

        var itemArray = itemQueue.ToArray();
        itemQueue.Clear();
        for (int i = 0; i < itemArray.Length; i++)
        {
            if (i != position)
            {
                itemQueue.Enqueue(itemArray[i]);
            }
        }

        AssignFollowersToItems();

        return itemArray[position];
    }

    void AssignFollowersToItems()
    {
        var queueArray = itemQueue.ToArray();
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
