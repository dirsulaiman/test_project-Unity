using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {

    public int health = 100;
    public int point = 0;
    public bool m_Grounded;
    public bool m_FacingRight = true;
    public float m_JumpForce = 400f;
    public Rigidbody2D rb;

    public Text HpText;
    //public Text PointText;
    public Text ScorText;
    public GameObject camera;
    public BoardManager boardManager; 

    public float k_GroundedRadius = .1f;
    public Transform m_GroundCheck;
    public Transform m_CeilingCheck;
    public LayerMask m_WhatIsGround;
    public Joystick joystick;

    private float move, x;
    private bool jump;
    private BoxCollider2D b_coll;

    private Animator m_anim;
    private float m_MaxSpeed = 10f;
	
    void Awake () {
        rb = GetComponent<Rigidbody2D>();
        m_anim = GetComponent<Animator>();
        b_coll = GetComponent<BoxCollider2D>();
        HpText.text = health.ToString();
        ScorText.text = point.ToString();
        boardManager = camera.GetComponent<BoardManager>();
	}

	// Update is called once per frame
	void Update () {
        ScorText.text = point.ToString();
        if (health <= 0) {
            boardManager.GameOver(false);
        } else if (point >= 100) {
            boardManager.GameOver(true);
        }
        // x = Input.GetAxis("Horizontal");
        // x = joystick.Horizontal;
        if (joystick.Horizontal >= .4f) {
            x = 1f;
        } else if (joystick.Horizontal <= -.4f) {
            x = -1f;
        } else {
            x = 0f;
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
       
        m_anim.SetFloat("Speed", Mathf.Abs(x));
        move = x;
        rb.velocity = new Vector2 (move*m_MaxSpeed, rb.velocity.y);
        if (x>0 && !m_FacingRight) {
            Flip();
        } else if (x<0 && m_FacingRight) {
            Flip();
        }

        if (jump && m_Grounded) {
            rb.AddForce(Vector2.up* m_JumpForce);
            m_Grounded = false;
            m_anim.SetBool("Ground", false);
            //rb.velocity = new Vector2 (0f, m_JumpForce);
        }
        jump = false;
    }

    private void Flip () {
        m_FacingRight = !m_FacingRight;
        transform.Rotate(0f, 180f, 0f);
    }


    public void Jumping () {
        jump = true;
    }

    public void TakeDamage (int damage) {
        this.health -= damage;
        HpText.text = health.ToString();
    }

    public void GetPoint (int point) {
        this.point += point;
    }
}
