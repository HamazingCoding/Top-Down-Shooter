using UnityEngine;

namespace BarthaSzabolcs.TutorialOnly
{
    public class Projectile : MonoBehaviour
    {
        #region Datamembers

        #region Editor Settings

        [SerializeField] private float speed;
        [SerializeField] private GameObject explosionEffect;

        #endregion
        #region Private Fields

        private bool destroyed = false;

        #endregion

        #endregion


        #region Methods

        #region Unity Callbacks

        private void Start()
        {
            var rigidBody = GetComponent<Rigidbody>();

            rigidBody.linearVelocity = transform.forward * speed;
        }

        private void OnCollisionEnter(Collision col)
        {
            if (destroyed == false)
            {
                Instantiate(explosionEffect, transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
        }

        #endregion

        #endregion
    }
}
