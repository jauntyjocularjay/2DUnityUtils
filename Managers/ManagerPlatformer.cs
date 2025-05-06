using System.Collections.Generic;
using System.Data.Common;
using UnityEngine;
using UnityEngine.SceneManagement;

[ExecuteAlways]
public class PlatformerManager : Manager
{
    public BoxPlayer player;
    public List<BoxEnemy> enemies;
    Transform cameraTX;
    public Vector3 cameraMinimumPosition;
    public Vector3 cameraMaximumPosition;
    void Start()
    {
        cameraTX = MainCamera().GetComponent<Transform>();
    }

    void Update()
    {
        SetCameraPosition();
    }
    void SetCameraPosition()
    {
        
        if( player.Transform().position.x + player.data.cameraOffset.x >= cameraMinimumPosition.x && player.Transform().position.x + player.data.cameraOffset.x <= cameraMaximumPosition.x )
        {
            cameraTX.position = new Vector3(player.Transform().position.x + player.data.cameraOffset.x, cameraTX.position.y, cameraTX.position.z);
        }
        else if (player.Transform().position.x + player.data.cameraOffset.x <= cameraMinimumPosition.x)
        {
            cameraTX.position = new Vector3(cameraMinimumPosition.x, cameraTX.position.y, cameraTX.position.z);
        }
        else if (player.Transform().position.x + player.data.cameraOffset.x >= cameraMaximumPosition.x)
        {
            cameraTX.position = new Vector3(cameraMaximumPosition.x, cameraTX.position.y, cameraTX.position.z);
        }
        
        if( player.Transform().position.y >= cameraMinimumPosition.y && cameraTX.position.y <= cameraMaximumPosition.y )
        {
            cameraTX.position = new Vector3(cameraTX.position.x, player.Transform().position.y + player.data.cameraOffset.y, cameraTX.position.z);
        }
        else if (player.Transform().position.y + player.data.cameraOffset.y >= cameraMinimumPosition.y)
        {
            cameraTX.position = new Vector3(cameraTX.position.x, cameraMinimumPosition.y, cameraTX.position.z);
        }
        else if (player.Transform().position.y + player.data.cameraOffset.y <= cameraMaximumPosition.y)
        {
            cameraTX.position = new Vector3(cameraTX.position.x, cameraMaximumPosition.y, cameraTX.position.z);
        }
        
        if( player.Transform().position.z >= cameraMinimumPosition.z && cameraTX.position.z <= cameraMaximumPosition.z )
        {
            cameraTX.position = new Vector3(cameraTX.position.x, cameraTX.position.y, cameraTX.position.z + player.data.cameraOffset.z);
        }
        else if (player.Transform().position.z >= cameraMinimumPosition.z)
        {
            cameraTX.position = new Vector3(cameraTX.position.x, cameraTX.position.y, cameraMinimumPosition.z);
        }
        else if (player.Transform().position.z <= cameraMaximumPosition.z)
        {
            cameraTX.position = new Vector3(cameraTX.position.x, cameraTX.position.y, cameraMaximumPosition.z);
        }
    }

    
}


