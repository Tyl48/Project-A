using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.Splines;

public class Moverment : MonoBehaviour
{
    enum State { Idle, Run, Warzone }

    [Header("setting")]
    [SerializeField] private float moveSpeed;

    [Header("Elements")]
    [SerializeField] private PlayerAnimator playerAnimator;

    [Header("Spline setting")]
    private float WarzoneTimer;

    private State state;
    private Warzone currentWarzone;
    [SerializeField] private float slowMoScale;
    
    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;
        state = State.Idle;
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyUp(KeyCode.Space))
        {
            StartRunning();
        }
        ManageState();
    }

    private void ManageState()
    {
        switch (state)
        {
            case State.Idle:
                break;

            case State.Run:
                Move();
                break;

            case State.Warzone:
                ManageWarzoneState();
                break;
        }
    }
    private void Move()
    {
        transform.position += Vector3.right * moveSpeed * Time.deltaTime;
    }

    private void StartRunning()
    {
        state = State.Run;
        playerAnimator.PlayRunAnimation();
    }

    public void EnterWarzoneCallback(Warzone warzone)
    {
        if (currentWarzone != null)
            return; 

        state= State.Warzone;
        currentWarzone = warzone;

        WarzoneTimer = 0;

        playerAnimator.Play(currentWarzone.GetAnimationToPlay(), currentWarzone.GetAnimatorSpeed());
        
        Time.timeScale = slowMoScale;

        Debug.Log("enter warzone");
    }

    private void ManageWarzoneState()
    {
        WarzoneTimer += Time.deltaTime;
        float splinePercent = WarzoneTimer / currentWarzone.GetDuration(); ;
       transform.position = currentWarzone.GetPlayerSpline().EvaluatePosition(splinePercent);

        if (splinePercent >= 1)
            ExitWarzone();
    }

    private void ExitWarzone()
    {
        state = State.Run;
        currentWarzone= null;
        playerAnimator.Play("Run");

        Time.timeScale = 1;
    }
}
