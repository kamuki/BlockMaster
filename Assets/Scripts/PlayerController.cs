using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{

    private bool isFrozen = false;
   
    public float HorSpeed = 1f; // The fastest the player can travel in the x axis.
    private float OriginHorSpeed;
    public float VerSpeed = 1f;
    public float TurboSpeed;
    public float offsetx;
    public float offsety;
    public int maxHP = 4;
    private int currentHP;

    public float minZ = -12f;
    public float maxZ = -0.3f;

    [HideInInspector]
    public bool lookingRight = true;
    private Animator cloudanim;

    private Rigidbody rb;
    private Animator anim;
    private bool isGrounded = true;
    private ScrollingBackground ScrollBackground;

    // Use this for initialization
    void Awake()
    {
        OriginHorSpeed = HorSpeed;
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        ScrollBackground = FindObjectOfType<ScrollingBackground>();
        //cloudanim = GetComponent<Animator>();	
        //cloudanim = GameObject.Find("Cloud(Clone)").GetComponent<Animator>();
    }

    void Update()
    {
        
        if (!isFrozen)
        {
            //float ver = Input.GetAxis("Vertical");
            //// check for touch input
            //if (Input.touchCount > 0)
            //{
            //    Touch t = Input.GetTouch(0);

            //    if (t.position.x < AspectUtility.screenWidth / 2)
            //    {
            //        if (t.position.y > Camera.main.WorldToScreenPoint(transform.position).y + 2)
            //        {
            //            ver = 1;
            //        }
            //        else if (t.position.y < Camera.main.WorldToScreenPoint(transform.position).y - 2)
            //        {
            //            ver = -1;
            //        }
            //    }
            //}
            

                // scroll the camera from here, since the cart race uses different scrolling than anything else
                Camera.main.transform.position = new Vector3(transform.position.x + offsetx,
                                                transform.position.y + offsety,
                                                Camera.main.transform.position.z);
        }

    }


    void FixedUpdate()
    {
        

        //float hor = Input.GetAxis("Horizontal");
        float ver = Input.GetAxis("Vertical");
        //anim.SetFloat("Speed", Mathf.Abs(hor));  
        anim.SetFloat("Speed", HorSpeed);     
        anim.SetFloat("vSpeed", Mathf.Abs(ver));

        if (Input.GetKeyDown(KeyCode.Mouse0) || Input.GetKeyDown(KeyCode.Space)) {
            HorSpeed = TurboSpeed;
        } else if (Input.GetKeyUp(KeyCode.Mouse0) || Input.GetKeyUp(KeyCode.Space)) {
            HorSpeed = OriginHorSpeed;
        }
        Vector3 newPos = transform.position;       
        float newZ = Mathf.Clamp(transform.position.z + ver * VerSpeed * Time.fixedDeltaTime, minZ, maxZ);        
        newPos.z = newZ;
        // +hor * HorSpeed
        transform.position = new Vector3(transform.position.x, transform.position.y, newPos.z);
        

        transform.Translate(Vector3.left * -HorSpeed * Time.deltaTime);
        //if ((hor > 0 && !lookingRight) || (hor < 0 && lookingRight))
        //    Flip();
        //if(( hor >0 ) || (hor < 0)) ScrollBackground.BackGroundGo();
    }



    public void Flip()
    {
        
        lookingRight = !lookingRight;
        Vector3 myScale = transform.localScale;
        myScale.x *= -1;
        transform.localScale = myScale;
        
    }

}
