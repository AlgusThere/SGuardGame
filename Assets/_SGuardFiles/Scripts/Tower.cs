using UnityEngine;
using UnityEngine.UI;

public class Tower : MonoBehaviour
{
    [Header("Tower Values")]
    [SerializeField] int _TowerHealth = 100;
    [SerializeField] float _TowerAttackSpeed = 2f;
    [SerializeField] float _TowerAttackRange = 3f;

    [SerializeField] Slider _HealthSlider;
    

    void Start()
    {
        if(_HealthSlider !=null)
        {
            _HealthSlider.maxValue = _TowerHealth;
            _HealthSlider.value = _TowerHealth;
            
        }

    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Enemy"))
        {
            _TowerHealth -= 10;
            _HealthSlider.value = _TowerHealth;
            Debug.Log("TowerHealth : " + _TowerHealth);
        }
    }
}
