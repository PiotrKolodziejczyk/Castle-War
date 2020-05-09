using Assets.Scripts.CastleScene;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class Global
{
    public static int currentCastle;
    public static string whichScene = Scenes.SampleScene.ToString();
    public static bool isSoldierPanelOnInCastleScene = false;
    public static bool isTowerPanelOnInCastleScene = false;

    public static void SetAppropriateCursor(Texture2D texture)
    {
        Cursor.SetCursor(texture, Vector2.zero, CursorMode.ForceSoftware);
    }
    public static void LoadAppropriateSceneTroughtTheLoadingScene(Scenes whichScene, int id)
    {
        Global.currentCastle = id;
        Global.whichScene = whichScene.ToString();
        SceneManager.LoadScene("LoadingScene");
    }
    public static bool Timer(ref float time)
    {
        time -= Time.deltaTime;
        if (time < 0)
            return true;
        return false;
    }

}
public enum Scenes
{
    MenuScene,
    SampleScene,
    BattleScene,
    CastleScene
}
