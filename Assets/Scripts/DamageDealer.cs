
using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    [SerializeField] int damageLevel;
    [SerializeField] bool destroyOnCollision;

    public int GetDamage() { return damageLevel; }
    public bool ShouldDestroyOnCollision() { return destroyOnCollision; }

    public void OnHit()
    {
        if (destroyOnCollision)
        {
            Destroy(gameObject);
        }
    }

}
