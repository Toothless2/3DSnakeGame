using UnityEngine;
using System.Threading;

namespace Snake
{
    public class LoadPreviousSettings : MonoBehaviour
    {
        public Camera main;
        public GraphicsOptions options;
        public RebindKey bind;

        void Awake()
        {
            main.enabled = false;

            Time.timeScale = 1;

            Debug.Assert(Time.timeScale > 0);

            //print(Constants.firstLoad);

            if (Constants.firstLoad)
            {
                options.FirstLoad();
                options.UpdateSettings();
                options.SaveSettings();
                Constants.firstLoad = false;
            }
            else
            {
                options.FirstLoad();
            }

            bind.LoadKeyBindings();
            main.enabled = true;
        }
    }
}