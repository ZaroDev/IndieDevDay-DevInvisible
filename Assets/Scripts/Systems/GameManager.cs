using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public List<GameSystem> systems = new List<GameSystem>();
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        foreach (GameSystem child in gameObject.GetComponentsInChildren<GameSystem>())
        {
            systems.Add(child);
        }
    }

    public void Restart()
    {
        foreach (GameSystem system in systems)
        {
            system.Restart();
        }
    }
}
