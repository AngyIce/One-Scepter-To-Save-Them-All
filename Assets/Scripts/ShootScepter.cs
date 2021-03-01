﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootScepter : MonoBehaviour
{
    public float damage = 10f;
    public float range = 100f;

    public new Camera camera;
    public GameObject laserPrefab;

    void Start()
    {
        DisableLaser();
    }

    void Update()
    {

        if (Input.GetButton("Fire1") && GameController.isEnded == false)
        {
            Shooting();
        }

        if (Input.GetButton("Fire1") && GameController.isEnded == false)
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
        if (Physics.Raycast(camera.transform.position, camera.transform.forward, out hit, range))
        {
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
