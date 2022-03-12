using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Force : MonoBehaviour
{
    public float mass;
    private Vector2 _velocity, _acceleration, _position;

    public Vector2 Velocity => _velocity;

    public Vector2 Position => _position;

    public void Initialize()
    {
        _position = transform.position;
        _velocity = new Vector2(0f, -5f);
    }

    public void UpdateData()
    {
        _velocity += _acceleration * Time.deltaTime;
        _position += _velocity * Time.deltaTime;
        transform.position = _position;
        _acceleration *= 0f;
    }

    public void ApplyForce(Vector2 force)
    {
        _acceleration += force / mass;
    }

    public void CheckEdges(Vector2 limit)
    {
        if (Mathf.Abs(transform.position.x)>limit.x)
        {
            _position = new Vector2(limit.x * Mathf.Sign(_position.x), _position.y);
            transform.position = _position;
            _velocity = new Vector2(Mathf.Abs(_velocity.x)*-Mathf.Sign(_velocity.x), _velocity.y);
        }
        if (Mathf.Abs(transform.position.y)>limit.y)
        {
            _position = new Vector2(_position.x, limit.y * Mathf.Sign(_position.y));
            transform.position = _position;
            _velocity = new Vector2(_velocity.x, Mathf.Abs(_velocity.y)*-Mathf.Sign(_velocity.y));
        }
    }
    
    public void Drag(Liquid l)
    {
        float speed = _velocity.magnitude;
        float dragMagnitude = l.c * speed * speed;
 
        Vector2 drag = -1*_velocity;
        drag.Normalize();
        drag *= dragMagnitude;

        ApplyForce(drag);
    }
    
    public bool IsInside(Liquid l)
    {
        return _position.x>l.x-l.w && _position.x<l.x+l.w && _position.y>l.y-l.h && _position.y<l.y+l.h;
    }
}
