using UnityEngine;
using System.Collections;

namespace Snake
{
    [RequireComponent(typeof(MeshFilter))]
    [RequireComponent(typeof(MeshRenderer))]
	public class CombineMeshes : MonoBehaviour {
        
		void Start ()
		{
            var meshFilters = GetComponentsInChildren<MeshFilter>();
            CombineInstance[] combine = new CombineInstance[meshFilters.Length];

            combine[0].mesh = new Mesh();

            for (int i = 1; i < meshFilters.Length; i++)
            {
                if(meshFilters[i]  != null)
                {
                    if((meshFilters[i].name == "Wall") || (meshFilters[i].name == "Tower"))
                    {
                        combine[i].mesh = new Mesh();
                    }
                    else
                    {
                        combine[i].mesh = meshFilters[i].mesh;
                        combine[i].transform = meshFilters[i].transform.localToWorldMatrix;
                        Destroy(meshFilters[i].gameObject);
                    }
                }
            }

            GetComponent<MeshFilter>().mesh = new Mesh();
            GetComponent<MeshFilter>().mesh.CombineMeshes(combine);
            transform.gameObject.SetActive(true);

            transform.localScale = new Vector3(5, 5, 5);
		}
	}
}