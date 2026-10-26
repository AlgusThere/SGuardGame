using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] Transform _EnemyTransform;

    void Start()
    {
        
    }


    void Update()
    {
        if(_EnemyTransform != null)
            LockToTarget();
    }

    private void LockToTarget()
    {
        Vector2 _LookAtRotation = _EnemyTransform.position - transform.position;

        float _Angle = Mathf.Atan2(_LookAtRotation.y, _LookAtRotation.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0, 0, _Angle);
    }
}
