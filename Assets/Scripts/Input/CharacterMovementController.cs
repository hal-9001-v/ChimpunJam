using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovementController : MonoBehaviour
{
    private CharaterInputComponent _charInput;
    private Vector2 _moveDelta;
    private Vector2 _smoothedInput;

    [Header("Physics Settings")]
    [Header("Movement")]
    [SerializeField] float walkingVelocity;
    [SerializeField] float smoothInputSpeed;
    [SerializeField] float rotationSpeed;

    [Header("References")]

    [SerializeField] Rigidbody movementRigidbody;

    private void Awake()
    {
        _charInput = GetComponent<CharaterInputComponent>();

    }

    private void Update()
    {
        //Debug.Log(_charInput.GetMovementVector());
        _moveDelta = Vector2.SmoothDamp(_moveDelta, _charInput.GetMovementVector(), ref _smoothedInput, smoothInputSpeed);
        Vector3 moveVector = _moveDelta * walkingVelocity * Time.deltaTime;
        movementRigidbody.velocity = new Vector3(moveVector.x, movementRigidbody.velocity.y, moveVector.y);
        if (_charInput.GetMovementVector() != Vector2.zero){
            Vector3 movDir = movementRigidbody.velocity.normalized;
            Quaternion rot = Quaternion.LookRotation(movDir, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, rot, rotationSpeed * Time.deltaTime);

        }
    }

}

