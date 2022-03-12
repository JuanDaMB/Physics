using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Liquid : MonoBehaviour
{
    public float c;
    public float x, y, w, h;
    
    public void SetUp(float _x, float _y, float _w, float _h)
    {
        x = _x;
        y = _y;
        w = _w;
        h = _h;
        transform.position = new Vector2(_x, _y);
        transform.localScale = new Vector2(_w*2, _h*2);
    }
}
