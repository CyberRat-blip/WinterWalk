using UnityEngine;
public class SnowBrush : MonoBehaviour
{
    public CustomRenderTexture SnowHeightMap;
    public Material HeightMapUpdate;
    public float SecondsToRestore = 100;

   // public GameObject[] Tires;
    public GameObject[] Paws;

    //private int tireIndex;
    private int pawsIndex;
    private float timeToRestoreOneTick;
    private static readonly int DrawPosition = Shader.PropertyToID("_DrawPosition");
    private static readonly int DrawAngle = Shader.PropertyToID("_DrawAngle");
    private static readonly int RestoreAmount = Shader.PropertyToID("_RestoreAmount");

    private void Start()
    {
        SnowHeightMap.Initialize();
    }
    private void Update()
    {
       // DrawWithTires();
        DrawWithPaws();
        timeToRestoreOneTick -= Time.deltaTime;
        if (timeToRestoreOneTick < 0)
        {
            // Если в этот update мы хотим увеличить цвет всех пикселей карты высот на 1
            HeightMapUpdate.SetFloat(RestoreAmount, 1 / 250f);
            timeToRestoreOneTick = SecondsToRestore / 250f;
        }
        else
        {
            // Если не хотим
            HeightMapUpdate.SetFloat(RestoreAmount, 0);
        }
        SnowHeightMap.Update();
    }
     private void DrawWithPaws()
        {
            GameObject paw = Paws[pawsIndex++ % Paws.Length];
            Ray ray = new Ray(paw.transform.position, Vector3.down);
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                Vector2 hitTextureCoord = hit.textureCoord;
                float angle = paw.transform.rotation.eulerAngles.y;

                HeightMapUpdate.SetVector(DrawPosition, hitTextureCoord);
                HeightMapUpdate.SetFloat(DrawAngle, angle * Mathf.Deg2Rad);
            }
        }
    }
