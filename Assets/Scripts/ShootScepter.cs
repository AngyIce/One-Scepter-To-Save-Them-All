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

        if (Input.GetButton("Fire1"))
        {
            Shooting();

            Vector3 forward = ShootingPoint.TransformDirection(Vector3.forward) * 0.5f;
            Debug.DrawRay(ShootingPoint.position, forward, Color.green);
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
}
