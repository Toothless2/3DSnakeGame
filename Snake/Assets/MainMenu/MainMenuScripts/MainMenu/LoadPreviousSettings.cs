using UnityEngine;

namespace Snake
{
    public class LoadPreviousSettings : MonoBehaviour
    {
        public Camera camera;
        public GraphicsOptions options;
        public RebindKey bind;

        void Awake()
        {
            camera.enabled = false;
            options.FirstLoad();
            options.UpdateSettings();

            bind.LoadKeyBindings();
            camera.enabled = true;
        }
    }
}