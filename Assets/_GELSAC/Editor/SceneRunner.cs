using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class SceneRunner : EditorWindow
{
  // [MenuItem ("Dev/Open Dev Tools _%#T")]
  // public static void ShowWindow ()
  // {
  //     // Opens the window, otherwise focuses it if it’s already open.
  //     var window = GetWindow<SceneRunner> ();

  //     // Adds a title to the window.
  //     window.titleContent = new GUIContent ("Dev Tools");

  //     // Sets a minimum size to the window.
  //     window.minSize = new Vector2 (250, 50);
  // }
  // private void OnEnable ()
  // {
  //     // Reference to the root of the window.
  //     var root = rootVisualElement;

  //     // Creates our button and sets its Text property.
  //     var startGameButton = new Button () { text = "Start Game" };
  //     var startCalibrationButton = new Button () { text = "Start Calibration Scene" };
  //     var reloadButton = new Button () { text = "Reload Current Scene" };
  //     // Adds it to the root.
  //     root.Add (new Label (" "));
  //     root.Add (startGameButton);
  //     root.Add (startCalibrationButton);
  //     root.Add (new Label (" "));
  //     root.Add (reloadButton);
  //     startGameButton.clickable.clicked += () => StartGame ();
  //     startCalibrationButton.clickable.clicked += () => StartCalibration ();
  //     reloadButton.clickable.clicked += () => Reload ();
  // }
  // private void StartGame ()
  // {
  //     Debug.Log ("Starting game...");
  // }
  // private void StartCalibration ()
  // {
  //     Debug.Log ("Starting calibration...");
  // }
  // private void Reload ()
  // {
  //     SceneManager.LoadScene (SceneManager.GetActiveScene ().name);
  // }
}