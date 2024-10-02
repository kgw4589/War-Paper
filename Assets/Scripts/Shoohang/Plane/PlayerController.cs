using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : BasicPlane
{
    [SerializeField] private Text speedText;
    [SerializeField] private Text ultimateText;
    [SerializeField] private Slider boosterSlider;
    
    [SerializeField] private Transform[] firePositions;

    [SerializeField] private AudioSource boosterAudioSource;

    private float _rotXAmount = 10.0f;
    private float _rotZAmount = 7.5f;

    private float _currentFireTime = 0.0f;
    private float _fireDelay = 0.25f;

    private int _attackLevel = 1;
    private int _speedLevel = 0;
    private float _speedUpValue;

    private bool _isReadyUltimate = true;

    private float _maxBoostGage = 100.0f;
    private float _currentBoostGage;
    private float _boosterFuelValue = 50.0f;
    private bool _isPlayingBoosterAudio = false;

    private float _defaultMoveSpeed;
    private float _boosterMaxMoveSpeed;
    private float _boosterValue = 2.0f;

    private void Start()
    {
        _currentFireTime = 0.0f;
        
        _currentBoostGage = _maxBoostGage;
        boosterSlider.value = _currentBoostGage / _maxBoostGage;
        
        _defaultMoveSpeed = moveSpeed;
        _boosterMaxMoveSpeed = _defaultMoveSpeed * _boosterValue;
        _speedUpValue = moveSpeed * 0.1f;
    }

    private void Update()
    {
        RotXValue = Input.GetAxis("Mouse Y") * _rotXAmount;
        RotZValue = Input.GetAxis("Mouse X") * _rotZAmount;
        
        SetUI();

        Booster();
        Fire();
        Ultimate();
    }

    private void SetUI()
    {
        speedText.text = $"{(int)moveSpeed} km/h";
        ultimateText.text = $"궁극기 {(_isReadyUltimate ? "준비됨" : "준비 중")}";
        
        boosterSlider.value = _currentBoostGage / _maxBoostGage;
    }

    private void Booster()
    {
        if ((_currentBoostGage > 0) && (moveSpeed < _boosterMaxMoveSpeed) && Input.GetButton("Boost"))
        {
            if (!_isPlayingBoosterAudio)
            {
                _isPlayingBoosterAudio = true;
                boosterAudioSource.Play();
            }
            moveSpeed = Mathf.Lerp(moveSpeed, _boosterMaxMoveSpeed, 2f * Time.deltaTime);
            _currentBoostGage -= (20.0f * Time.deltaTime);
            boosterAudioSource.volume += Time.deltaTime;
        }
        else if (moveSpeed > _defaultMoveSpeed)
        {
            _isPlayingBoosterAudio = false;
            moveSpeed = Mathf.Lerp(moveSpeed, _defaultMoveSpeed, 3f * Time.deltaTime);
            boosterAudioSource.volume -= Time.deltaTime;
        }
    }

    private void Fire()
    {
        _currentFireTime += Time.deltaTime;

        if (_currentFireTime < _fireDelay)
        {
            return;
        }
        
        if (Input.GetButton("Fire1"))
        {
            for (int i = 0; i < _attackLevel; i++)
            {
                GameObject bullet = ObjectPoolManager.Instance.GetBullet();

                bullet.transform.position = firePositions[i].position;
                bullet.transform.rotation = firePositions[i].rotation;
                
                bullet.SetActive(true);
            }

            _currentFireTime = 0;
        }
    }

    private void Ultimate()
    {
        if (_isReadyUltimate && Input.GetButtonDown("Fire2"))
        {
            UseUltimate();
        }
    }
    
    private void UseUltimate()
    {
        _isReadyUltimate = false;

        var damagables = FindObjectsOfType<MonoBehaviour>().OfType<IDamagable>();

        foreach (var damagable in damagables)
        {
            damagable.DamageAction();
        }
    }

    public void GetItem(Item.ItemType itemType)
    {
        switch (itemType)
        {
            case Item.ItemType.Attack :
                GetAttackItem();
                break;
            
            case Item.ItemType.Speed :
                GetSpeedItem();
                break;
            
            case Item.ItemType.Ultimate :
                GetUltimateItem();
                break;
            
            case Item.ItemType.BoosterFuel :
                GetBoosterFuel();
                break;
        }
    }

    private void GetAttackItem()
    {
        if (_attackLevel < 7)
        {
            _attackLevel += 2;
        }
    }
    
    private void GetSpeedItem()
    {
        if (_speedLevel++ < 3)
        {
            moveSpeed += _speedUpValue;
            _defaultMoveSpeed += _speedUpValue;
        }
    }
    
    private void GetUltimateItem()
    {
        _isReadyUltimate = true;
    }

    private void GetBoosterFuel()
    {
        _currentBoostGage = Mathf.Clamp(_currentBoostGage + _boosterFuelValue, 0, _maxBoostGage);
    }

    private void OnCollisionEnter(Collision other)
    {
        ObjectPoolManager.Instance.SpawnExplosion(transform.position);
        
        IDamagable damagable = other.gameObject.GetComponent<IDamagable>();

        if (damagable is not null)
        {
            damagable.DamageAction();
        }
        
        gameObject.SetActive(false);
    }
}
