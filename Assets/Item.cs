using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{    
    public float rotateSpeed;
    void Update()
    {
        transform.Rotate(Vector3.up * rotateSpeed * Time.deltaTime, Space.World);
    }

    void OnTriggerEnter(Collider other) {
        if(other.gameObject.name == "Player"){
            PlayerBall player = other.GetComponent<PlayerBall>();
            player.itemCount++;
            gameObject.SetActive(false);            
        }
    }
}
