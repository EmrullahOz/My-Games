using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : singleton<GameManager>
{
    public static GameManager instance;

    [HideInInspector] public bool _ingame;

    public GameObject[] _cubes;
    public GameObject[] _obstacle;
    [HideInInspector] public GameObject _bullets;
    public ParticleSystem[] _partic;

    public GameObject _successPanel;

    private void Awake()
    {
        instance = this;
        _ingame = true;

        _bullets = GameObject.Find("Bullets");
    }
}
