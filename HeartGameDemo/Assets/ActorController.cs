using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActorController : MonoBehaviour
{


    public float walkVelocity = 10.0f;
    public float jumpVelocity = 10.0f;
    private Vector2 thrustVec;
    private Vector2 moveVec;
    private Vector2 tarVec;
    private Rigidbody2D m_rigidbody;
    private PlayerInput pi;
    private Animator anim;
    private SpriteRenderer sp;
    public bool onGround = true;
    public LayerMask colLayer = new LayerMask();
    public float layLength = 0.5f;
    // Use this for initialization
    void Awake()
    {

        m_rigidbody = GetComponent<Rigidbody2D>();
        pi = GetComponent<PlayerInput>();
        anim = GetComponent<Animator>();
        sp = GetComponent<SpriteRenderer>();
        Messenger.AddListener(Message.JumpEnter, JumpEnter);
        Messenger.AddListener(Message.JumpExit, JumpExit);
        Messenger.AddListener(Message.VelocityDetect, VelocityDetect);
        //Messenger.AddListener(Message.ClearThrust, ClearThrust);

    }

    // Update is called once per frame
    void Update()
    {

        //if (Physics2D.Raycast(transform.position, Vector2.down, 2f))
        //{
        //    onGround = true;
        //}
        //else
        //{
        //    onGround = false;
        //}
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, Vector2.down, 0.5f, colLayer);
        if (hitInfo.collider!=null)
        {
            Debug.Log(Physics2D.Raycast(transform.position, Vector2.down, layLength, colLayer).collider.name);

        }
        //thrustVec.y = Input.GetKeyDown(KeyCode.Joystick1Button1) ? jumpVelocity : 0;

        //moveVec.x = Input.GetAxis("PSLeftJoyStick-X1");
        moveVec.x = pi.keyX;
        if (moveVec.x<0&& sp.flipX == false)
        {
            sp.flipX = true;
        }
        
        if(moveVec.x > 0 && sp.flipX == true)
        {
            sp.flipX = false;

        }
        if (pi.isJump)
        {
            anim.SetTrigger("jump");
        }
        if (Mathf.Abs(pi.keyX)>0.1f)
        {
            anim.SetBool("isWalking", true);
        }
        else
        {
            anim.SetBool("isWalking", false);
        }
        tarVec = new Vector2(moveVec.x, m_rigidbody.velocity.y) + thrustVec;
        thrustVec = Vector2.zero;
        m_rigidbody.velocity = walkVelocity * tarVec * Time.fixedDeltaTime;
    }

    void JumpEnter()
    {
        thrustVec.y = jumpVelocity;
        print("Jump!!!");
    }
    void JumpExit()
    {
        anim.ResetTrigger("jump");
    }
    void VelocityDetect()
    {
        //print("!!");
        anim.SetFloat("jumpVelocity", m_rigidbody.velocity.y);
    }
   

}
