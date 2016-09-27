using UnityEngine;
using UnityEngine.UI;
using LitJson;
using System.IO;

namespace Snake
{
    public class ApplyUserName : MonoBehaviour
    {
        public GameObject mainMenu;
        public InputField userNameInput;

        void Start()
        {
            GetUserName();
        }

        public void UpdateUserName()
        {
            bool applyname = false;

            if(userNameInput.text.Length > 1)
            {
                for (int i = 0; i < ProfanityList.PrfanityFilter.Length; i++)
                {
                    if (userNameInput.text == ProfanityList.PrfanityFilter[i])
                    {
                        userNameInput.text = "pick a different name";
                        applyname = false;
                        break;
                    }
                    else
                    {
                        applyname = true;
                    }
                }
            }

            if(applyname)
            {
                //chescks for names that are already in use
                if (CheckUserNames(userNameInput.text, Highscores.currentUserNames))
                {
                    ApplyuserName();
                }
                else
                {
                    userNameInput.text = "Name is already in use";
                }
            }
        }

        bool CheckUserNames(string desiredName, string[] currentNames)
        {
            for (int i = 0; i < currentNames.Length; i++)
            {
                if(desiredName == currentNames[i])
                {
                    return false;
                }
            }

            return true;
        }

        void ApplyuserName()
        {
            SaveUserName();
            UserName.userName = userNameInput.text;

            mainMenu.SetActive(true);
            gameObject.SetActive(false);
        }

        public void SaveUserName()
        {
            UserName username = new UserName(userNameInput.text);

            File.WriteAllText(Application.dataPath + "/Resources/Username.json", JsonMapper.ToJson(username));
        }

        public void GetUserName()
        {
            if(File.Exists(Application.dataPath + "/Resources/Username.json"))
            {
                string username;
                JsonData usernameJson;

                username = File.ReadAllText(Application.dataPath + "/Resources/Username.json");

                usernameJson = JsonMapper.ToObject(username);
                
                UserName.userName = usernameJson["userName"].ToString();

                mainMenu.SetActive(true);
                gameObject.SetActive(false);
            }
        }

        public void ChangeUserName()
        {
            mainMenu.SetActive(false);
            gameObject.SetActive(true);
        }
    }
}
