using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RagdollController : MonoBehaviour
{
    private Rigidbody[] rigidbodies;
    private CharacterJoint[] characterJoints;
    private Collider[] colliders;
    private Animator anim;

    void Awake()
    {
        anim = GetComponent<Animator>();
        rigidbodies = GetComponentsInChildren<Rigidbody>();
        characterJoints = GetComponentsInChildren<CharacterJoint>();
        colliders = GetComponentsInChildren<Collider>();
    }

    public void EnableRagdoll()
    {
        anim.enabled = false;

        foreach (Rigidbody rb in rigidbodies)
        {
            rb.velocity = Vector3.zero;
            rb.detectCollisions = true;
            rb.useGravity = true;
        }
        foreach (CharacterJoint cj in characterJoints)
        {
            cj.enableCollision = true;
        }
        foreach (Collider col in colliders)
        {
            col.enabled = true;
        }
    }

    public void EnableAnimator()
    {
        anim.enabled = true;

        foreach (Rigidbody rb in rigidbodies)
        {
            rb.detectCollisions = false;
            rb.useGravity = false;
        }
        foreach (CharacterJoint cj in characterJoints)
        {
            cj.enableCollision = false;
        }
        foreach (Collider col in colliders)
        {
            col.enabled = false;
        }

        GetComponent<Rigidbody>().detectCollisions = true;
        GetComponent<Rigidbody>().useGravity = true;
        GetComponent<CapsuleCollider>().enabled = true;
    }
}
