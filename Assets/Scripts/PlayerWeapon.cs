using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerWeapon : MonoBehaviour
{
    [SerializeField] private GameObject weapon;
    bool isFiring = false;
    void Update()
    {
        ProcessFiring();
    }


    void OnFire(InputValue value)
    {
        isFiring = value.isPressed;
    }

    private void ProcessFiring()
    {
        var emissionModule = weapon.GetComponent<ParticleSystem>().emission;
        emissionModule.enabled = isFiring;
    }
}
