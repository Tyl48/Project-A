using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Moverment))]
public class PlayerDetection : MonoBehaviour
{
    [Header("Elements")]
    [SerializeField] private Moverment playerMovement;

    [Header("Settings")]
    [SerializeField] private float detectionRadius;
    // Start is called before the first frame update
    void Start()
    {
        playerMovement = GetComponent<Moverment>();
    }

    // Update is called once per frame
    void Update()
    {
        DetectStuff();
    }

    private void DetectStuff()
    {
        Collider[] detectedObject = Physics.OverlapSphere(transform.position, detectionRadius);
        foreach(Collider collider in detectedObject)
            //Debug.Log(collider.name);
            if (collider.CompareTag("warzone trigger"))
                EnterWarzoneCallBack(collider);

    }
    private void EnterWarzoneCallBack(Collider warzoneTriggerCollider)
    {
        Warzone warzone = warzoneTriggerCollider.GetComponentInParent<Warzone>();
        playerMovement.EnterWarzoneCallback(warzone);    
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);
    }

}
