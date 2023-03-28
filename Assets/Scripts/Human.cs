using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Human : MonoBehaviour
{
    [SerializeField] private Transform _fixationPoint;

    // свойство =>  позволяет читать публичные переменные, но не перезаписывать их
     public Transform FixationPoint => _fixationPoint;


}
