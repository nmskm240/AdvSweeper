using UnityEngine;
using Alchemy;
using UI;

namespace UI.Orders
{
    [CreateAssetMenu(fileName = "LoadRecipeOrder", menuName = "AdvSweeper/Order/LoadRecipeOrder", order = 0)]
    public class LoadRecipeOrder : Order
    {
        public RecipeData Data;

        public override void Reset()
        {
            base.Reset();
            Data = null;
        }  

        public void SetData(RecipeNode node)
        {
            Data = node.Data;
        }
    }
}