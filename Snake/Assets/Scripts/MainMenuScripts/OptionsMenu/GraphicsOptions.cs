using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

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

            UpdateFulscreenButton();
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
            UpdateFulscreenButton();
        }

        void UpdateFulscreenButton()
        {
            if (Screen.fullScreen)
            {
                fullscreen = true;
                fullscreenToggleButton.isOn = true;
            }
            else
            {
                fullscreen = false;
                fullscreenToggleButton.isOn = false;
            }
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
            Constants.FOV = (int)fOVSlider.value;
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
            if(File.Exists(Application.dataPath + "/Resources/Settings.dat"))
            {
                BinaryFormatter bf = new BinaryFormatter();
                FileStream fs = new FileStream(Application.dataPath + "/Resources/Settings.dat", FileMode.Open, FileAccess.Read);
                SaveGraphicsOptions optionsLoad = new SaveGraphicsOptions();

                try
                {
                    optionsLoad = (SaveGraphicsOptions)bf.Deserialize(fs);
                }
                catch
                {
                    Debug.LogWarning("Oops somethign whent wrong deserializing options data");
                }
                finally
                {
                    fs.Close();
                }

                //the settings are applied
                Screen.fullScreen = optionsLoad.fullscreen;
                refreshRateDropdown.value = currentRefreshRate = optionsLoad.currentRefreshRate;
                resolutionDropdown.value = currentResolution = optionsLoad.currentResolution;
                vSyncDropdown.value = currentVSyncOption = optionsLoad.currentVSyncOption;
                textureQualityDropdown.value = currentTextureQuality = optionsLoad.currentTextureQuality;
                aADropdown.value = aADropdown.value = optionsLoad.currentAAOption;
                anisotropicDropdown.value = anisotropicDropdown.value = optionsLoad.currentAFOption;
                fOVSlider.value = currentFOVoption = Constants.FOV = optionsLoad.currentFOVoption;

                Debug.Assert(refreshRateDropdown.value == currentRefreshRate);

                UpdateFulscreenButton();
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

            BinaryFormatter bf = new BinaryFormatter();
            FileStream fs = new FileStream(Application.dataPath + "/Resources/Settings.dat", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            SaveGraphicsOptions optionsSave = new SaveGraphicsOptions(fullscreen, currentResolution, currentRefreshRate, currentVSyncOption, currentTextureQuality, currentAAOption, currentAFOption, currentFOVoption);

            try
            {
                bf.Serialize(fs, optionsSave);
            }
            catch
            {
                Debug.LogWarning("Oops something whent wring serializing the options data");
            }
            finally
            {
                fs.Close();
            }
        }
    }

    [System.Serializable]
    public class SaveGraphicsOptions
    {
        public bool fullscreen;
        public int currentResolution;
        public int currentRefreshRate;
        public int currentVSyncOption;
        public int currentTextureQuality;
        public int currentAAOption;
        public int currentAFOption;
        public int currentFOVoption;

        public SaveGraphicsOptions(bool _fullscreen, int _resolution, int _refreshRate, int _vSync, int _TQ, int _AA, int _AF, int _FOV)
        {
            fullscreen = _fullscreen;
            currentResolution = _resolution;
            currentRefreshRate = _refreshRate;
            currentVSyncOption = _vSync;
            currentTextureQuality = _TQ;
            currentAAOption = _AA;
            currentAFOption = _AF;
            currentFOVoption = _FOV;
        }

        public SaveGraphicsOptions(){}
    }
}