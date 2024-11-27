using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    protected Status status;

    protected void Awake()
    {
        status = GetComponent<Status>();
    }
}
