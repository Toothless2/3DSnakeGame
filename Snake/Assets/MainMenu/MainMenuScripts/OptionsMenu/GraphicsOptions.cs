using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.IO;
using LitJson;

namespace Snake
{
    public class GraphicsOptions : MonoBehaviour
    {
        //current vaule
        int currentResolution;
        int currentRefreshRate;
        int currentVSyncOption;
        int currentTextureQuality;
        int currentAAOption;
        int currentAFOption;
        int currentFOVoption;

        //is the Game Fulscreen?
        public bool fullscreen = true;
        public Toggle fullscreenToggleButton;

        //varables to do with resolution
        public Dropdown resolutionDropdown;
        Resolution[] resolutions;

        //refreshrate
        public Dropdown refreshRateDropdown;
        int[] refreshRates = new int[3];

        //VSync
        public Dropdown vSyncDropdown;
        string[] vSyncOptions = new string[3];

        //TexQ
        public Dropdown textureQualityDropdown;
        string[] textureQOptions = new string[4];

        //AA
        public Dropdown aADropdown;
        int[] aAOptions = new int[4];

        //Anisotropic
        public Dropdown anisotropicDropdown;
        string[] anisotropicOptions = new string[3];

        //FOV options
        public Slider fOVSlider;
        
        public void FirstLoad()
        {
            SetResolutions();

            if(Screen.fullScreen)
            {
                fullscreen = true;
                fullscreenToggleButton.isOn = true;
            }
            else
            {
                fullscreen = false;
                fullscreenToggleButton.isOn = false;
            }

            RefreshRate();
            VSyncOptions();
            TextureQuality();
            AA();
            AnisotropicFiltering();
            FOV();

            //loads the settings if the settings file exists
            LoadSettings();
        }

        public void ToggleFullscreen()
        {
            fullscreen = !fullscreen;
        }

        //gets all of the resolutions avaliable the user
        void SetResolutions()
        {
            resolutionDropdown.ClearOptions();

            resolutions = Screen.resolutions;

            foreach(Resolution resolution in resolutions)
            {
                string resolutionText = resolution.width + " x " + resolution.height + " @ " + resolution.refreshRate + "Hz";
                resolutionDropdown.options.Add(new Dropdown.OptionData() { text = resolutionText });
            }

            resolutionDropdown.value = resolutions.Length;
        }

        //sets the default refresh rate
        void RefreshRate()
        {
            refreshRateDropdown.ClearOptions();

            refreshRates[0] = 30;
            refreshRates[1] = 60;
            refreshRates[2] = 144;

            foreach(int refresh in refreshRates)
            {
                refreshRateDropdown.options.Add(new Dropdown.OptionData() { text = (refresh.ToString() + " Hz") });
            }
            
            refreshRateDropdown.value = 1;
        }

        //sets the VSync options defult to every VBlank
        void VSyncOptions()
        {
            vSyncDropdown.ClearOptions();

            vSyncOptions[0] = "No VSync";
            vSyncOptions[1] = "Every Vertical Blank";
            vSyncOptions[2] = "Every Second Vertical Blank";

            foreach(string vsopt in vSyncOptions)
            {
                vSyncDropdown.options.Add(new Dropdown.OptionData() { text = vsopt });
            }

            vSyncDropdown.value = 1;
        }

        //sets the maximum mitmap level for textures
        void TextureQuality()
        {
            textureQualityDropdown.ClearOptions();

            textureQOptions[0] = "Full Resolution";
            textureQOptions[1] = "Half Resolution";
            textureQOptions[2] = "Quarter Resolution";
            textureQOptions[3] = "Eighth Resolution";

            foreach(string tQOpt in textureQOptions)
            {
                textureQualityDropdown.options.Add(new Dropdown.OptionData() { text = tQOpt });
            }

            textureQualityDropdown.value = 1;
            textureQualityDropdown.value = 0;
        }

        //sets the dropdown for AA with the default level of 2x MSAA
        void AA()
        {
            aADropdown.ClearOptions();

            aAOptions[0] = 0;
            aAOptions[1] = 2;
            aAOptions[2] = 4;
            aAOptions[3] = 8;

            foreach(int aALvl in aAOptions)
            {
                if(aALvl == 0)
                {
                    aADropdown.options.Add(new Dropdown.OptionData() { text = "Disabled" });
                }
                else
                {
                    aADropdown.options.Add(new Dropdown.OptionData() { text = aALvl.ToString() + "x MSAA" });
                }
            }

            aADropdown.value = 1;
        }

        //sets the dropdown for the AF options with a default level of all textures
        void AnisotropicFiltering()
        {
            anisotropicDropdown.ClearOptions();

            anisotropicOptions[0] = "Disabled";
            anisotropicOptions[1] = "Forground Only";
            anisotropicOptions[2] = "All Textures";

            foreach(string aF in anisotropicOptions)
            {
                anisotropicDropdown.options.Add(new Dropdown.OptionData() { text = aF });
            }

            anisotropicDropdown.value = 2;
        }

        public void FOV()
        {
            Settings.FOV = (int)fOVSlider.value;
        }

        public void ResetToPrevious()
        {
            fullscreenToggleButton.isOn = fullscreen;
            refreshRateDropdown.value = currentRefreshRate;
            resolutionDropdown.value = currentResolution;
            vSyncDropdown.value = currentVSyncOption;
            textureQualityDropdown.value = currentTextureQuality;
            currentAAOption = aADropdown.value;
            currentAFOption = anisotropicDropdown.value;
        }

        public void UpdateSettings()
        {
            //sets the fullscreen
            Screen.fullScreen = fullscreen;
            //sets the resolution and the refresh rate
            Screen.SetResolution(resolutions[resolutionDropdown.value].width, resolutions[resolutionDropdown.value].height, fullscreen, refreshRates[refreshRateDropdown.value]);

            //sets the quality settings
            QualitySettings.vSyncCount = vSyncDropdown.value;
            QualitySettings.masterTextureLimit = textureQualityDropdown.value;
            QualitySettings.antiAliasing = aAOptions[aADropdown.value];
            QualitySettings.anisotropicFiltering = (AnisotropicFiltering)anisotropicDropdown.value;
        }

        public void LoadSettings()
        {
            //it should never not exist but humas are idiots and will delets it as some point
            if(File.Exists(Application.dataPath + "/Resources/Settings.json"))
            {
                string jsonData;
                JsonData settingsData;

                //the data from the json file is put into a string
                jsonData = File.ReadAllText(Application.dataPath + "/Resources/Settings.json");

                //the json data is formatted into a dictionary
                settingsData = JsonMapper.ToObject(jsonData);

                //the serrings are applied
                fullscreen = (bool)settingsData["Fullscreen"];
                refreshRateDropdown.value = currentRefreshRate = (int)settingsData["RefreshRate"];
                resolutionDropdown.value = currentResolution = (int)settingsData["Resolution"];
                vSyncDropdown.value = currentVSyncOption = (int)settingsData["VSyncOption"];
                textureQualityDropdown.value = currentTextureQuality = (int)settingsData["TextureQuality"];
                aADropdown.value = aADropdown.value = (int)settingsData["AAOption"];
                anisotropicDropdown.value = anisotropicDropdown.value = (int)settingsData["AFOption"];
                fOVSlider.value = currentFOVoption = (int)settingsData["FOV"];

                Debug.Assert(refreshRateDropdown.value == currentRefreshRate);
            }
            else
            {
                SaveSettings();
            }
        }

        public void SaveSettings()
        {
            //sets the values to temp variables
            //TODO remove
            currentRefreshRate = refreshRateDropdown.value;
            currentResolution = resolutionDropdown.value;
            currentVSyncOption = vSyncDropdown.value;
            currentTextureQuality = textureQualityDropdown.value;
            currentAAOption = aADropdown.value;
            currentAFOption = anisotropicDropdown.value;
            currentFOVoption = (int)fOVSlider.value;

            //saves the settings to the settings class
            Settings settings = new Settings("Editing this File is NOT reccomended - if game crashes after editing DELETE THIS FILE", fullscreen, currentRefreshRate, currentResolution, currentVSyncOption, currentTextureQuality, currentAAOption, currentAFOption, (int)fOVSlider.value);
            
            //makes a JsonData object to that the variabls of the class can be converted
            JsonData settingsJson;

            //converts the settings into JsonData
            settingsJson = JsonMapper.ToJson(settings);

            //writes the JsonData File
            File.WriteAllText(Application.dataPath + "/Resources/Settings.json", settingsJson.ToString());
        }
    }
}