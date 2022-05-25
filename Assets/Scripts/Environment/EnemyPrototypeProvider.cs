using UnityEngine;

public class EnemyPrototypeProvider : MonoBehaviour
{
    [Header("References")]
    [SerializeField] MeleeEnemy _fastMeleeEnemyPrototype;
    [SerializeField] MeleeEnemy _slowMeleeEnemyPrototype;
    [SerializeField] ShooterEnemy _shooterEnemyPrototype;

    private void Start()
    {
        _fastMeleeEnemyPrototype.DisableEnemy();
        _slowMeleeEnemyPrototype.DisableEnemy();
        _shooterEnemyPrototype.DisableEnemy();
    }

    public MeleeEnemy CloneFastMeleeEnemy()
    {
        var clone = Instantiate(_fastMeleeEnemyPrototype);

        return clone;
    }

    public MeleeEnemy CloneSlowMeleeEnemy()
    {
        var clone = Instantiate(_slowMeleeEnemyPrototype);

        return clone;
    }

    public ShooterEnemy CloneShooterEnemy()
    {
        var clone = Instantiate(_shooterEnemyPrototype);

        return clone;
    }

    public Enemy GetRandomEnemy()
    {
        Enemy clone = null;
        switch (Random.Range(0, 3))
        {
            case 0:
                clone = CloneFastMeleeEnemy();
                break;
            case 1:
                clone = CloneSlowMeleeEnemy();
                break;

            case 2:
                clone = CloneShooterEnemy();
                break;
            default:

                break;
        }

        return clone;
    }

}
