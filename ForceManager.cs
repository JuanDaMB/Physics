using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class ForceManager : MonoBehaviour
{
    [FormerlySerializedAs("_forces")] [SerializeField] private List<Force> forces;
    [SerializeField] private Vector2 limits;
    [SerializeField] private Vector2 wind, gravity;
    [SerializeField] private float c = 0.5f;
    [SerializeField]private Liquid liquid;

    void Start()
    {
        foreach (Force force in forces)
        {
            force.Initialize();
        }
        liquid.SetUp(0f,-7f, 5f, 4f);
    }

    void Update()
    {
        foreach (Force force in forces)
        {
            Vector2 friction = -1*force.Velocity.normalized*c;

            if (force.IsInside(liquid))
            {
                force.Drag(liquid);
            }
            
            force.ApplyForce(friction);
            force.ApplyForce(wind);
            force.ApplyForce(gravity * force.mass);
            force.UpdateData();
            force.CheckEdges(limits);
        }
    }
}
