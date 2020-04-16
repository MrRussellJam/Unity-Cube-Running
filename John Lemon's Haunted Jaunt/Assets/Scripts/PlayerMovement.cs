using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float turnSpeed = 20f;

    Animator m_Animator;
    Rigidbody m_Rigidbody;
    Vector3 m_Movement;
    Quaternion m_Rotation = Quaternion.identity;
    AudioSource m_MoveAudio;

    private void Start()
    {
        //获取组件
        m_Animator = GetComponent<Animator>();
        m_Rigidbody = GetComponent<Rigidbody>();
        m_MoveAudio = GetComponent<AudioSource>();
    }

    private void FixedUpdate()
    {
        //获取按键输入
        float horizontal = Input.GetAxis("Horizontal");     //水平输入AD键
        float vertical = Input.GetAxis("Vertical");         //垂直输入WS键   

        m_Movement.Set(horizontal, 0f, vertical);
        m_Movement.Normalize();

        bool hasHorizontalInput = !Mathf.Approximately(horizontal, 0f);
        bool hasVerticalInput = !Mathf.Approximately(vertical, 0f);
        bool isWalking = hasHorizontalInput || hasVerticalInput;

        m_Animator.SetBool("IsWalking", isWalking);

        Vector3 desiredForward = Vector3.RotateTowards
            (transform.forward, m_Movement, turnSpeed * Time.deltaTime, 0f);
        m_Rotation = Quaternion.LookRotation(desiredForward);

        if (isWalking)
        {
            if (!m_MoveAudio.isPlaying)
                m_MoveAudio.Play();
        }
        else
            m_MoveAudio.Stop();
    }

    private void OnAnimatorMove()    //当播放动画的时候，调用Rigidbody(刚体)控制角色运动
    {
        //Movement
        m_Rigidbody.MovePosition(m_Rigidbody.position + m_Movement * m_Animator.deltaPosition.magnitude);
        //Rotation
        m_Rigidbody.MoveRotation(m_Rotation);
    }


}
