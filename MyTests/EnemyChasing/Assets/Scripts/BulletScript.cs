using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{

    [SerializeField] float bulletSpeed = 3f;

    public void StartShooting(Vector3 mousePosition)
    {
        GetComponent<Rigidbody>().velocity = new Vector3(bulletSpeed * Time.deltaTime* mousePosition.x, 0, bulletSpeed * Time.deltaTime * mousePosition.y);
    }
}
