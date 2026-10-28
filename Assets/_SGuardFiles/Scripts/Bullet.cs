using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float _LifeTime = 2f;
    [SerializeField] int _Damage = 10;

    private bool _HasHit;

    void OnEnable()
    {
        _HasHit = false;
        Invoke("DeactiveBullet", _LifeTime);
    }

    void OnDisable()
    {
        CancelInvoke("DeactiveBullet");
    }

    void DeactiveBullet()
    {
        BulletPool.Instance.ReturnBulletToPool(this.gameObject);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(_HasHit) return;

        if(collision.CompareTag("Enemy"))
        {
            _HasHit = true;

            FirstEnemy _Enemy = collision.GetComponent<FirstEnemy>();
            _Enemy.TakeDamage(_Damage);

            DeactiveBullet();
        }
    }

}
