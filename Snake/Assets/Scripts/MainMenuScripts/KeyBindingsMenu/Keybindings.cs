using UnityEngine;

namespace Snake
{
    public class Keybindings
    {
        public static KeyCode input;

        public static KeyCode CheckForInput()
        {
            string inputString;
            char character;

            #region NumpadKeys
            if (Input.GetKeyDown(KeyCode.Alpha0))
            {
                input = KeyCode.Alpha0;
            }
            else if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                input = KeyCode.Alpha1;
            }
            else if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                input = KeyCode.Alpha2;
            }
            else if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                input = KeyCode.Alpha3;
            }
            else if (Input.GetKeyDown(KeyCode.Alpha4))
            {
                input = KeyCode.Alpha4;
            }
            else if (Input.GetKeyDown(KeyCode.Alpha5))
            {
                input = KeyCode.Alpha5;
            }
            else if (Input.GetKeyDown(KeyCode.Alpha6))
            {
                input = KeyCode.Alpha6;
            }
            else if (Input.GetKeyDown(KeyCode.Alpha7))
            {
                input = KeyCode.Alpha7;
            }
            else if (Input.GetKeyDown(KeyCode.Alpha8))
            {
                input = KeyCode.Alpha8;
            }
            else if (Input.GetKeyDown(KeyCode.Alpha9))
            {
                input = KeyCode.Alpha9;
            }
            else if (Input.GetKeyDown(KeyCode.KeypadDivide))
            {
                input = KeyCode.KeypadDivide;
            }
            else if (Input.GetKeyDown(KeyCode.KeypadEnter))
            {
                input = KeyCode.KeypadEnter;
            }
            else if (Input.GetKeyDown(KeyCode.KeypadMinus))
            {
                input = KeyCode.KeypadMinus;
            }
            else if (Input.GetKeyDown(KeyCode.KeypadMultiply))
            {
                input = KeyCode.KeypadMultiply;
            }
            else if (Input.GetKeyDown(KeyCode.KeypadPeriod))
            {
                input = KeyCode.KeypadPeriod;
            }
            else if (Input.GetKeyDown(KeyCode.KeypadPlus))
            {
                input = KeyCode.KeypadPlus;
            }
            #endregion NumpadKeys
            #region NormalCharacterInput
            else if (Input.inputString != "")
            {
                inputString = Input.inputString;

                character = inputString[0];
                input = (KeyCode)character;
            }
            #endregion NormalCharcterInput
            #region ShiftKeys
            else if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                input = KeyCode.LeftShift;
            }
            else if (Input.GetKeyDown(KeyCode.RightShift))
            {
                input = KeyCode.RightShift;
            }
            #endregion ShiftKeys
            #region ControlKeys
            else if (Input.GetKeyDown(KeyCode.LeftControl))
            {
                input = KeyCode.LeftControl;
            }
            else if (Input.GetKeyDown(KeyCode.RightControl))
            {
                input = KeyCode.RightControl;
            }
            #endregion ControlKeys
            #region MouseButtons
            else if (Input.GetMouseButtonDown(0))
            {
                input = KeyCode.Mouse0;
            }
            else if (Input.GetMouseButtonDown(1))
            {
                input = KeyCode.Mouse1;
            }
            else if (Input.GetMouseButtonDown(2))
            {
                input = KeyCode.Mouse2;
            }
            else if (Input.GetMouseButtonDown(3))
            {
                input = KeyCode.Mouse3;
            }
            else if (Input.GetMouseButtonDown(4))
            {
                input = KeyCode.Mouse4;
            }
            else if (Input.GetMouseButtonDown(5))
            {
                input = KeyCode.Mouse5;
            }
            else if (Input.GetMouseButtonDown(6))
            {
                input = KeyCode.Mouse6;
            }
            #endregion MouseButtons
            #region ArrowKeys
            else if(Input.GetKeyDown(KeyCode.UpArrow))
            {
                input = KeyCode.UpArrow;
            }
            else if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                input = KeyCode.DownArrow;
            }
            else if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                input = KeyCode.RightArrow;
            }
            else if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                input = KeyCode.LeftArrow;
            }
            #endregion ArrowKeys
            #region AltKeys
            else if (Input.GetKeyDown(KeyCode.LeftAlt))
            {
                input = KeyCode.LeftAlt;
            }
            else if(Input.GetKeyDown(KeyCode.RightAlt))
            {
                input = KeyCode.LeftAlt;
            }
            #endregion AltKeys
            #region MiscKeys
            else if(Input.GetKeyDown(KeyCode.AltGr))
            {
                input = KeyCode.AltGr;
            }
            else if(Input.GetKeyDown(KeyCode.Insert))
            {
                input = KeyCode.Insert;
            }
            else if (Input.GetKeyDown(KeyCode.Home))
            {
                input = KeyCode.Home;
            }
            else if (Input.GetKeyDown(KeyCode.Delete))
            {
                input = KeyCode.Delete;
            }
            else if (Input.GetKeyDown(KeyCode.End))
            {
                input = KeyCode.End;
            }
            else if (Input.GetKeyDown(KeyCode.PageUp))
            {
                input = KeyCode.PageUp;
            }
            else if (Input.GetKeyDown(KeyCode.PageDown))
            {
                input = KeyCode.PageDown;
            }
            #region PlatformSpecific
            else if(Input.GetKeyDown(KeyCode.LeftWindows))
            {
                input = KeyCode.LeftWindows;
            }
            else if(Input.GetKeyDown(KeyCode.RightWindows))
            {
                input = KeyCode.RightWindows;
            }
            else if(Input.GetKeyDown(KeyCode.LeftApple))
            {
                input = KeyCode.LeftApple;
            }
            else if (Input.GetKeyDown(KeyCode.RightApple))
            {
                input = KeyCode.RightApple;
            }
            #endregion PlatformSpecific
            #endregion MiscKeys
            #region NoInput
            else
            {
                input = KeyCode.None;
            }
            #endregion NoInput

            return input;
        }
    }
}