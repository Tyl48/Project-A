using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Splines;

public class Warzone : MonoBehaviour
{

    [Header("Elements")]
    [SerializeField] private SplineContainer playerSpline;

    [Header("settings")]
    [SerializeField] private float Duration;

    [Header("anim Name")]
    [SerializeField] private string animationToPlay;

    [SerializeField] private float animSpeed;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
         
    }

    public Spline GetPlayerSpline()
    {
        return playerSpline.Spline;
    }

    public float GetDuration()
    {
        return Duration;
    }

    public string GetAnimationToPlay()
    {
        return animationToPlay;
    }

    public float GetAnimatorSpeed()
    {
        return animSpeed;
    }
}
