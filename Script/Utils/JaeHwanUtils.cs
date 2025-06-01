public class JaeHwanUtils
{
    private static JaeHwanUtils instance;
    public static JaeHwanUtils Instance
    {
        get
        {
            instance ??= new JaeHwanUtils();

            return instance;
        }
    }

    public bool isStarted = false;

    public ServerRestApi serverRestApi;

    public SceneLoaderManager sceneLoaderManager;

    public CursorManager cursorManager;

    public LoadingManager loadingManager;

    public PopupManager popupManager;
    
    public bool soundOnOff = true;

    public int score = 0;

    public const string GameName = "HomeBound";
}
