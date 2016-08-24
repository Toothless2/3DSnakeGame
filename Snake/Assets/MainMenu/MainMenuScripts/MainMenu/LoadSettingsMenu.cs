using UnityEngine;
using System.Collections;

namespace Snake
{
    public class LoadSettingsMenu : MonoBehaviour
    {
        public GraphicsOptions options;

        void Start()
        {
            options.FirstLoad();
            options.UpdateSettings();
        }
    }
}