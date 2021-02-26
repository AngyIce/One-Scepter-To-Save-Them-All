using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootScepter : MonoBehaviour
{
    public float damage = 10f;
    public float range = 100f;

    public Transform ShootingPoint;
    public GameObject laserPrefab;

    void Start()
    {
        DisableLaser();
    }

    void Update()
    {

        if (Input.GetButton("Fire1"))
        {
            Shooting();

            Vector3 forward = ShootingPoint.TransformDirection(Vector3.forward) * 0.5f;
            Debug.DrawRay(ShootingPoint.position, forward, Color.green);
        }

        if (Input.GetButton("Fire1"))
        {
            EnableLaser();
        }

        if (Input.GetButtonUp("Fire1"))
        {
            DisableLaser();
        }
    }

    void Shooting()
    {
        RaycastHit hit;
        if (Physics.Raycast(ShootingPoint.transform.position, ShootingPoint.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);

            VirusTarget target = hit.transform.GetComponent<VirusTarget>();
            if (target != null)
            {
                target.TakeDamage(damage);

            }
        }
    }

    void EnableLaser()
    {
        laserPrefab.SetActive(true);
    }

    void DisableLaser()
    {
        laserPrefab.SetActive(false);
    }
}
