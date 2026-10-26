using UnityEngine;
using System.Collections.Generic;
using System.Collections;



public class Bullet : MonoBehaviour
{
    private const int POOl_SIZE = 10;

    [SerializeField] GameObject _BulletPrefab;

    [SerializeField] float _FireDuration = 2f;
    [SerializeField] float _BulletSpeed = 10f;

    [SerializeField] Gun _Gun;

    private Queue<GameObject> _Bullets;

    void OnEnable()
    {
        if(_Gun != null)
        _Gun._OnShoot += OnFire;
    }

    void OnDisable()
    {
        if(_Gun != null)
        _Gun._OnShoot -= OnFire;
    }

    void Start()
    {
        _Bullets = new();

        for (int i = 0; i < POOl_SIZE; ++i)
        {
            GameObject _Bullet = Instantiate(_BulletPrefab, Vector3.zero, Quaternion.identity, this.transform);
            _Bullet.SetActive(false);
            _Bullets.Enqueue(_Bullet);
        }
    }

    private GameObject GetBulletFromPool()
    {
        if(_Bullets.Count > 0)
        {
            GameObject _Bullet = _Bullets.Dequeue();
            _Bullet.SetActive(true);
            return _Bullet;
        }
        return null;
    }

    private void ReturnBulletToPool(GameObject _Bullet)
    {
        _Bullet.SetActive(false);
        _Bullets.Enqueue(_Bullet);
    }

    private IEnumerator DisableBulletAfterDelay(GameObject _bullet, float delay)
    {
        yield return new WaitForSeconds(delay);
        ReturnBulletToPool(_bullet);
    }

    void OnFire()
    {
        GameObject _bullet = GetBulletFromPool();
        if (_bullet != null)
        {
            _bullet.transform.SetPositionAndRotation(transform.position,transform.rotation);

            Rigidbody2D _BulletRB = _bullet.GetComponent<Rigidbody2D>();
            if(_BulletRB != null)
            {
                _BulletRB.linearVelocity = _Gun.transform.right * _BulletSpeed;
            }

            StartCoroutine(DisableBulletAfterDelay(_bullet, _FireDuration));
        }
    }

}
