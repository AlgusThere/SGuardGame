using UnityEngine;

[CreateAssetMenu(fileName = "EnemySO", menuName = "Scriptable Objects/EnemySO")]
public class EnemySO : ScriptableObject
{
    [SerializeField] int _ENEMYHEALTH;
    [SerializeField] float _ENEMYSPEED;
    [SerializeField] Color _ENEMYCOLOR;

    public int _EnemyHealth => _ENEMYHEALTH;
    public float _EnemySpeed => _ENEMYSPEED;
    public Color _EnemyColor => _ENEMYCOLOR;
}
