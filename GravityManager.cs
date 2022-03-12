using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class GravityManager : MonoBehaviour
{
    [SerializeField] private Attractor attractor;
    [SerializeField] private Force force;
    
    void Start()
    {
        force.Initialize();
    }
    
    void Update()
    {
        Vector2 f = attractor.Attract(force);
        force.ApplyForce(f);
        force.UpdateData();
    }
}
