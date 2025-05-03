using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[ExecuteAlways]
public class PlatformerManager : Manager
{
    public BoxPlayer player;
    public List<BoxEnemy> enemies;
    Transform cameraTX;
    void Start()
    {
        cameraTX = MainCamera().GetComponent<Transform>();
    }
}


