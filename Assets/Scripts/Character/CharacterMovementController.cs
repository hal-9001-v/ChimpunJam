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
    [SerializeField] private float walkingVelocity;
    [SerializeField] private float rotationSpeed;

    [SerializeField][Range(10, 30)] private float dashVelocity;
    [SerializeField][Range(0.1f, 1)] private float dashDuration;
    [SerializeField][Range(0f, 1f)] private float friction;

    [Header("References")]

    [SerializeField] private Rigidbody movementRigidbody;


    private void Awake()
    {
        _charInput = GetComponent<CharaterInputComponent>();
    }

    private void FixedUpdate()
    {
        var moveDirection = _charInput.GetMovementVector();
        var targetVelocity = moveDirection.normalized * walkingVelocity;
        var fixedVelocity = new Vector3(targetVelocity.x, 0f, targetVelocity.y) - movementRigidbody.velocity;
        if (moveDirection != Vector2.zero)
        {
            fixedVelocity.y = 0f;
            //Move rb
            movementRigidbody.AddForce(fixedVelocity, ForceMode.VelocityChange);

            var movDir = movementRigidbody.velocity.normalized;
            var rot = Quaternion.LookRotation(movDir, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, rot, rotationSpeed * Time.deltaTime);
        }
        else
        {
            fixedVelocity = -friction * movementRigidbody.velocity;
            fixedVelocity.y = 0f;
            movementRigidbody.AddForce(fixedVelocity, ForceMode.VelocityChange);
        }

        if (!_isDashing) return;
        //esto igual lo he roto lo arreglamos luego
        targetVelocity = moveDirection.normalized * dashVelocity;

        _dashElapsedTime += Time.deltaTime;
        if (_dashElapsedTime >= dashDuration)
        {
            _isDashing = false;
        }

        fixedVelocity = new Vector3(targetVelocity.x, 0f, targetVelocity.y) - movementRigidbody.velocity;
        fixedVelocity.y = 0f;
        movementRigidbody.AddForce(fixedVelocity, ForceMode.VelocityChange);

    }

    public void Dash(float duration, float speed)
    {
        dashDuration = duration;
        dashVelocity = speed;

        _isDashing = true;
        _dashElapsedTime = 0;

    }

    public Vector2 GetVelocity()
    {
        var velocity = movementRigidbody.velocity;
        return new Vector2(velocity.x, velocity.z);
    }

}

