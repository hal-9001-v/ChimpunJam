using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class CharaterInputComponent : MonoBehaviour
{
    private CharacterMovement _characterControls;
    private Vector2 _movementInputVector;
    private Vector2 _swordInputVector;


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
    }

    private void InitializeControls()
    {
        _characterControls.CharacterControllerActionMap.Move.performed += ctx => _movementInputVector = ctx.ReadValue<Vector2>();
        _characterControls.CharacterControllerActionMap.Sword2DVec.performed += ctx => _swordInputVector = ctx.ReadValue<Vector2>();

        _characterControls.CharacterControllerActionMap.Move.canceled += ctx =>
        {
            _movementInputVector = Vector2.zero;
        };

        _characterControls.CharacterControllerActionMap.Ability.performed += ctx =>{
            FollowerAbility();
        };

        _characterControls.CharacterControllerActionMap.DuckAbility.performed += ctx => {
            DuckAbility();
        };
    }

    private void DuckAbility(){
        CameraShaker.Instance.ShakeCam(5f, 5f, .3f);
        Debug.Log("Duck Pium");
    }

    private void FollowerAbility(){
        Debug.Log("Follower Pium");
    }


    public Vector2 GetMovementVector(){ return _movementInputVector;}
    public Vector2 GetMouseInputVector(){ return _swordInputVector;}


}
