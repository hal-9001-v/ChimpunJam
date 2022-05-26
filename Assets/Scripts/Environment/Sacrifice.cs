using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AreaHolder))]
public class Sacrifice : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] SacrificeType _sacrificeType;

    [SerializeField] Health _playerHealth;

    [SerializeField] float _moreHealth = 2;

    enum SacrificeType
    {
        Health,
        Weapon
    }

    Inventory _inventory => FindObjectOfType<Inventory>();
    AreaHolder _areaHolder => GetComponent<AreaHolder>();
    SwordController _swordController => FindObjectOfType<SwordController>();

    private void Awake()
    {
        if (_sacrificeType == SacrificeType.Weapon)
        {
            _areaHolder.successEvent.AddListener(GiveCombinedEffects);
        }
        else
        {
            _areaHolder.successEvent.AddListener(GiveHealth);
        }
    }

    void GiveHealth()
    {
        if (_inventory.itemQueue.Count != 0)
        {
            _inventory.RemoveItem(0);

            _playerHealth.currentHealth += _moreHealth;
        }
    }
    void GiveCombinedEffects()
    {
        if (_inventory.itemQueue.Count >= 3)
        {
            var combinedItems = new ItemEffect[3];
            for (int i = 0; i < 3; i++)
            {
                combinedItems[i] = _inventory.RemoveItem(0).effect;
            }

            _swordController.AddEffects(combinedItems);
        }
    }
}
