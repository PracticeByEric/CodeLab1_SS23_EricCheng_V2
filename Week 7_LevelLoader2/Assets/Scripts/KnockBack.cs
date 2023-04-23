using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Vector3 = System.Numerics.Vector3;

public class KnockBack : MonoBehaviour
{
    // reference of knock back object
    [SerializeField] private Rigidbody2D rb2d;
    
    // forces in related
    [SerializeField] private float strength = 16;
    [SerializeField] float delay = 0.15f;

    // alert other class the status
    private UnityEvent OnBegin, OnDone;

    public void PlayFeedback(GameObject sender)
    {
        StopAllCoroutines();
        OnBegin.Invoke();
        Vector2 direction = (transform.position - sender.transform.position).normalized;
        rb2d.AddForce(direction * strength, ForceMode2D.Impulse);
        StartCoroutine((Reset()));
    }

    // after finish, nolong apply backforce
    private IEnumerator Reset()
    {
        yield return new WaitForSeconds(delay);
        rb2d.velocity = Vector2.zero;
        OnDone?.Invoke();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
