using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootScepter : MonoBehaviour
{
    public float damage = 10f;
    public float range = 100f;

    public Transform ShootingPoint;

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shooting();
        }
    }

    void Shooting()
    {
        RaycastHit hit;
        if (Physics.Raycast(ShootingPoint.transform.position, ShootingPoint.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);

            Target target = hit.transform.GetComponent<Target>();
            if (target != null)
            {
                target.TakeDamage(damage);

            }
        }
    }
}
