using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class CharaterInputComponent : MonoBehaviour
{

    private CharacterMovement _characterControls;
    private Vector2 _movementInputVector;
    private Vector2 _swordInputVector;

    private Inventory _inventory => FindObjectOfType<Inventory>();
    private SwordController _swordController => FindObjectOfType<SwordController>();

    [SerializeField] Health _playerHealth;

    private void OnEnable()
    {
        _characterControls.CharacterControllerActionMap.Enable();

    }

    private void OnDisable()
    {
        _characterControls.CharacterControllerActionMap.Disable();
    }

    private void Awake()
    {
        _characterControls = new CharacterMovement();
        InitializeControls();

        _playerHealth.deadAction += (v, f, p) =>
        {
            _characterControls.CharacterControllerActionMap.Disable();
        };
    }

    private void InitializeControls()
    {
        _characterControls.CharacterControllerActionMap.Move.performed += ctx => _movementInputVector = ctx.ReadValue<Vector2>();
        _characterControls.CharacterControllerActionMap.Sword2DVec.performed += ctx => _swordInputVector = ctx.ReadValue<Vector2>();

        _characterControls.CharacterControllerActionMap.Move.canceled += ctx =>
        {
            _movementInputVector = Vector2.zero;
        };

        _characterControls.CharacterControllerActionMap.Ability.performed += ctx =>
        {
            FollowerAbility();
        };

        _characterControls.CharacterControllerActionMap.DuckAbility.performed += ctx =>
        {
            DuckAbility();
        };

        _characterControls.CharacterControllerActionMap.UseSword.performed += ctx =>
        {
            _swordController.EnableSword(true);
        };

        _characterControls.CharacterControllerActionMap.UseSword.canceled += ctx =>
        {
            _swordController.EnableSword(false);
        };
    }

    private void DuckAbility()
    {
        _inventory.UseItem();

    }

    private void FollowerAbility()
    {
        Debug.Log("Follower Pium");
    }



    public Vector2 GetMovementVector() { return _movementInputVector; }
    public Vector2 GetMouseInputVector() { return _swordInputVector; }


}
