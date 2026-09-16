using System;
using UnityEngine;



namespace DMBTools
{
    [RequireComponent(typeof(Transform))]
    [RequireComponent(typeof(BoxCollider2D))]
    [RequireComponent(typeof(AudioSource))]
    public abstract class PlatformerManager : MonoBehaviour
    {
        [SerializeField] AudioSource _audioSource;
        public AudioSource AudioSource { get => _audioSource; }
        public Vector3 cameraMinimumPosition;
        public Vector3 cameraMaximumPosition;
        [Tooltip("Defaults to the BoxPlayer in the root.")]
        public Transform playerTransform;
        [Tooltip("Controls the position of the player sprite relative to the Camera.main")]
        public Vector2 playerCameraOffset = Vector2.zero;
        public float cameraFollowFactor = 0.1f;
        Transform cameraTX;

        [Tooltip("The death collider will trigger a player death ")]
        public Vector2 deathColliderSize = new Vector2(32, 24);
        BoxCollider2D deathCollider;

        protected void Awake()
        {
            SetPlayer();
            cameraTX = Camera.main.GetComponent<Transform>();
            SetCameraPosition();
            deathCollider = GetComponent<BoxCollider2D>();
            deathCollider.isTrigger = true;
        }

        protected void Start()
        {
            deathCollider = GetComponent<BoxCollider2D>();
            deathCollider.isTrigger = true;
            deathCollider.size = deathColliderSize;

            _audioSource = GetComponent<AudioSource>();
            if(cameraFollowFactor < 0.0f) cameraFollowFactor = 0.0f;
            else if(cameraFollowFactor > 1.0f) cameraFollowFactor = 1.0f;
        }
        void SetPlayer()
        {
            if (playerTransform == null)
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

            if (playerTransform.position.x + playerCameraOffset.x <= cameraMinimumPosition.x)
            {
                newPosition = new Vector3
                (
                    cameraMinimumPosition.x,
                    cameraTX.position.y,
                    cameraTX.position.z
                );

            }
            else if (playerTransform.position.x + playerCameraOffset.x >= cameraMaximumPosition.x)
            {
                newPosition = new Vector3
                (
                    cameraMaximumPosition.x,
                    cameraTX.position.y,
                    cameraTX.position.z
                );
            }
            else
            {
                newPosition = new Vector3
                (
                    playerTransform.position.x + playerCameraOffset.x,
                    cameraTX.position.y,
                    cameraTX.position.z
                );
            }

            if (playerTransform.position.y + playerCameraOffset.y <= cameraMinimumPosition.y)
            {
                newPosition = new Vector3
                (
                    newPosition.x,
                    cameraMinimumPosition.y,
                    cameraTX.position.z
                );
            }
            else if (playerTransform.position.y + playerCameraOffset.y >= cameraMaximumPosition.y)
            {
                newPosition = new Vector3
                (
                    newPosition.x,
                    cameraMaximumPosition.y,
                    cameraTX.position.z
                );
            }
            else
            {
                newPosition = new Vector3
                (
                    newPosition.x,
                    playerTransform.position.y + playerCameraOffset.y,
                    cameraTX.position.z
                );
            }

            cameraTX.position = Vector3.Lerp(cameraTX.position, newPosition, cameraFollowFactor);
            transform.position = Vector3.Lerp(transform.position, newPosition, cameraFollowFactor);

        }

        void OnTriggerExit2D(Collider2D collision)
        {
            HandleTrigger(collision, TriggerType.Exit);
        }
        void HandleTrigger(Collider2D collision, TriggerType type)
        {
            if (collision.gameObject.layer == LayerIndex.Enemy ||
                collision.gameObject.layer == LayerIndex.Player &&
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

