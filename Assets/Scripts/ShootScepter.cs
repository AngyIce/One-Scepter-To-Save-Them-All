using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootScepter : MonoBehaviour
{
    public float damage = 10f;
    public float range = 100f;

    public new Camera camera;
    public GameObject laserPrefab;

    public AudioSource laser;
    public AudioSource death;

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

            if (!laser.isPlaying)
            {
                laser.Play();
            }
            
        }

        if (Input.GetButtonUp("Fire1"))
        {
            DisableLaser();

            
                laser.Stop();
            
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
                death.Play();
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
