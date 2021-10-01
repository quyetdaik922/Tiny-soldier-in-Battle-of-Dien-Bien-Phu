using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller2D;
    public Animator animator;
    public float speed = 40f;
    float m_movehorizontal = 0f;
    
    bool m_isJump = false, m_isCrouch = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        m_movehorizontal = Input.GetAxisRaw("Horizontal") * speed;
        animator.SetFloat("speed", Mathf.Abs(m_movehorizontal));
        if (Input.GetButtonDown("Jump"))
        {
            m_isJump = true;
            animator.SetBool("jump", true);
            
        }
        if (Input.GetButtonDown("Crouch"))
        {
            m_isCrouch = true;
            animator.SetBool("crouch",true);
        }
        if(Input.GetButtonUp("Crouch"))
        {
            m_isCrouch = false;
            animator.SetBool("crouch", false);
        }
        
    }
    private void FixedUpdate()
    {
        controller2D.Move(m_movehorizontal * Time.fixedDeltaTime, m_isCrouch, m_isJump);
        m_isJump = false;
    }
    public void onLanding()
    {
        animator.SetBool("jump", false);
    }
    
}
