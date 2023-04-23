using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropellerRotation : MonoBehaviour
{

    public static PropellerRotation Instance;

    private Rigidbody _rb;

    [SerializeField] private float speed;

    [SerializeField] private float angularSpeed;

    public int rAngle = 20;

    private void Awake()
    {
        if (Instance == null)
        {
            DontDestroyOnLoad(gameObject);
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
            
        }
    }

    // Start is called before the first frame update

    void Start()
    {
        _rb = gameObject.GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {
        speed = _rb.velocity.magnitude;
        angularSpeed = _rb.angularVelocity.magnitude * Mathf.Rad2Deg;

        var q = Quaternion.AngleAxis(rAngle, Vector3.back);

        float angle;
        Vector3 axis;
        q.ToAngleAxis(out angle, out axis);

        _rb.angularVelocity = axis * angle * Mathf.Deg2Rad;
        
    }
    
}
