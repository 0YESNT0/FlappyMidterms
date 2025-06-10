using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trunks : MonoBehaviour
{
    [SerializeField]private float moveSpeed;
    [SerializeField]float despawnOnXLimit;
       
    // Update is called once per frame
    void Update()
    {
        Vector2 position = transform.position;
        position.x = position.x - (moveSpeed * Time.deltaTime);
        transform.position = position;

        if(transform.position.x <= despawnOnXLimit){
            Destroy(this);
        }
    }

    public void SetMoveSpeed(int speed){
        moveSpeed = speed;
    }
}
