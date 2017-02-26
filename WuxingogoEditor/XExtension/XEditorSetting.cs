using UnityEngine;
using System.Collections;
using UnityEditor;
using System;
using wuxingogo.tools;
public class XEditorSetting : XBaseWindow
{
    public static string author = "Wuxingogo";
    public static string mail = "52111314ly@gmail.com";
    /// <summary>
    /// file name, author, mail and time.
    /// </summary>
    public static string codeFileHeader = "//{0}\n" + 
        "//\n" + 
        "//Author:\n" +
        "//\t\t{1} {2}\n" +
        "//\n" +
        "//\n" + 
        "//\t\tCopyright (c) {3} \n" +
        "//\n" + 
        "//\tYou should have received a copy of the GNU Lesser General Public License" +
        "along with this program.\n" + 
        "//\tIf not, see <http://www.gnu.org/licenses/>.\n";
	
    public const string PluginName = "Plugins/WuxingogoExtension";
	public static string PluginPath{
		get{
			return XFileUtils.CombinePath(Application.dataPath, PluginName);
		}
	}
	public static string RelativeProjectPath = XFileUtils.CombinePath("Assets", PluginName);
	public static string TemplatesPath{
		get{
			return XFileUtils.CombinePath(PluginPath,"Templates");
		}
	}
	public static string relativePath{
		get{
			return FileUtil.GetProjectRelativePath(PluginPath);
		}
	}
	public static string ProjectPath{
		get{
			return XFileUtils.GetAbsolutePath(Application.dataPath, "..");
		}
	}
	private bool isShowIcons = false;
	
    [MenuItem( "Wuxingogo/Wuxingogo XEditorSetting" )]
    static void init()
    {
		InitWindow<XEditorSetting>();
    }

    public override void OnXGUI()
    {
        if (CreateSpaceButton("Save Asset"))
        {
            XResources.SaveAll();
        }
        
		DoButton("ShowAllIcon", ()=> isShowIcons = !isShowIcons);
		
		if(isShowIcons) ShowAllIcon();

		DoButton("persistentDataPath", ()=> {
			EditorUtility.RevealInFinder(Application.persistentDataPath);
		});
		DoButton("temporaryCachePath", ()=> {
			EditorUtility.RevealInFinder(Application.temporaryCachePath);
		});
		DoButton("dataPath", ()=> {
			EditorUtility.RevealInFinder(Application.dataPath);
		});
		DoButton("streamingAssetsPath", ()=> {
			EditorUtility.RevealInFinder(Application.streamingAssetsPath);
		});
    }
    
    public void ShowAllIcon(){
		foreach (MouseCursor item in Enum.GetValues(typeof(MouseCursor)))
		{
			DoButton(Enum.GetName(typeof(MouseCursor),item), ()=> XLogger.Log(item.ToString()));
			EditorGUIUtility.AddCursorRect(GUILayoutUtility.GetLastRect(), item);
			GUILayout.Space(10);
		}
    }
}
