using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[ExecuteInEditMode]

public class CameraControl : MonoBehaviour
{
    public Transform _target;
    public Vector3 _distanceToTarget;
    public Vector3 _lookAtOffset;
    [Range(0f, 1f)] public float _lookAtTargetModifier;
    public float _movementSpeed;
    public float _rotationSpeed;

#if UNITY_EDITOR
    public bool _executeInEditMode = false;
#endif

    private void Start()
    {
        _target= GameObject.FindObjectOfType<PlayerControl>().transform;
    }
    private void LateUpdate()
    {

#if  UNITY_EDITOR
        if (!UnityEditor.EditorApplication.isPlaying && !_executeInEditMode) return;
#endif

        if (!_target) return;
        Vector3 targetPosition = _target.position;
        Vector3 cameraPosition = targetPosition + new Vector3(0f, _distanceToTarget.y, 0f);
        Vector3 focusPointOffset = new Vector3(0f, _lookAtOffset.y, 0f);

        Vector3 targetForward = _target.forward;
        targetForward.y = 0;
        targetForward.Normalize();

        cameraPosition += targetForward * _distanceToTarget.z;
        focusPointOffset += targetForward * _lookAtOffset.z;
        if (_distanceToTarget.x != 0f || _lookAtOffset.x != 0f)
        {
            Vector3 targetRight = _target.right;
            targetRight.y = 0;
            targetRight.Normalize();

            cameraPosition += targetRight * _distanceToTarget.x;
            focusPointOffset += targetRight * _lookAtOffset.x;
        }

        Vector3 newPosition = Vector3.Lerp(transform.position, cameraPosition, Time.deltaTime * _movementSpeed);
        transform.position = newPosition;

        Quaternion cameraRotation;
        if (_lookAtTargetModifier <= 0f)
        {
            cameraRotation = Quaternion.LookRotation(targetForward);
        }
        else
        {
            Vector3 lookAtDirection = targetPosition + focusPointOffset - newPosition;
            if (_lookAtTargetModifier >= 1f)
            {
                cameraRotation = Quaternion.LookRotation(lookAtDirection);
            }
            else
            {
                cameraRotation = Quaternion.LerpUnclamped(Quaternion.LookRotation(targetForward), Quaternion.LookRotation(lookAtDirection), _lookAtTargetModifier);
            }
        }

        transform.rotation = Quaternion.Lerp(transform.rotation, cameraRotation, Time.deltaTime * _rotationSpeed);

#if UNITY_EDITOR
        if (!UnityEditor.EditorApplication.isPlaying && _executeInEditMode)
        {
            transform.position = cameraPosition;
            transform.rotation = cameraRotation;
        }
#endif
    }
}
