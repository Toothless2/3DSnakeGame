using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Snake
{
    public class RebindKey : MonoBehaviour
    {
        private KeyCode input;

        public Text speedUpButtonText;
        private string originalSpeedUpText;
        private bool rebindSpeedUp;

        public Text speedDownButtonText;
        private string originalSpeedDownText;
        private bool rebindSpeedDown;

        public Slider sensitivitySlider;
        private float originalSensitivity;

        void Update()
        {
            //when a key is pressed is sets the input variable to that keycode
            
            input = KeyCode.None;

            #region RebindSpeedUp
            if (rebindSpeedUp)
            {
                input = Keybindings.CheckForInput();

                if(input != KeyCode.None)
                {
                    rebindSpeedUp = false;
                    originalSpeedUpText = speedUpButtonText.text;
                    speedUpButtonText.text = input.ToString();
                    Constants.speedUp = input;
                }
            }
            #endregion RebindSpeedUp

            #region RebindSpeedDown
            if (rebindSpeedDown)
            {
                input = Keybindings.CheckForInput();

                if (input != KeyCode.None)
                {
                    rebindSpeedDown = false;
                    originalSpeedDownText = speedDownButtonText.text;
                    speedDownButtonText.text = input.ToString();
                    Constants.speedDown = input;
                }
            }
            #endregion RebindSpeedDown
        }

        //Called by Buttons
        public void RebindSpeedUpKey()
        {
            rebindSpeedUp = true;
        }

        public void RebindSpeedDownKey()
        {
            rebindSpeedDown = true;
        }

        //rests the keybindings to the default
        public void ResetKeyBindings()
        {
            sensitivitySlider.value = 5;
            Constants.speedUp = KeyCode.None;
            Constants.speedDown = KeyCode.None;
            
            originalSpeedUpText = "Scroll Up";
            originalSpeedDownText = "Scroll Down";
            speedUpButtonText.text = "Scroll Up";
            speedDownButtonText.text = "Scroll Down";

            SaveKeybindings();
        }

        //loads the keybindings at the start of the game
        public void LoadKeyBindings()
        {
            if (File.Exists(Application.dataPath + "/Resources/Keybindings.dat"))
            {
                //Accessing the file
                BinaryFormatter bf = new BinaryFormatter();
                FileStream fs = new FileStream(Application.dataPath + "/Resources/Keybindings.dat", FileMode.Open, FileAccess.Read);
                SaveKeyBindings bind = new SaveKeyBindings();

                try
                {
                    bind = (SaveKeyBindings)bf.Deserialize(fs);
                }
                catch
                {
                    Debug.LogWarning("Oops cant derialize keybindings");
                }
                finally
                {
                    fs.Close();
                }

                bind.SetBindings();

                #region ApplyToUI
                //Applying the data to the UI
                sensitivitySlider.value = Constants.lookSensitivity;

                if (Constants.speedUp == KeyCode.None)
                {
                    speedUpButtonText.text = "Scroll Up";
                }
                else
                {
                    speedUpButtonText.text = Constants.speedUp.ToString();
                }

                if (Constants.speedDown == KeyCode.None)
                {
                    speedDownButtonText.text = "Scroll Up";
                }
                else
                {
                    speedDownButtonText.text = Constants.speedDown.ToString();
                }
                #endregion ApplyToUI
            }
            else
            {
                SaveKeybindings();
            }
        }

        // saves the keybindings so the they can be used in game
        public void SaveKeybindings()
        {
            originalSpeedUpText = speedUpButtonText.text;
            originalSpeedDownText = speedDownButtonText.text;
            originalSensitivity = sensitivitySlider.value;

            BinaryFormatter bf = new BinaryFormatter();
            FileStream fs = new FileStream(Application.dataPath + "/Resources/Keybindings.dat", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            SaveKeyBindings bind = new SaveKeyBindings((int)sensitivitySlider.value, Constants.speedUp, Constants.speedDown);

            try
            {
                bf.Serialize(fs, bind);
            }
            catch
            {
                Debug.LogWarning("Oops cant serialize keybidnings");
            }
            finally
            {
                fs.Close();
            }

            LoadKeyBindings();
        }

        //Called by Button - goes back to previous menu
        public void Back()
        {
            LoadKeyBindings();
        }
    }

    [System.Serializable]
    public class SaveKeyBindings
    {
        public int lookSensitivity;
        public int speedUp;
        public int speedDown;

        public SaveKeyBindings(int _lookSensitivity, KeyCode _upSpeed, KeyCode _downSpeed)
        {
            lookSensitivity = _lookSensitivity;
            speedUp = (int)_upSpeed;
            speedDown = (int)_downSpeed;
        }

        //Just to make this class easy to access if i dont want to input anything
        public SaveKeyBindings(){}

        public void SetBindings()
        {
            Constants.lookSensitivity = lookSensitivity;
            Constants.speedUp = (KeyCode)speedUp;
            Constants.speedDown = (KeyCode)speedDown;
        }
    }
}