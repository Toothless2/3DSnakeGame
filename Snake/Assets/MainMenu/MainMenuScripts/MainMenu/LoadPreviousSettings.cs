using UnityEngine;

namespace Snake
{
    public class LoadPreviousSettings : MonoBehaviour
    {
        public GraphicsOptions options;
        public RebindKey bind;

        void Start()
        {
            options.FirstLoad();
            options.UpdateSettings();

            bind.LoadKeyBindings();
        }
    }
}