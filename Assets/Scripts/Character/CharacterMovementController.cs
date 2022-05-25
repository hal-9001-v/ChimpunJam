using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovementController : MonoBehaviour
{
    private CharaterInputComponent _charInput;
    private float _dashElapsedTime;
    private bool _isDashing;

    [Header("Physics Settings")]
    [Header("Movement")]
    [SerializeField] float walkingVelocity;
    [SerializeField] float rotationSpeed;

    [SerializeField][Range(10, 30)] float dashVelocity;
    [SerializeField][Range(0.1f, 1)] float dashDuration;
    [SerializeField][Range(0f, 1f)] float friction;

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

            Vector2 targetVelocity = moveDirection.normalized * walkingVelocity;
            Vector3 fixedVelocity = new Vector3(targetVelocity.x, movementRigidbody.velocity.y, targetVelocity.y) - movementRigidbody.velocity;

            //Move rb
            movementRigidbody.AddForce(fixedVelocity, ForceMode.VelocityChange);


            Vector3 movDir = movementRigidbody.velocity.normalized;
            Quaternion rot = Quaternion.LookRotation(movDir, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, rot, rotationSpeed * Time.deltaTime);
        }
        else
        {
            Vector3 fixedVelocity = -friction * movementRigidbody.velocity;

            movementRigidbody.AddForce(fixedVelocity, ForceMode.VelocityChange);
        }

        if (_isDashing)
        {
            //esto igual lo he roto lo arreglamos luego
            Vector2 targetVelocity = moveDirection.normalized * dashVelocity;

            _dashElapsedTime += Time.deltaTime;
            if (_dashElapsedTime >= dashDuration)
            {
                _isDashing = false;
            }

            Vector3 fixedVelocity = new Vector3(targetVelocity.x, movementRigidbody.velocity.y, targetVelocity.y) - movementRigidbody.velocity;
            movementRigidbody.AddForce(fixedVelocity, ForceMode.VelocityChange);
        }

    }

    public void Dash(float duration, float speed)
    {
        dashDuration = duration;
        dashVelocity = speed;

        _isDashing = true;
        _dashElapsedTime = 0;

    }

}

