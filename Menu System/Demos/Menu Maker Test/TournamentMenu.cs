using System.Collections.Generic;
using MenuManagement.Behaviours;


namespace MyMagicSpace
{
    public class TournamentMenu : BaseDynamicMenu<TournamentInfo, TournamentItemPrefab, TournamentMenu>
    {
        protected override TournamentMenu CommonObject => this;
        
        protected override IEnumerable<TournamentInfo> GetItems()
        {
            throw new System.NotImplementedException();
        }
    }
}
