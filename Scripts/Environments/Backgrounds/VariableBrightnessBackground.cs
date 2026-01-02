using UnityEngine;



namespace DMBTools
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class VariableBrightness : MonoBehaviour
    {
        // Required Components
        SpriteRenderer SpriteRenderer { get => GetComponent<SpriteRenderer>(); }

        // Variable Declaration
        [Tooltip("The increments represent the number of changes of color over the course of the level. Default: 255")]
        public int increments = 255;
        FractionScale levelProgress;
        public Color startColor; // Make Private when finished
        [Tooltip("The TargetColor is the color your sprite will eventually reach as the player progresses through the level. Default: Color.black")]
        public Color targetColor = Color.black;
        [Tooltip("The levelEnd is the BoxCollider2D the player triggers to move on to the next level.")]
        Transform playerTransform;
        float levelHypotenuse;

        void Start()
        {
            startColor = SpriteRenderer.color;
            levelProgress = new FractionScale(0, increments);
            playerTransform = FindFirstObjectByType<BoxPlayer>().GetComponent<Transform>();
            if (playerTransform == null) throw new System.Exception("VariableBrightness Player Character undefined in the scene.");
            Manager manager = FindFirstObjectByType<Manager>();
            levelHypotenuse = FindHypotenuse(manager.cameraMinimumPosition, manager.cameraMaximumPosition);
        }
        void FixedUpdate()
        {




        }

        float FindHypotenuse(Vector2 start, Vector2 end)
        {
            return
            (
                Mathf.Sqrt
                (
                    Mathf.Pow(end.x - start.x, 2.0f) +
                    Mathf.Pow(end.y - start.y, 2.0f)
                )
            );
        }
    }
}