using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    Camera cameraMain;
    private Vector3 mousePos;
    private Rigidbody2D bullet;

    [SerializeField] private float shootForce;
    
    // Start is called before the first frame update
    void Start()
    {
        cameraMain = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        bullet = GetComponent<Rigidbody2D>();
        mousePos = cameraMain.ScreenToWorldPoint(Input.mousePosition);
        // transform.position means position of current bullet
        Vector3 direction = mousePos - transform.position;

        // normalize direction
        bullet.velocity = new Vector2(direction.x, direction.y).normalized * shootForce;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
