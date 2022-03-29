using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerBall : MonoBehaviour
{
    public float jumpPower;
    public int itemCount;
    public GameManagerLogic manager;
    bool isJumped;
    Rigidbody rigid;
    new AudioSource audio;

    void Awake()
    {
        isJumped = false;
        rigid = GetComponent<Rigidbody>();
        audio = GetComponent<AudioSource>();
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

    
    void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "Item"){
            itemCount++;
            audio.Play();       
            other.gameObject.SetActive(false);
        } else if(other.gameObject.tag == "Finish"){
            if(itemCount == manager.totalItemCount){
                // Game Clear!
                SceneManager.LoadScene("Example1_" + (manager.stage + 1).ToString());
            }else{
                // Restart..        
                SceneManager.LoadScene("Example1_" + (manager.stage).ToString());
            }
        }
    }
}
