using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

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

        /*
        void Start()
        {
            FirstLoad();
            UpdateSettings();
        }
        */
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
        }

        void SetResolutions()
        {
            resolutionDropdown.ClearOptions();

            resolutions = Screen.resolutions;

            foreach(Resolution resolution in resolutions)
            {
                string resolutionText = resolution.width + " x " + resolution.height + " @ " + resolution.refreshRate + "Hz";
                resolutionDropdown.options.Add(new Dropdown.OptionData() { text = resolutionText });
            }

            resolutionDropdown.value = 0;
        }

        void ToggleFullscreen()
        {
            fullscreen = !fullscreen;
        }

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
                    aADropdown.options.Add(new Dropdown.OptionData() { text = aALvl.ToString() + "x SMAA" });
                }
            }

            aADropdown.value = 1;
        }

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

        public void UpdateSettings()
        {
            SaveSettings();

            Screen.fullScreen = fullscreen;
            Screen.SetResolution(resolutions[resolutionDropdown.value].width, resolutions[resolutionDropdown.value].height, fullscreen, refreshRates[refreshRateDropdown.value]);

            QualitySettings.vSyncCount = vSyncDropdown.value;
            QualitySettings.masterTextureLimit = textureQualityDropdown.value;
            QualitySettings.antiAliasing = aAOptions[aADropdown.value];
            QualitySettings.anisotropicFiltering = (AnisotropicFiltering)anisotropicDropdown.value;
        }

        public void LoadSettings()
        {

        }

        void SaveSettings()
        {
            currentRefreshRate = refreshRateDropdown.value;
            currentResolution = resolutionDropdown.value;
            currentVSyncOption = vSyncDropdown.value;
            currentTextureQuality = textureQualityDropdown.value;
            currentAAOption = aADropdown.value;
            currentAFOption = anisotropicDropdown.value;
        }
    }
}