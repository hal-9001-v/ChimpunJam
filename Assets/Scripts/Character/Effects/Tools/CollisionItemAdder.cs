using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CollisionInteractable))]
public class CollisionItemAdder : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] Vector3 _itemOffset;

    CollisionInteractable _interactable => GetComponent<CollisionInteractable>();
    Inventory _inventory => FindObjectOfType<Inventory>();
    
    EffectPrototypeProvider _effectProvider => FindObjectOfType<EffectPrototypeProvider>();

    InventoryItem _item;

    private void Awake()
    {
        _interactable.enterEvent.AddListener(AddItem);

        _item = _effectProvider.GetRandomItem();

        _item.transform.position = transform.position + _itemOffset;
        _item.transform.parent = transform;
    }

    void AddItem()
    {
        if (_inventory && _item)
        {
            _inventory.AddItem(_item);
        }
    }

}

