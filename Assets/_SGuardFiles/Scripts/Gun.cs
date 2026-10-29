using System;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [Header("Targeting")]
    [SerializeField] float _TargetDetectionDistance = 5f;
    [SerializeField] LayerMask _EnemyLayer;
    
    [Header("Values")]
    [SerializeField] float _FireRate = 1f;
    [SerializeField] float _BulletSpeed = 10f;

    // public event Action _OnShoot;

    Transform _CurrentTarget;
    float _FireTimer = 0f;

    void Update()
    {
        FindClosestEnemy();

        if(_CurrentTarget == null) return;

        LockToTarget();
        HandleShooting();
    }

    private void FindClosestEnemy()
    {
        Collider2D[] _EnemiesInRange = Physics2D.OverlapCircleAll(transform.position, _TargetDetectionDistance, _EnemyLayer);

        float _ClosestDistance = Mathf.Infinity;
        Transform _ClosestEnemy = null;

        foreach (Collider2D _EnemyCollider in _EnemiesInRange)
        {
            float _Distance = Vector2.Distance(transform.position, _EnemyCollider.transform.position);
            if(_Distance < _ClosestDistance)
            {
                _ClosestDistance = _Distance;
                _ClosestEnemy = _EnemyCollider.transform;
            }
        }

        _CurrentTarget = _ClosestEnemy;
    }   

    private void LockToTarget()
    {
        Vector2 _LookAtRotation = _CurrentTarget.position - transform.position;

        transform.right = _LookAtRotation; //----------------- 2. YÖNTEM
        
        // float _Angle = Mathf.Atan2(_LookAtRotation.y, _LookAtRotation.x) * Mathf.Rad2Deg;

        // transform.rotation = Quaternion.Euler(0, 0, _Angle);
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

    // void OnDrawGizmosSelected()
    // {
    //     Gizmos.color = Color.red;
    //     Gizmos.DrawWireSphere(transform.position, _TargetDetectionDistance);
    // }
}
