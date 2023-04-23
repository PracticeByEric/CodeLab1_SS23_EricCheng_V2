using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    [SerializeField] private Camera mainCamera;

    private Vector3 mousePos;

    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform bulletPosition; 
    
    // bullet loading => time gap
    // default canFire true, shot right after game start
    private bool canFire = true;
    private float timer;
    [SerializeField] float bulletLoadingTime;
    
    // shooting status indicator
    [SerializeField] private TMP_Text LoaderText;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // turn mouse position screen to world
        mousePos = mainCamera.ScreenToWorldPoint(Input.mousePosition);

        // rotation of object
        Vector3 rotation = mousePos - transform.position;

        float rotZ = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
        
        // transform.rotation = Quaternion.Euler(0, 0, rotZ);

        // bullet loading
        if (canFire == false)
        {
            // stat counting fire loading time
            timer += Time.deltaTime;
            if (timer > bulletLoadingTime)
            {
                // turn true
                canFire = true;
                // reset timer
                timer = 0;
            }
        }
        
        // bullet loader text
        if (canFire == false)
        {
            // change text to loading
            LoaderText.text= "Bullet Loading";
        }
        else
        {
            LoaderText.text = "Ready to shot";
        }

        // SHOOT ON CLICK
        if (Input.GetMouseButton(0) && canFire)
        {
            // Debug.Log("Shoot!");
            
            // instantiate bullet
            Instantiate(bullet, bulletPosition.position, Quaternion.identity);
            // reloading
            canFire = false;
            
        }
    }
}
