using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attractor : MonoBehaviour
{  
    public float mass;
    public Vector2 location;
    public float G, minDis, maxDis;
 
    public void SetUp() {
        location = new Vector2(0f,0f);
        mass = 20;
    }
    public Vector2 Attract(Force m)
    {
        Vector2 force = (location-m.Position);
        float distance = force.magnitude;

        distance = Mathf.Clamp(distance, minDis, maxDis);
        
        force.Normalize();
        float strength = (G * mass * m.mass) / (distance * distance);
        force*=(strength);
        return force;
    }
    
}
