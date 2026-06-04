using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;




namespace DMBTools
{
    public abstract class Manager : DMBMonoBehaviour
    {
        static readonly float mapUnitSide = 2.8125f;
        [Header("Camera Orthagonal Size Multiplier")]
        static float size = 2.0f;
        public Scene nextScene;
        public static Vector3 cameraMinimumPosition;
        public static Vector3 cameraMaximumPosition;

        public static void SetupCamera()
        // Public to pass information to the ManagerInspector
        {
            Camera.main.orthographicSize = size * Manager.mapUnitSide;
            Camera.main.GetComponent<Transform>().position = new Vector3(cameraMinimumPosition.x, cameraMinimumPosition.y, Camera.main.transform.position.z);
        }
    }

}
