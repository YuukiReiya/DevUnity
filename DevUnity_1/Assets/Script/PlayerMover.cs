using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    [SerializeField]
    float moveSpeed = 0.1f; //  プレイヤーの移動速度
    [SerializeField]
    float jumpPower = 50.0f;//  プレイヤーのジャンプ力
    [SerializeField]
    float rotspeed = 10.0f;
    bool isGround = true;
    Rigidbody rb;  //   物理オブジェクト
    Animator animator;
    int faceIndex = 0;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float speed = 0, rot = 0;

        //  移動処理
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rot = -1;
            transform.Rotate(0, -rotspeed * Time.deltaTime, 0);
            //transform.Translate(-moveSpeed, 0, 0);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            rot = 1;
            transform.Rotate(0, rotspeed * Time.deltaTime, 0);
            //transform.Translate(moveSpeed, 0, 0);
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            speed = Input.GetKey(KeyCode.LeftShift) ? 0.5f : 1.0f;
            transform.Translate(0, 0, (moveSpeed * Time.deltaTime) * speed);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            speed = -0.5f;
            transform.Translate(0, 0, (-moveSpeed * Time.deltaTime) * speed);
        }
        if (Input.GetKeyDown(KeyCode.Space) && isGround)
        {
            rb.AddForce(0, jumpPower, 0);
            animator.SetBool("Jump", true);
        }

        //anim param
        animator.SetFloat("speed", speed);
        animator.SetFloat("rot", rot);

        //face
        FaceUpdate();
    }

    private void OnCollisionEnter(Collision collision)
    {
        isGround = true;
        animator.SetBool("Jump", false);
    }

    private void OnCollisionExit(Collision collision)
    {
        isGround = false;
    }

    void FaceUpdate()
    {
        if (Input.GetKeyDown("1"))
        {
            faceIndex = faceIndex == 1 ? 0 : 1;
            Debug.Log("index:"+faceIndex);
        }
        if (Input.GetKeyDown("2"))
        {
            faceIndex = faceIndex == 2 ? 0 : 2;
        }
        if (Input.GetKeyDown("3"))
        {
            faceIndex = faceIndex == 3 ? 0 : 3;
        }
        animator.SetInteger("FaceIndex", faceIndex);
    }
}
