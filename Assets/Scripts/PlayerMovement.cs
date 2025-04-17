using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    //variables to control movement clamping
    [SerializeField] private float yClampOffset = 5f;
    [SerializeField] private float xClampRange = 5f;
    [SerializeField] private float yClampRange = 5f;


    //variables to control player moevement
    [SerializeField] private float ControlSpeed = 0f;
    [SerializeField] private float controlRollFactor = 0f;
    [SerializeField] private float controlPitchFactor = 0f;
    [SerializeField] private float rotationSpeed = 0f;

    Vector2 movement;

    void Update()
    {
        ProcessTranslation();
        ProcessRotation();
    }

    private void ProcessTranslation()
    {
        //processing movement on X axis and clamping players movement
        float xOffset = movement.x * ControlSpeed * Time.deltaTime;
        float rawXPos = transform.localPosition.x + xOffset;
        float clampedXPos = Mathf.Clamp(rawXPos, -xClampRange, xClampRange);

        //processing movement on Y axis and clamping players movement, also with offset on Y positive direction
        float yOffset = movement.y * ControlSpeed * Time.deltaTime;
        float rawYPos = transform.localPosition.y + yOffset;
        float clampedYPos = Mathf.Clamp(rawYPos, -yClampRange, yClampRange + yClampOffset);


        //moving player object
        transform.localPosition = new Vector3(clampedXPos, clampedYPos, 0f);
    }

    private void ProcessRotation()
    {
        float roll = -controlRollFactor * movement.x;
        float pitch = -controlPitchFactor * movement.y;

        Quaternion targetRotation = Quaternion.Euler(pitch, 0f, roll);
        transform.localRotation = Quaternion.Lerp(transform.localRotation, targetRotation, rotationSpeed * Time.deltaTime);
    }

    private void OnMove(InputValue value)
    {
        movement = value.Get<Vector2>();
    }
}
