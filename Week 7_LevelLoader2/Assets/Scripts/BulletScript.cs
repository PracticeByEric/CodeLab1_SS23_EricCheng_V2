using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    Camera cameraMain;
    private Vector3 mousePos;
    private Rigidbody2D bullet;

    [SerializeField] private float shootForce;
    
    // get size of bullet object
    private Vector2 bulletSize;
    private float bulletWidth;
    private float bulletHeight;
    
    // get screen boundary
    private Vector2 screenBounds;
    
    // Animation and states
    // private Animator bulletAnimator;
    // private string currentAnimationState;
    // private const string BULLET_IDLE = "Bullet_Idle";
    // private const string BULLET_HITBORDER= "HitBorder";
    
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
        
        // calculate screen boundaries
        screenBounds = Camera.main.ScreenToWorldPoint((new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z)));
        
        // calculate size of bullet object
        bulletSize = GetComponent<CircleCollider2D>().bounds.size;
        bulletWidth = bulletSize.x;
        bulletHeight = bulletSize.y;
        
        // get animator
        // bulletAnimator = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
        // ChangeAnimationState(BULLET_IDLE);
        DestoryBulletOutsideBoundary();
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // hit object with tag enemy
        if (collision.gameObject.tag == "Enemy")
        {
            Destroy(gameObject);
            // GameManager.instance.GetComponent<LevelControls>().BulletCollision();
        }
    }

    void DestoryBulletOutsideBoundary()
    {
        Vector3 objectPos = transform.position;
        // if width exceed boundary
        if (objectPos.x > screenBounds.x - bulletWidth/2 || objectPos.x < screenBounds.x * -1 + bulletWidth/2)
        {
            // ChangeAnimationState(BULLET_HITBORDER);
            Destroy(gameObject);
        }
        // if height exceed boundary
        if (objectPos.y > screenBounds.y - bulletHeight/2 || objectPos.y < screenBounds.y * -1 + bulletHeight/2)
        {
            // ChangeAnimationState(BULLET_HITBORDER);
            Destroy(gameObject);
        }
    }
    
    // animation state changer
    // void ChangeAnimationState(string newState)
    // {
    //     // stop animation from interrupting itself
    //     if (currentAnimationState == newState)
    //     {
    //         return;
    //     }
    //     // play new animation
    //     else
    //     {
    //         bulletAnimator.Play(newState);
    //     }
    //
    //     currentAnimationState = newState;
    // }
}
