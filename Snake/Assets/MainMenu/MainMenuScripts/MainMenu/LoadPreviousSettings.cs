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

            Debug.Assert(Time.timeScale != 0);

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
            camera.enabled = true;
        }
    }
}