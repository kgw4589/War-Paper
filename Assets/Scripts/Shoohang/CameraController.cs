using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform aimPosition;
    [SerializeField] private RectTransform aimUI;
    
    private Camera _camera;
    
    private GameObject _target;
    private Rigidbody _targetRigidbody;

    private float _smoothTime = 0.75f;

    private void Start()
    {
        _target = GameManager.Instance.player;
        _targetRigidbody = _target.GetComponent<Rigidbody>();

        transform.position = _target.transform.position;
        
        _camera = Camera.main;
        
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void FixedUpdate()
    {
        CameraEffect();

        aimUI.position = _camera.WorldToScreenPoint(aimPosition.position);
    }
    
    private void CameraEffect()
    {
        transform.position = _target.transform.position;
        
        transform.rotation = Quaternion.Slerp(_target.transform.rotation, transform.rotation, _smoothTime);
        
        _camera.fieldOfView = Mathf.Clamp(15 + (_targetRigidbody.velocity.magnitude * 0.25f), 40, 80);
    }
}
