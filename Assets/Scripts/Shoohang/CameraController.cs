using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Camera _camera;
    
    private GameObject _target;
    private Rigidbody _targetRigidbody;
    
    private float _smoothTime = 0.75f;

    private void Start()
    {
        _target = GameManager.Instance.player;
        _targetRigidbody = _target.GetComponent<Rigidbody>();

        _camera = GetComponentInChildren<Camera>();
    }

    private void FixedUpdate()
    {
        CameraEffect();
    }
    
    private void CameraEffect()
    {
        //카메라 고정 원점의 좌표를 항공기 좌표값 + 속도 * ∆fixedUpdateT
        transform.position = transform.position + _targetRigidbody.velocity * Time.fixedDeltaTime;
        //쿼터니언 구형 보간을 이용해 카메라 고정 원점을 기준으로 한 좌표계를 항공기 회전값만큼 부드럽게 회전변환
        transform.rotation = Quaternion.Slerp(_target.transform.rotation, transform.rotation, _smoothTime);

        //속력에 따른 시야 확장 효과 (속력에 비례하여 증가)
        _camera.fieldOfView = Mathf.Clamp(60 + (_targetRigidbody.velocity.magnitude * 0.25f), 60, 100);
    }
}
