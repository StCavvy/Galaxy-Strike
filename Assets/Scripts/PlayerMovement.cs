using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] float ControlSpeed;
    Vector2 movement;

    void Start()
    {
        
    }

    void Update()
    {   
        float xOffset = movement.x * ControlSpeed * Time.deltaTime;
        transform.localPosition = new Vector3(transform.localPosition.x + xOffset, 0f, 0f);
    }


    public void OnMove(InputValue value)
    {
        movement = value.Get<Vector2>();
    }
}
