using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public void Active(Vector2 position)
    {
        transform.position = position;
    }
}
