using System;
using UnityEngine;
using UnityEngine.InputSystem.EnhancedTouch;
using UnityEngine.InputSystem.Utilities;

public class BirbScript : MonoBehaviour
{
    [SerializeField] private float JumpPower;
    public static readonly ReadOnlyArray<UnityEngine.InputSystem.EnhancedTouch.Touch> activeTouches;
    public static Action AddScore; 
    public static Action Dead;
    public static Action Start;

    private bool isStarted = false;
    void OnEnable()
    {
        EnhancedTouchSupport.Enable();
        MenuScripts.Reset += resetGame;
    }
    void OnDisable()
    {
        EnhancedTouchSupport.Disable();
    }

    // Update is called once per frame
    void Update()
    {           
        if(EnhancedTouchSupport.enabled == false) return;
        //touch detection
        if(UnityEngine.InputSystem.EnhancedTouch.Touch.activeTouches.Count <= 0) return;
        if(UnityEngine.InputSystem.EnhancedTouch.Touch.activeTouches[0].began){
            Debug.Log("Touch Detected");
            Jump();
            if(isStarted == false){
                isStarted = true;
                Start?.Invoke();
            }
        }
    
        
    }

    private void Jump(){
        Debug.Log("Jump");
        Vector2 force = new Vector2(0,JumpPower);
        this.GetComponent<Rigidbody2D>().velocity = force;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
         if(collision.gameObject.CompareTag("Score")){
            Debug.Log("Add Points");
            AddScore?.Invoke();
        }
        if(collision.gameObject.CompareTag("Damage")){
            Debug.Log("kil");
            EnhancedTouchSupport.Disable();
            Dead?.Invoke();
        }
    }

    public void resetGame(){
        isStarted = false;
        //reset position of Birb
        transform.position = new Vector2(-1,0);
    }

}
