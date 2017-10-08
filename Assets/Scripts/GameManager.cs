public static class GameManager
{
    private static bool isGameStarted = false;

    public static bool IsGameStarted
    {
        get { return isGameStarted; }
        set { isGameStarted = value; }
    }
}