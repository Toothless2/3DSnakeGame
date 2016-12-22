using UnityEngine;
using UnityEngine.UI;
//TODO Remove After a couple of versions
using LitJson;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

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
                    ApplyUsername();
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

        void ApplyUsername()
        {
            SaveUserName();
            Constants.username = userNameInput.text;

            mainMenu.SetActive(true);
            gameObject.SetActive(false);
        }

        public void SaveUserName()
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream fs = new FileStream(Application.persistentDataPath + "/Username.dat", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            Username username = new Username(userNameInput.text);

            bf.Serialize(fs, username);
        }

        //TODO Remove after a couple of versions
        void SaveUserNameFromJSON(string _username)
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream fs = new FileStream(Application.persistentDataPath + "/Username.dat", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            Username username = new Username(_username);

            bf.Serialize(fs, username);

            Constants.username = _username;
        }

        //Gets the user name
        public void GetUserName()
        {
            //Old Format
            if(File.Exists(Application.persistentDataPath + "/Username.json"))
            {
                string username;
                JsonData usernameJson;

                username = File.ReadAllText(Application.persistentDataPath + "/Username.json");

                usernameJson = JsonMapper.ToObject(username);

                SaveUserNameFromJSON(usernameJson["userName"].ToString());
                
                File.Delete(Application.persistentDataPath + "/Username.json");

                mainMenu.SetActive(true);
                gameObject.SetActive(false);
            }
            //New Format
            else if(File.Exists(Application.persistentDataPath + "/Username.dat"))
            {
                BinaryFormatter bf = new BinaryFormatter();
                FileStream fs = new FileStream(Application.persistentDataPath + "/Username.dat", FileMode.Open, FileAccess.Read);
                Username username = new Username();

                username = (Username)bf.Deserialize(fs);
                fs.Close();

                Constants.username = username.username;
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

    [System.Serializable]
    public class Username
    {
        public string username;

        public Username(string _name)
        {
            username = _name;
        }

        public Username(){}
    }
}
