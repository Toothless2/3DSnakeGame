using UnityEngine;
using UnityEngine.UI;

namespace RougeLike3D
{
    public class UpdateFOVNumber : MonoBehaviour
    {
        public Slider slider;

        void Start()
        {
            GetComponent<Text>().text = slider.value.ToString();
        }

        public void UpdateText()
        {
            GetComponent<Text>().text = slider.value.ToString();
        }
    }
}