using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public bool m_Grounded;
    public bool m_FacingRight = true;
    public float m_JumpForce = 400f;
    public Rigidbody2D rb;
    public bool crouch;

    public float k_GroundedRadius = .1f;
    public Transform m_GroundCheck;
    public Transform m_CeilingCheck;
    public LayerMask m_WhatIsGround;
    private float move, x;
    private bool jump;
    private bool crouching = false;
    private BoxCollider2D b_coll;

    private Animator m_anim;
    private float m_MaxSpeed = 10f;
    [Range(0, 1)] [SerializeField] private float m_CrouchSpeed = .36f;	// Use this for initialization
	void Awake () {
        rb = GetComponent<Rigidbody2D>();
        m_anim = GetComponent<Animator>();
        b_coll = GetComponent<BoxCollider2D>();
	}

	// Update is called once per frame
	void Update () {
        x = Input.GetAxis("Horizontal");
        //print(rb.velocity.y);
        if (Input.GetKeyDown(KeyCode.Space)) {
            jump = true;
        }
        if (Input.GetButtonDown("Crouch")) {
            Crouching(true);
        } else if ((Input.GetButtonUp("Crouch"))) {
            Crouching(false);
        }
	}

    void FixedUpdate () {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(m_GroundCheck.position, k_GroundedRadius, m_WhatIsGround);
        for (int i = 0; i < colliders.Length; i++)
        {
            //print(colliders[i].name);
            if (colliders[i].gameObject != gameObject)
                m_Grounded = true;
                m_anim.SetBool("Ground", true);
        }
        /*
        if (Physics2D.OverlapCircle(m_CeilingCheck.position, k_GroundedRadius, m_WhatIsGround)){
            crouching = true;
            //print("on crouch");
        }
        */
        m_anim.SetFloat("Speed", Mathf.Abs(x));
        move = crouch ? x*m_CrouchSpeed : x;
        rb.velocity = new Vector2 (move*m_MaxSpeed, rb.velocity.y);
        if (x>0 && !m_FacingRight) {
            Flip();
        } else if (x<0 && m_FacingRight) {
            Flip();
        }

        if (jump && m_Grounded) {
            rb.AddForce(new Vector2 (rb.velocity.x, m_JumpForce));
            m_Grounded = false;
            m_anim.SetBool("Ground", false);
            //rb.velocity = new Vector2 (0f, m_JumpForce);
        }
        jump = false;
        //Debug.Log(m_Grounded);
    }

    private void Flip () {
        m_FacingRight = !m_FacingRight;
        transform.Rotate(0f, 180f, 0f);
    }

    private void Crouching (bool crouch) {
        m_anim.SetBool("Crouch", crouch);
        this.crouch = crouch;
        b_coll.enabled = !crouch;
    }
}
