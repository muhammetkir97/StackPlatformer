using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    [SerializeField] private Animator characterAnimator;

    private float movementSpeed = 1;
    private bool isMoving = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate() 
    {
        if(isMoving) CharacterMovement();
    }

    private void CharacterMovement()
    {
        transform.Translate(Vector3.forward * movementSpeed);
    }

    public void SetCharacterSpeed(float speed)
    {
        movementSpeed = speed;
    }

    public void SetCharacterAnimationStatus(CharacterState state)
    {
        switch(state)
        {
            case CharacterState.Run:
                characterAnimator.Play("Run");
                break;
            case CharacterState.Dance:
                characterAnimator.Play("Dance");
                break;
        }
    }

    public void SetCharacterMovementStatus(CharacterState state)
    {
        switch(state)
        {
            case CharacterState.Run:
                isMoving = true;
                break;
            case CharacterState.Idle:
                isMoving = false;
                break;
        }
    }
}

public enum CharacterState
{
    Idle,
    Run,
    Dance,
    Fall
}
