using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovementController : MonoBehaviour
{
    private CharaterInputComponent _charInput;
    private Vector2 _moveDelta;
    private Vector2 _smoothedInput;

    private float _dashElapsedTime;
    private bool _isDashing;

    [Header("Physics Settings")]
    [Header("Movement")]
    [SerializeField] float walkingVelocity;
    [SerializeField] float smoothInputSpeed;
    [SerializeField] float rotationSpeed;

    [SerializeField] [Range(10, 30)] float _dashVelocity;
    [SerializeField] [Range(0.1f, 1)] float _dashDuration;

    [Header("References")]

    [SerializeField] Rigidbody movementRigidbody;


    private void Awake()
    {
        _charInput = GetComponent<CharaterInputComponent>();

    }

    private void FixedUpdate()
    {
        Vector2 moveDirection = _charInput.GetMovementVector();
        if (moveDirection != Vector2.zero)
        {
            //Damp movement & Generate Movement Vector
            _moveDelta = Vector2.SmoothDamp(_moveDelta, moveDirection, ref _smoothedInput, smoothInputSpeed);
            _moveDelta.Normalize();

            Vector2 targetVelocity = _moveDelta * walkingVelocity;
            Vector3 fixedVelocity = new Vector3(targetVelocity.x, 0, targetVelocity.y) - movementRigidbody.velocity;

            //Move rb
            movementRigidbody.AddForce(fixedVelocity, ForceMode.VelocityChange);

            Vector3 movDir = movementRigidbody.velocity.normalized;
            Quaternion rot = Quaternion.LookRotation(movDir, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, rot, rotationSpeed * Time.deltaTime);
        }
        else
        {
            Vector3 fixedVelocity = -0.25f * movementRigidbody.velocity;

            movementRigidbody.AddForce(fixedVelocity, ForceMode.VelocityChange);
        }

        if (_isDashing)
        {
            Vector2 targetVelocity = _moveDelta * _dashVelocity;

            _dashElapsedTime += Time.deltaTime;
            if (_dashElapsedTime >= _dashDuration)
            {
                _isDashing = false;
            }

            Vector3 fixedVelocity = new Vector3(targetVelocity.x, 0, targetVelocity.y) - movementRigidbody.velocity;
            movementRigidbody.AddForce(fixedVelocity, ForceMode.VelocityChange);
        }

    }

    public void Dash(float duration, float speed)
    {
        _dashDuration = duration;
        _dashVelocity = speed;

        _isDashing = true;
        _dashElapsedTime = 0;

    }

}

