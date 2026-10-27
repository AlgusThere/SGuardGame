using System;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] Transform _EnemyTransform;
    [SerializeField] float _TargetDetectionDistance = 5f;
    [SerializeField] float _FireRate = 1f;
    [SerializeField] float _BulletSpeed = 10f;

    // public event Action _OnShoot;

    public bool _IsEnemyInDistance;

    float _EnemyDistance;
    float _FireTimer = 0f;

    void Update()
    {
        if(_EnemyTransform == null) return;

        _EnemyDistance = Vector2.Distance(_EnemyTransform.position, transform.position);
        // Debug.Log(_EnemyDistance);

        if(_TargetDetectionDistance > _EnemyDistance)
        {
            LockToTarget();
            HandleShooting();
        }

    }

    private void LockToTarget()
    {
        if(_EnemyTransform != null)
        {
            Vector2 _LookAtRotation = _EnemyTransform.position - transform.position;

            float _Angle = Mathf.Atan2(_LookAtRotation.y, _LookAtRotation.x) * Mathf.Rad2Deg;

            transform.rotation = Quaternion.Euler(0, 0, _Angle);
            // transform.right = _LookAtRotation; ----------------- 2. YÖNTEM

        }
    }
    private void HandleShooting()
    {
        _FireTimer -= Time.deltaTime;

        if(_FireTimer <= 0f)
        {
            _FireTimer = _FireRate;

            GameObject _bullet = BulletPool.Instance.GetBulletFromPool();

            if (_bullet != null)
            {
                _bullet.transform.SetPositionAndRotation(transform.position,transform.rotation);

                Rigidbody2D _BulletRB = _bullet.GetComponent<Rigidbody2D>();
                if(_BulletRB != null)
                {
                    _BulletRB.linearVelocity = transform.right * _BulletSpeed;
                }

                // _OnShoot?.Invoke();
            }
        }
    }
}
