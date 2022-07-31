using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class GameManager : MonoBehaviour
{
    [SerializeField] private CharacterController characterController;

    [Header("UI")]
    [SerializeField] private Transform startText;

    private int currentLevel = 0;
    private bool isGameStarted = false;

    void Start()
    {
        startText.DOScale(Vector3.one * 1.2f,0.3f).SetLoops(-1,LoopType.Yoyo);

    }

    // Update is called once per frame
    void Update()
    {
        if(!isGameStarted && Input.GetMouseButtonDown(0))
        {
            isGameStarted = true;
            StartLevel();
            startText.DOKill();
            startText.DOScale(Vector3.zero,0.1f);
        }
    }

    void StartLevel()
    {

        characterController.SetCharacterSpeed(Globals.instance.GetCharacterSpeed(currentLevel));
        characterController.SetCharacterAnimationStatus(CharacterState.Run);
        characterController.SetCharacterMovementStatus(CharacterState.Run);
    }
}
