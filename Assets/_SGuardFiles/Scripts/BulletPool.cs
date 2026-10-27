using UnityEngine;
using System.Collections.Generic;
using System.Collections;


public class BulletPool : MonoBehaviour
{
    public static BulletPool Instance;
    private const int POOl_SIZE = 10;

    [SerializeField] GameObject _BulletPrefab;

    [SerializeField] float _FireDuration = 1f;

    private Queue<GameObject> _Bullets;

    void Awake()
    {
        if(Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        _Bullets = new Queue<GameObject>();

        for (int i = 0; i < POOl_SIZE; ++i)
        {
            GameObject _Bullet = Instantiate(_BulletPrefab, Vector3.zero, Quaternion.identity, this.transform);
            _Bullet.SetActive(false);
            _Bullets.Enqueue(_Bullet);
        }
    }

    public GameObject GetBulletFromPool()
    {
        if(_Bullets.Count > 0)
        {
            GameObject _Bullet = _Bullets.Dequeue();
            _Bullet.SetActive(true);

            StartCoroutine(DisableBulletAfterDelay(_Bullet, _FireDuration));
            return _Bullet;
        }
        else
        {
            GameObject _NewBullet = Instantiate(_BulletPrefab, Vector3.zero, Quaternion.identity, this.transform);
            _NewBullet.SetActive(true);

            StartCoroutine(DisableBulletAfterDelay(_NewBullet, _FireDuration));
            return _NewBullet;
        }
    }

    private void ReturnBulletToPool(GameObject _Bullet)
    {
        _Bullet.SetActive(false);
        _Bullets.Enqueue(_Bullet);
    }

    private IEnumerator DisableBulletAfterDelay(GameObject _bullet, float delay)
    {
        yield return new WaitForSeconds(delay);
        
        if(_bullet.activeInHierarchy)
            ReturnBulletToPool(_bullet);
    }

}
