using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] private GameObject destroyedVFX;


    // this method provides player death mechanic via collision with enemies or terrain
    private void OnTriggerEnter(Collider collisionObject)
    {
        if (collisionObject != null )
        {
            Instantiate(destroyedVFX, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }
}
