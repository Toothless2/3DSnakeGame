using UnityEngine;
using System.Threading;

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