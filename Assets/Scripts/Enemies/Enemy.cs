using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(Navigator))]
public class Enemy : MonoBehaviour
{
    protected Navigator _navigator => GetComponent<Navigator>();

}