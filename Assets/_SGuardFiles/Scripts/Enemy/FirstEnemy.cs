using UnityEngine;

public class FirstEnemy : MonoBehaviour
{
    [SerializeField] EnemySO _EnemySO;

    Rigidbody2D _RB;

    int _Health;
    float _Speed;
    Color _Color;
    
    void Start()
    {
        _RB = GetComponent<Rigidbody2D>();

        _Health = _EnemySO._EnemyHealth;
        _Speed = _EnemySO._EnemySpeed;
        _Color = _EnemySO._EnemyColor;

        // Debug.Log(_Health);
        // Debug.Log(_Speed);
        // Debug.Log(_Color);
    }

    
    void FixedUpdate()
    {
        _RB.linearVelocityX = -_Speed;
    }

    public void TakeDamage(int _DamageAmount)
    {
        _Health -= _DamageAmount;
        Debug.Log(_Health);
        if(_Health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
