    using Entity;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using SystemOperations.BaseSO;

    namespace SystemOperations.SystemOperations
    {
        public class SearchGameSystemOperation : BaseSystemOperations
        {
            public List<Game> filteredGames { get; set; }
            public string filter;
            private Game game;
            protected override void ExecuteConcreteOperation()
            {
                game = new Game();
                filteredGames = repository.Select(game, $"t.Name like '%{filter}%' or " +
                    $"tt.Name like '%{filter}%'")
                    .Cast<Game>().ToList();
            }
        }
    }
