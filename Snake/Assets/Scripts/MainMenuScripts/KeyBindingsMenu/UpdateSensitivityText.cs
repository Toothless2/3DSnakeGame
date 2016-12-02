using UnityEngine;
using UnityEngine.UI;

namespace Snake
{
    public class UpdateSensitivityText : MonoBehaviour
    {
        public Slider sensitivitySlider;

        void Update()
        {
            GetComponent<Text>().text = sensitivitySlider.value.ToString();
        }
    }
}