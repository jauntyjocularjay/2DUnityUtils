using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;




namespace DMBTools
{
    public abstract class Manager : DMBMonoBehaviour
    {
        // static readonly float mapUnitSide = 2.8125f;
        [Header("Camera Orthagonal Size Multiplier")]
        // static float size = 2.0f;
        public Scene nextScene;
        public Vector3 cameraMinimumPosition;
        public Vector3 cameraMaximumPosition;
    }

}
