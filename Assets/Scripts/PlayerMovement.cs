using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] float ControlSpeed = 0f;
    [SerializeField] float xClampRange = 5f;
    [SerializeField] float yClampRange = 5f;


    Vector2 movement;

    void Update()
    {
        ProcessTranslation();
    }

    private void ProcessTranslation()
    {
        float xOffset = movement.x * ControlSpeed * Time.deltaTime;
        float rawXPos = transform.localPosition.x + xOffset;
        float clampedXPos = Mathf.Clamp(rawXPos, -xClampRange, xClampRange);

        float yOffset = movement.y * ControlSpeed * Time.deltaTime;
        float rawYPos = transform.localPosition.y + yOffset;
        float clampedYPos = Mathf.Clamp(rawYPos, -yClampRange, yClampRange);



        transform.localPosition = new Vector3(clampedXPos, clampedYPos, 0f);
    }

    public void OnMove(InputValue value)
    {
        movement = value.Get<Vector2>();
    }
}
