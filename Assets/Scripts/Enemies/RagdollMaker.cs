using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RagdollMaker : MonoBehaviour
{
    [SerializeField] private Animator animator; 
    [SerializeField] private Enemy AIenemy;
    [SerializeField] private Navigator AInavigator;
    [SerializeField] private Collider[] enemyColliders;
    [SerializeField] private Collider[] ragdollColliders;
    [SerializeField] private Rigidbody AIRigidbody;
    private Rigidbody[] rigidbodies;

    private void Start() {
        rigidbodies = GetComponentsInChildren<Rigidbody>(); 
        ragdollColliders = GetComponentsInChildren<Collider>(); 
        EnableRagdoll(false);
    }

    public void EnableRagdoll(bool enabled){

        //Ragdoll Stuff
        bool isKinematic = !enabled;
        foreach(Rigidbody rigidbody in rigidbodies){
            rigidbody.isKinematic = isKinematic;
        }
        foreach(Collider collider in ragdollColliders){
            collider.enabled = enabled;
        }
        animator.enabled = !enabled;

        AInavigator.enabled = !enabled;
        AIenemy.enabled = !enabled;
        foreach(Collider col in enemyColliders){
            col.enabled = !enabled;
        }
        AIRigidbody.isKinematic= enabled;


    }



}
