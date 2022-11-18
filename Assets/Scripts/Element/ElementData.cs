using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElementData : MonoBehaviour
{
    [SerializeField] Element _element;

    public Element Element { get => _element; }
}
