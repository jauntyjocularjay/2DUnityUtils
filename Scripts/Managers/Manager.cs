using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;




namespace DMBTools
{
    public abstract class Manager : DMBMonoBehaviour
    {
        readonly float mapUnitSide = 2.8125f;
        [Header("Camera Orthagonal Size Multiplier")]
        public float size = 2.0f;
        public Scene nextScene;
        public Vector3 cameraMinimumPosition;
        public Vector3 cameraMaximumPosition;

        new protected void Start()
        {
            MainCamera().orthographicSize = size * mapUnitSide;
            MainCamera().GetComponent<Transform>().position = new Vector3(cameraMinimumPosition.x, cameraMinimumPosition.y, Camera.main.transform.position.z);
        }
        public Camera MainCamera()
        {
            return Camera.main;
        }
    }

}
