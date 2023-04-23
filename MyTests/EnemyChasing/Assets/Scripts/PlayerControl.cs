using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    // reference to camera
    [SerializeField] private Camera sceneCamera;
    
    public float playerSpeed = 10f;

    // bullet object
    [SerializeField] GameObject bullet;
    
    // bullet spawn position
    [SerializeField] Transform bulletSpawnPos;

    // speed bullet shooting
    public float bulletShootingSpeed = 3f;
    
    // mouse screen position, save for click
    public Vector3 mouseScreenPosition;
    public Vector3 mouseWorldPosition;

    // Update is called once per frame
    void Update()
    {
        // player move control
        Vector3 pos = transform.position;

        if (Input.GetKey(KeyCode.W))
        {
            pos.z += playerSpeed * Time.deltaTime;
        }
        
        if (Input.GetKey(KeyCode.S))
        {
            pos.z -= playerSpeed * Time.deltaTime;
        }
        
        if (Input.GetKey(KeyCode.D))
        {
            pos.x += playerSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.A))
        {
            pos.x -= playerSpeed * Time.deltaTime;
        }

        transform.position = pos;
        
        // shooting action
        if (Input.GetMouseButton(0))
        {
            Debug.Log("Shoot!");

            // instantiate bullet at player location and shoot
            GameObject b = Instantiate(this.bullet);
            b.transform.position = bulletSpawnPos.transform.position;
            
            // b.GetComponent<BulletScript>().StartShooting(mousePos);
        }
    }

    void GetInput()
    {
        //get mouse position when click
        mouseScreenPosition = Input.mousePosition;
        mouseScreenPosition.z = Camera.main.nearClipPlane + 1;
        mouseWorldPosition = Camera.main.ScreenToWorldPoint(mouseScreenPosition);
    }

    void PlayerRotation()
    {
        // rotate player to follow mouse
        Vector3 aimDirection = mouseWorldPosition - GetComponent<Rigidbody>().position;
        float aimAngle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg - 90f;
        GetComponent<Rigidbody>().rotation = aimAngle;
    }
}
