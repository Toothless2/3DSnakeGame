using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using LitJson;
using System.IO;

namespace Snake
{
    public class RebindKey : MonoBehaviour
    {
        private KeyCode input;

        public Text speedUpButtonText;
        private string originalSpeedUpText;
        private bool rebindSpeedUp;
        private KeyCode tempSpeedUp;

        public Text speedDownButtonText;
        private string originalSpeedDownText;
        private bool rebindSpeedDown;
        private KeyCode tempSpeedDown;

        public Slider sensitivitySlider;
        private float originalSensitivity;

        void Start()
        {
            originalSensitivity = sensitivitySlider.value;
            originalSpeedUpText = speedUpButtonText.text;
            originalSpeedDownText = speedDownButtonText.text;
        }

        void Update()
        {
            input = KeyCode.None;

            if(rebindSpeedUp)
            {
                input = Keybindings.CheckForInput();

                if(input != KeyCode.None)
                {
                    rebindSpeedUp = false;
                    originalSpeedUpText = speedUpButtonText.text;
                    speedUpButtonText.text = input.ToString();
                    tempSpeedUp = input;
                }
            }
            
            if(rebindSpeedDown)
            {
                input = Keybindings.CheckForInput();

                if (input != KeyCode.None)
                {
                    rebindSpeedDown = false;
                    originalSpeedDownText = speedDownButtonText.text;
                    speedDownButtonText.text = input.ToString();
                    tempSpeedDown = input;
                }
            }
        }

        public void RebindSpeedUpKey()
        {
            rebindSpeedUp = true;
            tempSpeedUp = KeyCode.None;
        }

        public void RebindSpeedDownKey()
        {
            rebindSpeedDown = true;
            tempSpeedDown = KeyCode.None;
        }

        public void ResetKeyBindings()
        {
            sensitivitySlider.value = 5;
            CurrentKeybindings.speedUp = KeyCode.None;
            CurrentKeybindings.speedDown = KeyCode.None;
            
            originalSpeedUpText = "Scroll Up";
            originalSpeedDownText = "Scroll Down";
            speedUpButtonText.text = "Scroll Up";
            speedDownButtonText.text = "Scroll Down";

            SaveKeybindings();
        }

        public void LoadKeyBindings()
        {
            if (File.Exists(Application.dataPath + "/Resources/Settings.json"))
            {
                string jsonData;
                JsonData bindingsJson;

                //the data from the json file is put into a string
                jsonData = File.ReadAllText(Application.dataPath + "/Resources/Keybindings.json");

                //the json data is formatted into a dictionary
                bindingsJson = JsonMapper.ToObject(jsonData);

                sensitivitySlider.value = CurrentKeybindings.lookSensitivity = (int)bindingsJson["lookSensitivity"];

                CurrentKeybindings.speedUp = (KeyCode)((int)bindingsJson["speedUp"]);

                if (CurrentKeybindings.speedUp == KeyCode.None)
                {
                    speedUpButtonText.text = "Scroll Up";
                }
                else
                {
                    speedUpButtonText.text = CurrentKeybindings.speedUp.ToString();
                }

                CurrentKeybindings.speedDown = (KeyCode)((int)bindingsJson["speedDown"]);

                if (CurrentKeybindings.speedDown == KeyCode.None)
                {
                    speedUpButtonText.text = "Scroll Up";
                }
                else
                {
                    speedUpButtonText.text = CurrentKeybindings.speedUp.ToString();
                }
            }
        }

        public void SaveKeybindings()
        {
            CurrentKeybindings.lookSensitivity = (int)sensitivitySlider.value;
            CurrentKeybindings.speedUp = tempSpeedUp;
            CurrentKeybindings.speedDown = tempSpeedDown;
            
            originalSpeedUpText = speedUpButtonText.text;
            originalSpeedDownText = speedDownButtonText.text;
            originalSensitivity = sensitivitySlider.value;

            CurrentKeybindings curret = new CurrentKeybindings((int)sensitivitySlider.value, CurrentKeybindings.speedUp, CurrentKeybindings.speedDown);

            //makes a JsonData object to that the variabls of the class can be converted
            JsonData bindingsJson;

            //converts the settings into JsonData
            bindingsJson = JsonMapper.ToJson(curret);

            //writes the JsonData File
            File.WriteAllText(Application.dataPath + "/Resources/Keybindings.json", bindingsJson.ToString());
        }

        public void Back()
        {
            sensitivitySlider.value = originalSensitivity;
            speedUpButtonText.text = originalSpeedUpText;
            speedDownButtonText.text = originalSpeedDownText;

            tempSpeedUp = KeyCode.None;
            tempSpeedDown = KeyCode.None;
        }
    }
}