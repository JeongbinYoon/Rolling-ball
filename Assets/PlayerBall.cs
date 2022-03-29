using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBall : MonoBehaviour
{
    public float jumpPower;
    public int itemCount;
    bool isJumped;
    Rigidbody rigid;
    void Awake()
    {
        isJumped = false;
        rigid = GetComponent<Rigidbody>();
    }

    void Update() {
        // 점프 시 isJumped가 false이면 true로 변경 (점프를 1번만 할 수 있게)
        if(Input.GetButtonDown("Jump") && !isJumped){
            isJumped = true;
            rigid.AddForce(new Vector3(0, jumpPower, 0), ForceMode.Impulse);
        }
    }

    void FixedUpdate()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        rigid.AddForce(new Vector3(h, 0, v), ForceMode.Impulse);
    }

    void OnCollisionEnter(Collision collision) {
        if(collision.gameObject.name == "Floor"){
            isJumped = false;

        }
    }
}
