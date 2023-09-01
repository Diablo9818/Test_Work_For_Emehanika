using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveFlame : MonoBehaviour
{
    [SerializeField] private float _speed;

    void Update()
    {
        float zMovement = _speed * Time.deltaTime;
        transform.Translate(0f, 0f, zMovement);
    }
}
