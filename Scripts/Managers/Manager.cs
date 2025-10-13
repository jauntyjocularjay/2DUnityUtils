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
        [SerializeField] protected Vector3 cameraMinimumPosition;
        [SerializeField] protected Vector3 cameraMaximumPosition;
        new protected void Start()
        {
            MainCamera().orthographicSize = size * mapUnitSide;
            MainCamera().GetComponent<Transform>().position = cameraMinimumPosition;
        }
        public Camera MainCamera()
        {
            return Camera.main;
        }
    }

}
