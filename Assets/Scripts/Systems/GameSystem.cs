using UnityEngine;
using System;
[System.Serializable]
public abstract class GameSystem : MonoBehaviour
{
    public virtual void StartSystem() { }
    public virtual void Restart() { }
}
