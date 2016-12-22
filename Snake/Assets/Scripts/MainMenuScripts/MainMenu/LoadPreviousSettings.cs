using UnityEngine;

namespace Snake
{
    public class LoadPreviousSettings : MonoBehaviour
    {
        public GameObject snow;
        public Camera main;
        public GraphicsOptions options;
        public RebindKey bind;

        void Awake()
        {
            main.enabled = false;
            
            Time.timeScale = 1;

            Debug.Assert(Time.timeScale > 0);

            //print(Constants.firstLoad);

            if(Random.Range(0, 100) < Random.Range(0, 10))
            {
                snow.SetActive(true);
                Constants.snowing = true;
            }

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