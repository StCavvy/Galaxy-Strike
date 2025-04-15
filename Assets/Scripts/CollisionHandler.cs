using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] private GameObject destroyedVFX;
    private void OnTriggerEnter(Collider collisionObject)
    {
        if (collisionObject != null )
        {
            Instantiate(destroyedVFX, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }
}
