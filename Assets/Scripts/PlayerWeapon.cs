using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerWeapon : MonoBehaviour
{
    //reference variable for player weapon objects
    [SerializeField] private GameObject[] weapons;

    //reference variable for crosshair UI element
    [SerializeField] private RectTransform crosshair;

    //variables for processing targeting
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


    private void OnFire(InputValue value)
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


    //method provides following target point on cursor
    private void MoveTargetPoint()
    {
        Vector3 targetPointPosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, targetDistance);
        targetPoint.position = Camera.main.ScreenToWorldPoint(targetPointPosition);
    }


    //method provides moving crosshair on cursor
    private void MoveCrosshair()
    {
        crosshair.position = Input.mousePosition;
    }


    //aiming players weapons on target point 
    private void AimWeapons()
    {
        foreach (GameObject weapon in weapons)
        {
            Vector3 fireDirection = targetPoint.position - transform.position;
            Quaternion rotationToTarget = Quaternion.LookRotation(fireDirection);
            weapon.transform.rotation = rotationToTarget;
        }
    }
}
