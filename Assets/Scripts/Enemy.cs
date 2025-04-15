using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private GameObject destroyVFX;
    private void OnParticleCollision(GameObject other)
    {
        Instantiate(destroyVFX, transform.position, Quaternion.identity);
        Destroy(this.gameObject);
    }
}
