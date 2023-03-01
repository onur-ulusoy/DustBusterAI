using UnityEngine;

public class TspCity
{
    public Vector3 Position { get; set; }
    public int Number;
    public int Order;
    public GameObject go;
    public TspCity prev;
    public TspCity next;
}