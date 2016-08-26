using UnityEngine;
using System.Collections;

namespace Snake
{
	public class Keybindings : MonoBehaviour {

        string input;
        char character;

		void Start ()
		{
			
		}
	
		void Update ()
		{
            if(Input.inputString != "")
            {
                print(Input.inputString);

                input = Input.inputString;

                character = input[0];

                print(character);
                print((KeyCode)character);
            }

            if(Input.GetMouseButton(0))
            {
                print(KeyCode.Mouse0);
            }
		}

		void OnEnable()
		{
			
		}

		void OnDisbale()
		{
			
		}

		void SetInitialRefernces()
		{
			
		}
	}
}