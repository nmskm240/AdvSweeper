using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Adv;
using UI;

namespace Alchemy
{
    public class Alchemist : Player
    {
        [SerializeField]
        private Transform _materials;
        [SerializeField]
        private Jar _jar;
        [SerializeField]
        private RecipeData _selectRecipeData;

        private void Awake()
        {
            var factory = new MaterialNodeFactory();
            foreach(var materialAndQuantity in _selectRecipeData.NeedMaterials)
            {
                var obj = factory.Create();
                var node = obj.GetComponent<MaterialNode>();
                obj.transform.SetParent(_materials);
                obj.transform.localScale = Vector3.one;
                node.Init(materialAndQuantity);
            }
        }

        public void Alchemy()
        {
            var useMaterials = new List<ItemData>();
            foreach(Transform tf in _materials)
            {
                var materialNode = tf.gameObject.GetComponent<MaterialNode>();
                if(materialNode.NeedQuantity != materialNode.SelectedMaterials.Count())
                {
                    var factory = new DialogFactory();
                    var dialog = factory.Create().GetComponent<Dialog>();
                    dialog.Show(DialogType.AgreeOnly, "素材の選択が完了していません。", () => {});
                    return;
                }
                useMaterials.AddRange(materialNode.SelectedMaterials);
            }
            _container.Contents.Add(_jar.Alchemy(useMaterials));
        }
    }
}