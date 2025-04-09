using UnityEngine;

public class Projectile : MonoBehaviour
{
    #region Data Members

    #region Editor Settings

    [SerializeField] private float speed;
    [SerializeField] private GameObject explosionEffect;
    [SerializeField] private int damage = 20; // Damage dealt per hit

    #endregion

    #region Private Fields

    private bool destroyed = false;

    #endregion

    #endregion

    #region Methods

    #region Unity Callbacks

    private void Start()
    {
        Rigidbody rigidBody = GetComponent<Rigidbody>();
        if (rigidBody != null)
        {
            rigidBody.linearVelocity = transform.forward * speed;
        }
        else
        {
            Debug.LogWarning("Projectile has no Rigidbody attached.");
        }
    }

    private void OnCollisionEnter(Collision col)
    {
        if (destroyed) return;

        // Check if hit object is an enemy
        EnemyHealth enemyHealth = col.gameObject.GetComponent<EnemyHealth>();
        if (enemyHealth != null)
        {
            Vector3 hitPoint = col.contacts.Length > 0 ? col.contacts[0].point : transform.position;
            enemyHealth.TakeDamage(damage, hitPoint);
        }

        // Always destroy on collision (even if not an enemy)
        if (explosionEffect != null)
        {
            Instantiate(explosionEffect, transform.position, Quaternion.identity);
        }

        destroyed = true;
        Destroy(gameObject);
    }
    #endregion

    #endregion
}
