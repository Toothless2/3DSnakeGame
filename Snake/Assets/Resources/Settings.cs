public class Settings
{
    public string WARNING;
    public bool Fullscreen;
    public int RefreshRate;
    public int Resolution;
    public int VSyncOption;
    public int TextureQuality;
    public int AAOption;
    public int AFOption;

    public Settings(string WARNING, bool fullscreen, int refreshRate, int resolution, int vSyncOption, int textureQuality, int aAOption, int aFOption)
    {
        this.WARNING = WARNING;
        Fullscreen = fullscreen;
        RefreshRate = refreshRate;
        Resolution = resolution;
        VSyncOption = vSyncOption;
        TextureQuality = textureQuality;
        AAOption = aAOption;
        AFOption = aFOption;
    }
}