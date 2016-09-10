using UnityEngine;

namespace Snake
{
    public class UpdateUI : MonoBehaviour
    {
        public GraphicsOptions options;
        public RebindKey bind;

        void Start()
        {
            options.FirstLoad();
            bind.LoadKeyBindings();
        }
    }
}