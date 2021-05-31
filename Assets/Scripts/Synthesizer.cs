using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Synthesizer<TMaterial, TProduct>
{
    [SerializeField]
    private List<TMaterial> _materials = new List<TMaterial>();
    [SerializeField]
    private TProduct _product;

    public IEnumerable<TMaterial> Materials { get { return _materials; } }
    public TProduct Product { get { return _product; } }
}