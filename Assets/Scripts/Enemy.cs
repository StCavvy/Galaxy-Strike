using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private GameObject destroyVFX;



    //this method provides enemy death mechanic via collision with player weapon particles
    private void OnParticleCollision(GameObject other)
    {
        Instantiate(destroyVFX, transform.position, Quaternion.identity);
        Destroy(this.gameObject);
    }
}
