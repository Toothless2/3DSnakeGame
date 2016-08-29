public class Settings
{
    public static string WARNING;
    public static bool Fullscreen;
    public static int RefreshRate;
    public static int Resolution;
    public static int VSyncOption;
    public static int TextureQuality;
    public static int AAOption;
    public static int AFOption;
    public static int FOV = 85;

    public Settings(string _WARNING, bool fullscreen, int refreshRate, int resolution, int vSyncOption, int textureQuality, int aAOption, int aFOption, int fOV)
    {
        WARNING = _WARNING;
        Fullscreen = fullscreen;
        RefreshRate = refreshRate;
        Resolution = resolution;
        VSyncOption = vSyncOption;
        TextureQuality = textureQuality;
        AAOption = aAOption;
        AFOption = aFOption;
        FOV = fOV;
    }
}