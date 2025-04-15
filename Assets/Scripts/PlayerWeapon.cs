using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerWeapon : MonoBehaviour
{
    [SerializeField] private GameObject[] weapons;
    [SerializeField] private RectTransform crosshair;
    [SerializeField] private Transform targetPoint;
    [SerializeField] private float targetDistance = 100f;



    bool isFiring = false;



    private void Start()
    {
        Cursor.visible = false;
    }


    void Update()
    {
        ProcessFiring();
        MoveCrosshair();
        MoveTargetPoint();
        AimWeapons();
    }

    void OnFire(InputValue value)
    {
        isFiring = value.isPressed;
    }

    private void ProcessFiring()
    {
        foreach (var weapon in weapons)
        {
            var emissionModule = weapon.GetComponent<ParticleSystem>().emission;
            emissionModule.enabled = isFiring;
        }
    }



    private void MoveTargetPoint()
    {
        Vector3 targetPointPosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, targetDistance);
        targetPoint.position = Camera.main.ScreenToWorldPoint(targetPointPosition);
    }
    private void MoveCrosshair()
    {
        crosshair.position = Input.mousePosition;
    }

    void AimWeapons()
    {
        foreach (GameObject weapon in weapons)
        {
            Vector3 fireDirection = targetPoint.position - transform.position;
            Quaternion rotationToTarget = Quaternion.LookRotation(fireDirection);
            weapon.transform.rotation = rotationToTarget;
        }



    }
}
