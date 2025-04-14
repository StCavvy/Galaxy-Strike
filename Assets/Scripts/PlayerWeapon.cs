using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerWeapon : MonoBehaviour
{
    [SerializeField] private GameObject[] weapons;
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
    {   foreach (var weapon in weapons)
        {
            var emissionModule = weapon.GetComponent<ParticleSystem>().emission;
            emissionModule.enabled = isFiring;
        }
    }
}
