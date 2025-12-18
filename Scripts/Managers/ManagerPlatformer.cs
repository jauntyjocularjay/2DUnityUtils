using System;
using UnityEngine;



namespace DMBTools
{
    [RequireComponent(typeof(Transform))]
    [RequireComponent(typeof(BoxCollider2D))]
    public abstract class PlatformerManager : Manager
    {
        [Tooltip("Defaults to the BoxPlayer in the root.")]
        public BoxPlayer player;
        [Tooltip("Controls the position of the player sprite relative to the Camera.main")]
        public Vector2 playerCameraOffset = Vector2.zero;
        Transform cameraTX;
        CameraInfo _camera_info;
        public CameraInfo CameraInfo
        {
            get => cameraTX.GetComponent<CameraInfo>();
            set => CameraInfo = value;
        }
        [Tooltip("The death collider will trigger a player death ")]
        public Vector2 deathColliderSize = new Vector2(32, 24);
        BoxCollider2D deathCollider;

        new protected void Awake()
        {
            base.Awake();

            SetPlayer();
            cameraTX = MainCamera().GetComponent<Transform>();
            SetCameraPosition();
        }

        new protected void Start()
        {
            base.Start();
            deathCollider = GetComponent<BoxCollider2D>();
            deathCollider.isTrigger = true;
            deathCollider.size = deathColliderSize;
        }
        void SetPlayer()
        {
            if (player == null)
            {
                throw new Exception("Player is not defined. Set your player in the GameManager");
            }
        }

        void Update()
        {
            SetCameraPosition();
        }

        void SetCameraPosition()
        {
            Vector3 newPosition;

            if (player.Transform.position.x + playerCameraOffset.x <= cameraMinimumPosition.x)
            {
                newPosition = new Vector3
                (
                    cameraMinimumPosition.x,
                    cameraTX.position.y,
                    cameraTX.position.z
                );
                cameraTX.position = newPosition;
                Transform.position = newPosition;

            }
            else if (player.Transform.position.x + playerCameraOffset.x >= cameraMaximumPosition.x)
            {
                newPosition = new Vector3
                (
                    cameraMaximumPosition.x,
                    cameraTX.position.y,
                    cameraTX.position.z
                );

                cameraTX.position = newPosition;
                Transform.position = newPosition;
            }
            else
            {
                newPosition = new Vector3
                (
                    player.Transform.position.x + playerCameraOffset.x,
                    cameraTX.position.y,
                    cameraTX.position.z
                );

                cameraTX.position = newPosition;
                Transform.position = newPosition;
            }

            if (player.Transform.position.y + playerCameraOffset.y <= cameraMinimumPosition.y)
            {
                newPosition = new Vector3
                (
                    cameraTX.position.x,
                    cameraMinimumPosition.y,
                    cameraTX.position.z
                );

                cameraTX.position = newPosition;
                Transform.position = newPosition;
            }
            else if (player.Transform.position.y + playerCameraOffset.y >= cameraMaximumPosition.y)
            {
                newPosition = new Vector3
                (
                    cameraTX.position.x,
                    cameraMaximumPosition.y,
                    cameraTX.position.z
                );

                cameraTX.position = newPosition;
                Transform.position = newPosition;
            }
            else
            {
                newPosition = new Vector3
                (
                    cameraTX.position.x,
                    player.Transform.position.y + playerCameraOffset.y,
                    cameraTX.position.z
                );

                cameraTX.position = newPosition;
                Transform.position = newPosition;
            }

            if (!CameraInfo.camera_initial_position_is_set)
            {
                CameraInfo.camera_initial_position = newPosition;
                CameraInfo.camera_initial_position_is_set = true;
            }
        }

        void OnTriggerExit2D(Collider2D collision)
        {
            HandleTrigger(collision, TriggerType.Exit);
        }
        void HandleTrigger(Collider2D collision, TriggerType type)
        {
            if (collision.gameObject.CompareTag("Enemy") ||
                collision.gameObject.CompareTag("Player") &&
                type == TriggerType.Exit)
            {
                UnityEngine.Object.Destroy(collision.gameObject);
            }
        }
        // Unity Editor methods
        void OnRenderObject()
        {
            SetPlayer();
        }
    }

}

