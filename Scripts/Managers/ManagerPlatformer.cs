using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

namespace DMBTools
{
    [ExecuteAlways]
    public abstract class PlatformerManager : Manager
    {
        public BoxPlayer player;
        public List<BoxEnemy> enemies;
        Transform cameraTX;
        public Vector2 CollidrSize = new Vector2(32, 24);
        BoxCollider2D collidr;

        public

        new void Start()
        {
            base.Start();
            cameraTX = MainCamera().GetComponent<Transform>();
            collidr = GetComponent<BoxCollider2D>();
            collidr.size = CollidrSize;
        }

        void Update()
        {
            SetCameraPosition();
        }

        void SetCameraPosition()
        {
            Vector3 newPosition;
            if (player.Transform().position.x + player.data.cameraOffset.x <= cameraMinimumPosition.x)
            {
                newPosition = new Vector3
                (
                    cameraMinimumPosition.x,
                    cameraTX.position.y,
                    cameraTX.position.z
                );
                cameraTX.position = newPosition;
                GetComponent<Transform>().position = newPosition;

            }
            else if (player.Transform().position.x + player.data.cameraOffset.x >= cameraMaximumPosition.x)
            {
                newPosition = new Vector3
                (
                    cameraMaximumPosition.x,
                    cameraTX.position.y,
                    cameraTX.position.z
                );

                cameraTX.position = newPosition;
                GetComponent<Transform>().position = newPosition;
            }
            else
            {
                newPosition = new Vector3
                (
                    player.Transform().position.x + player.data.cameraOffset.x,
                    cameraTX.position.y,
                    cameraTX.position.z
                );

                cameraTX.position = newPosition;
                GetComponent<Transform>().position = newPosition;
            }

            if (player.Transform().position.y + player.data.cameraOffset.y <= cameraMinimumPosition.y)
            {
                newPosition = new Vector3
                (
                    cameraTX.position.x,
                    cameraMinimumPosition.y,
                    cameraTX.position.z
                );

                cameraTX.position = newPosition;
                GetComponent<Transform>().position = newPosition;
            }
            else if (player.Transform().position.y + player.data.cameraOffset.y >= cameraMaximumPosition.y)
            {
                newPosition = new Vector3
                (
                    cameraTX.position.x,
                    cameraMaximumPosition.y,
                    cameraTX.position.z
                );

                cameraTX.position = newPosition;
                GetComponent<Transform>().position = newPosition;
            }
            else
            {
                newPosition = new Vector3
                (
                    cameraTX.position.x,
                    player.Transform().position.y + player.data.cameraOffset.y,
                    cameraTX.position.z
                );

                cameraTX.position = newPosition;
                GetComponent<Transform>().position = newPosition;
            }
        }

        void OnTriggerExit2D(Collider2D collision)
        {
            HandleTriggers(collision, TriggerType.Exit);
        }
        void HandleTriggers(Collider2D collision, TriggerType type)
        {
            if
            (
                (
                    collision.gameObject.CompareTag("Enemy") ||
                    collision.gameObject.CompareTag("Player"
                )) &&
                type == TriggerType.Exit
            )
            {
                Object.Destroy(collision.gameObject);
            }
        }
    }
}

