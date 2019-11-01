using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    [SerializeField]
    float moveSpeed = 0.1f; //  プレイヤーの移動速度
    [SerializeField]
    float jumpPower = 50.0f;//  プレイヤーのジャンプ力

    Rigidbody rb;  //   物理オブジェクト

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //  移動処理
        if(Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(-moveSpeed, 0, 0);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(moveSpeed, 0, 0);
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(0, 0, moveSpeed);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(0, 0, -moveSpeed);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(0, jumpPower, 0);
        }
    }
}
