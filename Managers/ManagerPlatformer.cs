using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[ExecuteAlways]
public class PlatformerManager : Manager
{
    public BoxCharacter player;
    public List<BoxCharacter> enemies;
    Transform cameraTX;
    void Start()
    {
        cameraTX = MainCamera().GetComponent<Transform>();
    }
}


