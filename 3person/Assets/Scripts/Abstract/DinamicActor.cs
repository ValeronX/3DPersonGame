using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DinamicActor : MonoBehaviour
{
    [SerializeField] protected float defaultMoveSpeed = 3f;
    [SerializeField] protected float currentMoveSpeed = 3f;
    [SerializeField, Range(0f, 3f)] protected float sprintMultiplier = 2f;
    [SerializeField] protected float rotationSpeed = 400f;
}
