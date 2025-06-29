using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trunks : MonoBehaviour
{
    [SerializeField]private float moveSpeed;
    [SerializeField]float despawnOnXLimit;

    void OnEnable(){
        BirbScript.Start +=  Despawn;
        MenuScripts.Reset += Despawn; 
    }
    void OnDisable(){
        BirbScript.Start -=  Despawn;
        MenuScripts.Reset -= Despawn; 
    }
    void Update()
    {
        Vector2 position = transform.position;
        position.x = position.x - (moveSpeed * Time.deltaTime);
        transform.position = position;

        if(transform.position.x <= despawnOnXLimit){
            Despawn();
        }
    }

    public void SetMoveSpeed(int speed){
        moveSpeed = speed;
    }

    private void Despawn(){        
        Destroy(this.gameObject);
    }
}
