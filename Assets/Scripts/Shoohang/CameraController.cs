using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform aimPosition;
    [SerializeField] private RectTransform aimUI;
    
    private enum CameraType
    {
        ThirdPersonView = 0,
        FirstPersonView = 1,
    }

    private CameraType _cameraType = CameraType.ThirdPersonView;
        
    private Camera[] _cameras;
    private Camera _currentCamera;
    private int _currentCameraIndex = 0;

    private float _changeCameraDelay = 1f;
    
    private GameObject _target;
    private Rigidbody _targetRigidbody;

    private float _smoothTime = 0.75f;

    private float[] _shakeTime = {0.5f, 0.75f};
    private float[] _shakeSpeed = { 10f, 15f };
    private float[] _shakeAmount = { 10f, 20f };
    private float _currentChangeCameraDelay = 0f;

    private void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        
        _target = GameManager.Instance.player;
        _targetRigidbody = _target.GetComponent<Rigidbody>();

        transform.position = _target.transform.position;

        _cameras = GetComponentsInChildren<Camera>();
        _currentCameraIndex = 0;
        for (int i = 0; i < _cameras.Length; i++)
        {
            _cameras[i].gameObject.SetActive(i == _currentCameraIndex);
        }
        _currentCamera = _cameras[0];
    }

    private void Update()
    {
        _currentChangeCameraDelay += Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.V))
        {
            ChangeCameraType();
        }
    }

    private void FixedUpdate()
    {
        aimUI.position = _currentCamera.WorldToScreenPoint(aimPosition.position);

        switch (_cameraType)
        {
            case CameraType.ThirdPersonView :
                CameraEffectForThirdPersonView();
                break;
            
            case CameraType.FirstPersonView :
                CameraEffectForFirstPersonView();
                break;
        }
    }
    
    private void ChangeCameraType()
    {
        if (_currentChangeCameraDelay < _changeCameraDelay)
        {
            return;
        }
        _currentChangeCameraDelay = 0f;
        
        _currentCameraIndex = (_currentCameraIndex + 1) % _cameras.Length;

        _cameraType = (CameraType)_currentCameraIndex;

        _currentCamera = _cameras[_currentCameraIndex];
        
        for (int i = 0; i < _cameras.Length; i++)
        {
            _cameras[i].gameObject.SetActive(i == _currentCameraIndex);
        }
    }
    
    private void CameraEffectForThirdPersonView()
    {
        transform.position = _target.transform.position;
        
        transform.rotation = Quaternion.Slerp(_target.transform.rotation, transform.rotation, _smoothTime);
        
        _currentCamera.fieldOfView = Mathf.Clamp(30 + (_targetRigidbody.velocity.magnitude * 0.25f), 40, 80);
    }

    private void CameraEffectForFirstPersonView()
    {
        transform.position = _target.transform.position;
        
        transform.rotation = _target.transform.rotation;
        
        _currentCamera.fieldOfView = Mathf.Clamp(15 + (_targetRigidbody.velocity.magnitude * 0.25f), 40, 80);
    }

    public void ShakeCamera()
    {
        _currentChangeCameraDelay = -2f;
        StartCoroutine(Shake());
    }
    
    IEnumerator Shake()
    {
        Vector3 originPosition = transform.localPosition;
        float elapsedTime = 0.0f;
 
        while (elapsedTime < _shakeTime[_currentCameraIndex])
        {
            Vector3 randomPoint = originPosition + Random.insideUnitSphere * _shakeAmount[_currentCameraIndex];
            transform.localPosition = Vector3.Lerp(transform.localPosition, randomPoint, Time.deltaTime * _shakeSpeed[_currentCameraIndex]);
 
            yield return null;
 
            elapsedTime += Time.deltaTime;
        }

        transform.position = originPosition;
    }
}
