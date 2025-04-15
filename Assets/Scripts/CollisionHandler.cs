using UnityEngine;

public class CollisionHandler : MonoBehaviour
{

    private void OnTriggerEnter(Collider collisionObject)
    {
        if (collisionObject != null)
        {
            Debug.Log($"Collided with {collisionObject.name}");
        }
    }
}
